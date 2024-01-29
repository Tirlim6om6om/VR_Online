using System;
using System.Collections;
using System.Collections.Generic;
using Code.Scripts.Network;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

namespace Code.Scripts.UI
{
    public class RoomList : MonoBehaviourPunCallbacks
    {
        [SerializeField] private GameObject prefab;
        [SerializeField] private Transform parent;
        [SerializeField] private List<GameObject> rooms = new List<GameObject>();
        private bool _processing;

        public override void OnRoomListUpdate(List<RoomInfo> roomList)
        {
            StartCoroutine(UpdatingList(roomList));
        }

        private IEnumerator UpdatingList(List<RoomInfo> roomList)
        {
            yield return new WaitWhile(() => _processing);
            _processing = true;
            for (int i = 0; i < rooms.Count; i++)
            {
                Destroy(rooms[i]);
                yield return new WaitWhile(() => rooms[i] != null);
            }

            rooms = new List<GameObject>();
            
            foreach (var roomInfo in roomList)
            {
                GameObject newRoom = Instantiate(prefab, parent);
                newRoom.TryGetComponent(out RoomElement roomElement);
                roomElement.SetInfo(roomInfo);
                rooms.Add(newRoom);
            }
            _processing = false;
        }
    }
}
