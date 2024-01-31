using Fusion;
using Fusion.Addons.Physics;
using UltimateXR.Manipulation;
using UnityEngine;

namespace Code.Scripts
{
    public class GrabbableNetwork : NetworkBehaviour
    {
        private UxrGrabbableObject _grabbable;
        private Rigidbody _rb;
        private NetworkRigidbody3D _rbNet;
    
        public override void Spawned()
        {
            base.Spawned();
            TryGetComponent(out _grabbable);
            TryGetComponent(out _rb);
            TryGetComponent(out _rbNet);
            _grabbable.GrabbingNetwork += OnGrabbedNet;
            _grabbable.Grabbed += OnGrabbed;
            _grabbable.Released += OnThrow;
        }

        private void OnGrabbedNet(object sender, UxrManipulationEventArgs e)
        {
            RPCGrabNet();
        }

        private void OnGrabbed(object sender, UxrManipulationEventArgs e)
        {
        
            RPCGrab();
        }

        private void OnThrow(object sender, UxrManipulationEventArgs e)
        {
            RPCRelease();
        }

        [Rpc(RpcSources.All, RpcTargets.Proxies, HostMode = RpcHostMode.SourceIsServer)]
        private void RPCGrabNet(RpcInfo info = default)
        {
            print("Grab try!");
            UxrGrabManager.Instance.ReleaseGrabs(_grabbable, false);
        }
    
        [Rpc(RpcSources.All, RpcTargets.All, HostMode = RpcHostMode.SourceIsServer)]
        private void RPCGrab(RpcInfo info = default)
        {
            _rb.isKinematic = true;
            _rbNet.RBIsKinematic = true;
        }
    
        [Rpc(RpcSources.All, RpcTargets.All, HostMode = RpcHostMode.SourceIsServer)]
        public void RPCRelease(RpcInfo info = default)
        {
            _rb.isKinematic = false;
            _rbNet.RBIsKinematic = false;
        }
    }
}
