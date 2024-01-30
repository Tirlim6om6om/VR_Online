using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fusion;

public class NetworkRig : NetworkBehaviour
{
    public bool IsLocalNetworkRig => Object.HasStateAuthority;

    [Header("RigComponents")]
    [SerializeField]
    private NetworkTransform playerTransform;

    [SerializeField]
    private NetworkTransform headTransform;

    [SerializeField]
    private NetworkTransform leftHandTransform;

    [SerializeField]
    private NetworkTransform rightHandTransform;

    HardwareRig hardwareRig;

    public override void Spawned()
    {
        base.Spawned();

        if (IsLocalNetworkRig)
        {
            hardwareRig = FindObjectOfType<HardwareRig>();
            if (hardwareRig == null) 
                Debug.LogError("Missing HardwareRig in the scene");
        }
        // else it means that this is a client
    }

    public override void FixedUpdateNetwork()
    {
        base.FixedUpdateNetwork();

        if (GetInput<RigState>(out var input))
        {
            playerTransform.transform.SetPositionAndRotation(input.PlayerPosition, input.PlayerRotation);

            headTransform.transform.SetPositionAndRotation(input.Head.Pos, input.Head.Rot);

        }
    }

    public override void Render()
    {
        base.Render();
        if (IsLocalNetworkRig)
        {
            playerTransform.transform.SetPositionAndRotation(hardwareRig.playerTransform.position, hardwareRig.playerTransform.rotation);
            
            headTransform.transform.SetPositionAndRotation(hardwareRig.avatar.AvatarRig.Head.Head.position, hardwareRig.avatar.AvatarRig.Head.Head.rotation);

        }
    }
}
