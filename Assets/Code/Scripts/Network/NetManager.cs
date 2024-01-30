using System;
using Photon.Pun;
using UnityEngine;

namespace Code.Scripts.Network
{
    public class NetManager : MonoBehaviourPunCallbacks
    {
        [SerializeField] private GameObject playerPrefab;
        [SerializeField] private Transform point;

        private void Start()
        {
            PhotonNetwork.Instantiate(playerPrefab.name, point.position, Quaternion.identity);
        }
    }
}
