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
    }

    private void OnGrabbed(object sender, UxrManipulationEventArgs e)
    {
        _obj.RequestStateAuthority();
    }
    
}
