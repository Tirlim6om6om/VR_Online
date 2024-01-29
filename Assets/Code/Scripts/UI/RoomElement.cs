using Photon.Pun;
using Photon.Realtime;
using TMPro;
using UnityEngine;

namespace Code.Scripts.UI
{
    public class RoomElement : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI nameText;
        [SerializeField] private TextMeshProUGUI countPlayerText;
        private RoomInfo _roomInfo;

        public void SetInfo(RoomInfo roomInfo)
        {
            nameText.text = roomInfo.Name;
            countPlayerText.text = roomInfo.PlayerCount + " / " + roomInfo.MaxPlayers;
            _roomInfo = roomInfo;
        }

        public void Connect()
        {
            PhotonNetwork.JoinRoom(_roomInfo.Name);
        }
    }
}
