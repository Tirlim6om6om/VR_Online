using System;
using System.Collections.Generic;
using Photon.Pun;
using UltimateXR.Avatar;
using UltimateXR.Avatar.Controllers;
using UnityEngine;

namespace Code.Scripts.Network
{
    public class NetworkPlayer : MonoBehaviour
    {
        [SerializeField] private Camera cam;
        [SerializeField] private AudioListener listener;
        [SerializeField] private UxrHandIntegration handR;
        [SerializeField] private UxrHandIntegration handL;
        [SerializeField] private List<GameObject> destroyingObjs;


        private void Start()
        {
            TryGetComponent(out PhotonView view);
            if(view.IsMine)
                return;
            TryGetComponent(out UxrStandardAvatarController avatarController);
            Destroy(avatarController);
            TryGetComponent(out UxrAvatar avatar);
            Destroy(avatar);
            Destroy(cam);
            Destroy(listener);
            Destroy(handR);
            Destroy(handL);
            foreach (var obj in destroyingObjs)
            {
                Destroy(obj);
            }
        }
    }
}
