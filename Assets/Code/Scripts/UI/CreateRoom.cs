using Code.Scripts.Network;
using Photon.Realtime;
using TMPro;
using UnityEngine;

namespace Code.Scripts.UI
{
    public class CreateRoom : MonoBehaviour
    {
        [SerializeField] private LobbyManager network;
        [SerializeField] private TMP_InputField inputField;
        
        public void Create()
        {
            network.CreateRoom(inputField.text);
        }
    }
}
