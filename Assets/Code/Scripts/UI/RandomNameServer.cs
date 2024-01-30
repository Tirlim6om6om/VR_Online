using System;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Code.Scripts.UI
{
    public class RandomNameServer : MonoBehaviour
    {
        private void OnEnable()
        {
            TryGetComponent(out TMP_InputField field);
            field.text = "Room_" + Random.Range(1000, 9999);
        }
    }
}
