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
    
    public override void Spawned()
    {
        base.Spawned();
        TryGetComponent(out _grabbable);
        TryGetComponent(out _obj);
        _grabbable.Grabbed += OnGrabbed;
    }

    private void OnGrabbed(object sender, UxrManipulationEventArgs e)
    {
        RPCGrab();
    }

    public void OnGrabbed()
    {
        RPCGrab();
    }

    private void OnThrow(object sender, UxrManipulationEventArgs e)
    {
        RPCRelease();
    }
    
    
    [Rpc(RpcSources.All, RpcTargets.Proxies, HostMode = RpcHostMode.SourceIsServer)]
    private void RPCGrab(RpcInfo info = default)
    {
        print("Grab try!");
        UxrGrabManager.Instance.ReleaseGrabs(_grabbable, false);
        return;
        if (!info.IsInvokeLocal)
        {
            UxrGrabManager.Instance.ReleaseGrabs(_grabbable, false);
            Debug.Log("Release");
        }
        else
        {
            Debug.Log("Take!");
        }
    }
    
    [Rpc(RpcSources.All, RpcTargets.Proxies, HostMode = RpcHostMode.SourceIsServer)]
    public void RPCRelease(RpcInfo info = default)
    {
        
    }
}
