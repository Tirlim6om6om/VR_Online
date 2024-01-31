using System;
using System.Collections;
using System.Collections.Generic;
using Fusion;
using UltimateXR.Manipulation;
using UnityEngine;

public class GrabbableNetwork : NetworkBehaviour
{
    private UxrGrabbableObject _grabbable;
    private NetworkObject _obj;
    
    private void Start()
    {
        TryGetComponent(out _grabbable);
        TryGetComponent(out _obj);
        _grabbable.Grabbed += OnGrabbed;
        _grabbable.Released += OnThrow;
    }

    private void OnGrabbed(object sender, UxrManipulationEventArgs e)
    {
        //_obj.RequestStateAuthority();
        RPCGrab();
    }

    private void OnThrow(object sender, UxrManipulationEventArgs e)
    {
        RPCRelease();
    }
    
    
    [Rpc(RpcSources.All, RpcTargets.Proxies, HostMode = RpcHostMode.SourceIsServer)]
    public void RPCGrab(RpcInfo info = default)
    {
        UxrGrabManager.Instance.ReleaseGrabs(_grabbable, false);
    }
    
    [Rpc(RpcSources.All, RpcTargets.Proxies, HostMode = RpcHostMode.SourceIsServer)]
    public void RPCRelease(RpcInfo info = default)
    {
        
    }
}
