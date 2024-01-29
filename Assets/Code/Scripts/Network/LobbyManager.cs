using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using UnityEngine.Events;

namespace Code.Scripts.Network
{
    public class LobbyManager : MonoBehaviourPunCallbacks
    {
        private string _gameVersion = "0.1";
        
        private void Start()
        {
            PhotonNetwork.AutomaticallySyncScene = true;
            PhotonNetwork.NickName = "Player_" + Random.Range(1000, 9999); 
            if (!PhotonNetwork.IsConnected)
            {
                PhotonNetwork.PhotonServerSettings.AppSettings.AppVersion = _gameVersion;
                PhotonNetwork.ConnectUsingSettings();
            }
        }
        
        public override void OnConnectedToMaster()
        {
            PhotonNetwork.JoinLobby(TypedLobby.Default);
        }
        
        public void CreateRoom(string roomName)
        {
            PhotonNetwork.CreateRoom(roomName, new RoomOptions { MaxPlayers = 4, PublishUserId = true});
        }

        public override void OnJoinedRoom()
        {
            print("Connect to: " + PhotonNetwork.CurrentRoom.Name);
            PhotonNetwork.LoadLevel("Main");
        }
    }
}
