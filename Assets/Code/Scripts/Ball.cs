using System;
using Fusion;
using Fusion.Addons.Physics;
using UnityEngine;

namespace Code.Scripts
{
    public class Ball : NetworkBehaviour
    {
        private NetworkRigidbody3D _rb;

        private void Start()
        {
            TryGetComponent(out _rb);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Hand"))
            {
               KicK(other.transform.forward);
            }
        }
        
        //[Rpc(RpcSources.All, RpcTargets.All, HostMode = RpcHostMode.SourceIsServer)]
        private void KicK(Vector3 direction)
        {
            _rb.Rigidbody.AddForce(direction, ForceMode.Impulse);
        }
    }
}
