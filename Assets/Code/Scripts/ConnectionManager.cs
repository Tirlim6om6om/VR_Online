using TMPro;
using UnityEngine;

namespace Code.Scripts
{
    public class ConnectionManager : MonoBehaviour
    {
        [SerializeField] private TMP_InputField inputField;
    
        public void CreateRoom()
        {
            NetworkManager.Instance.CreateSession(inputField.text);
        }

        public void JoinRoom()
        {
            NetworkManager.Instance.JoinSession(inputField.text);
        }
    }
}
