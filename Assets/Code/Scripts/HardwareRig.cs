using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fusion;
using Fusion.Sockets;
using System;
using UltimateXR.Avatar;
using UltimateXR.Avatar.Rig;

public class HardwareRig : MonoBehaviour, INetworkRunnerCallbacks
{
    public Transform playerTransform;
    public UxrAvatar avatar;

    void Start()
    {
        NetworkManager.Instance.Runner.AddCallbacks(this);
    }


    #region INetworkRunnerCallbacks

    void INetworkRunnerCallbacks.OnInput(NetworkRunner runner, NetworkInput input)
    {
        RigState xrRigState = new RigState();
        xrRigState.PlayerPosition = playerTransform.position;
        xrRigState.PlayerRotation = playerTransform.rotation;
        UxrAvatarRig rig = avatar.AvatarRig;
        
        //Основа
        xrRigState.UpperChest.Set(rig.UpperChest.position, rig.UpperChest.rotation);
        xrRigState.Chest.Set(rig.Chest.position, rig.UpperChest.rotation);
        xrRigState.Spine.Set(rig.Spine.position, rig.Spine.rotation);
        xrRigState.Hips.Set(rig.Hips.position, rig.Hips.rotation);


        #region arm left
        //ARM LEFT
        xrRigState.LeftArm.Clavicle.Set(rig.LeftArm.Clavicle.position, rig.LeftArm.Clavicle.rotation);
        xrRigState.LeftArm.UpperArm.Set(rig.LeftArm.UpperArm.position, rig.LeftArm.UpperArm.rotation);
        xrRigState.LeftArm.Forearm.Set(rig.LeftArm.Forearm.position, rig.LeftArm.Forearm.rotation);
        //HandLeft
        xrRigState.LeftArm.Hand.Wrist.Set(rig.LeftArm.Hand.Wrist.position, rig.LeftArm.Hand.Wrist.rotation);
        //FINGERS LEFT
        //Thumb
        xrRigState.LeftArm.Hand.Thumb.Intermediate.Set(rig.LeftArm.Hand.Thumb.Intermediate.position, rig.LeftArm.Hand.Thumb.Intermediate.rotation);
        xrRigState.LeftArm.Hand.Thumb.Metacarpal.Set(rig.LeftArm.Hand.Thumb.Metacarpal.position, rig.LeftArm.Hand.Thumb.Metacarpal.rotation);
        xrRigState.LeftArm.Hand.Thumb.Proximal.Set(rig.LeftArm.Hand.Thumb.Proximal.position, rig.LeftArm.Hand.Thumb.Proximal.rotation);
        xrRigState.LeftArm.Hand.Thumb.Distal.Set(rig.LeftArm.Hand.Thumb.Distal.position, rig.LeftArm.Hand.Thumb.Distal.rotation);
        //Index
        xrRigState.LeftArm.Hand.Index.Intermediate.Set(rig.LeftArm.Hand.Index.Intermediate.position, rig.LeftArm.Hand.Index.Intermediate.rotation);
        xrRigState.LeftArm.Hand.Index.Metacarpal.Set(rig.LeftArm.Hand.Index.Metacarpal.position, rig.LeftArm.Hand.Index.Metacarpal.rotation);
        xrRigState.LeftArm.Hand.Index.Proximal.Set(rig.LeftArm.Hand.Index.Proximal.position, rig.LeftArm.Hand.Index.Proximal.rotation);
        xrRigState.LeftArm.Hand.Index.Distal.Set(rig.LeftArm.Hand.Index.Distal.position, rig.LeftArm.Hand.Index.Distal.rotation);
        //Middle
        xrRigState.LeftArm.Hand.Middle.Intermediate.Set(rig.LeftArm.Hand.Middle.Intermediate.position, rig.LeftArm.Hand.Middle.Intermediate.rotation);
        xrRigState.LeftArm.Hand.Middle.Metacarpal.Set(rig.LeftArm.Hand.Middle.Metacarpal.position, rig.LeftArm.Hand.Middle.Metacarpal.rotation);
        xrRigState.LeftArm.Hand.Middle.Proximal.Set(rig.LeftArm.Hand.Middle.Proximal.position, rig.LeftArm.Hand.Middle.Proximal.rotation);
        xrRigState.LeftArm.Hand.Middle.Distal.Set(rig.LeftArm.Hand.Middle.Distal.position, rig.LeftArm.Hand.Middle.Distal.rotation);
        //Ring
        xrRigState.LeftArm.Hand.Ring.Intermediate.Set(rig.LeftArm.Hand.Ring.Intermediate.position, rig.LeftArm.Hand.Ring.Intermediate.rotation);
        xrRigState.LeftArm.Hand.Ring.Metacarpal.Set(rig.LeftArm.Hand.Ring.Metacarpal.position, rig.LeftArm.Hand.Ring.Metacarpal.rotation);
        xrRigState.LeftArm.Hand.Ring.Proximal.Set(rig.LeftArm.Hand.Ring.Proximal.position, rig.LeftArm.Hand.Ring.Proximal.rotation);
        xrRigState.LeftArm.Hand.Ring.Distal.Set(rig.LeftArm.Hand.Ring.Distal.position, rig.LeftArm.Hand.Ring.Distal.rotation);
        //Little
        xrRigState.LeftArm.Hand.Little.Intermediate.Set(rig.LeftArm.Hand.Little.Intermediate.position, rig.LeftArm.Hand.Little.Intermediate.rotation);
        xrRigState.LeftArm.Hand.Little.Metacarpal.Set(rig.LeftArm.Hand.Little.Metacarpal.position, rig.LeftArm.Hand.Little.Metacarpal.rotation);
        xrRigState.LeftArm.Hand.Little.Proximal.Set(rig.LeftArm.Hand.Little.Proximal.position, rig.LeftArm.Hand.Little.Proximal.rotation);
        xrRigState.LeftArm.Hand.Little.Distal.Set(rig.LeftArm.Hand.Little.Distal.position, rig.LeftArm.Hand.Little.Distal.rotation);
        

        #endregion

        #region arm right
        //ARM Right
        xrRigState.RightArm.Clavicle.Set(rig.RightArm.Clavicle.position, rig.RightArm.Clavicle.rotation);
        xrRigState.RightArm.UpperArm.Set(rig.RightArm.UpperArm.position, rig.RightArm.UpperArm.rotation);
        xrRigState.RightArm.Forearm.Set(rig.RightArm.Forearm.position, rig.RightArm.Forearm.rotation);
        //HandLeft
        xrRigState.RightArm.Hand.Wrist.Set(rig.RightArm.Hand.Wrist.position, rig.RightArm.Hand.Wrist.rotation);
        //FINGERS LEFT
        //Thumb
        xrRigState.RightArm.Hand.Thumb.Intermediate.Set(rig.RightArm.Hand.Thumb.Intermediate.position, rig.RightArm.Hand.Thumb.Intermediate.rotation);
        xrRigState.RightArm.Hand.Thumb.Metacarpal.Set(rig.RightArm.Hand.Thumb.Metacarpal.position, rig.RightArm.Hand.Thumb.Metacarpal.rotation);
        xrRigState.RightArm.Hand.Thumb.Proximal.Set(rig.RightArm.Hand.Thumb.Proximal.position, rig.RightArm.Hand.Thumb.Proximal.rotation);
        xrRigState.RightArm.Hand.Thumb.Distal.Set(rig.RightArm.Hand.Thumb.Distal.position, rig.RightArm.Hand.Thumb.Distal.rotation);
        //Index
        xrRigState.RightArm.Hand.Index.Intermediate.Set(rig.RightArm.Hand.Index.Intermediate.position, rig.RightArm.Hand.Index.Intermediate.rotation);
        xrRigState.RightArm.Hand.Index.Metacarpal.Set(rig.RightArm.Hand.Index.Metacarpal.position, rig.RightArm.Hand.Index.Metacarpal.rotation);
        xrRigState.RightArm.Hand.Index.Proximal.Set(rig.RightArm.Hand.Index.Proximal.position, rig.RightArm.Hand.Index.Proximal.rotation);
        xrRigState.RightArm.Hand.Index.Distal.Set(rig.RightArm.Hand.Index.Distal.position, rig.RightArm.Hand.Index.Distal.rotation);
        //Middle
        xrRigState.RightArm.Hand.Middle.Intermediate.Set(rig.RightArm.Hand.Middle.Intermediate.position, rig.RightArm.Hand.Middle.Intermediate.rotation);
        xrRigState.RightArm.Hand.Middle.Metacarpal.Set(rig.RightArm.Hand.Middle.Metacarpal.position, rig.RightArm.Hand.Middle.Metacarpal.rotation);
        xrRigState.RightArm.Hand.Middle.Proximal.Set(rig.RightArm.Hand.Middle.Proximal.position, rig.RightArm.Hand.Middle.Proximal.rotation);
        xrRigState.RightArm.Hand.Middle.Distal.Set(rig.RightArm.Hand.Middle.Distal.position, rig.RightArm.Hand.Middle.Distal.rotation);
        //Ring
        xrRigState.RightArm.Hand.Ring.Intermediate.Set(rig.RightArm.Hand.Ring.Intermediate.position, rig.RightArm.Hand.Ring.Intermediate.rotation);
        xrRigState.RightArm.Hand.Ring.Metacarpal.Set(rig.RightArm.Hand.Ring.Metacarpal.position, rig.RightArm.Hand.Ring.Metacarpal.rotation);
        xrRigState.RightArm.Hand.Ring.Proximal.Set(rig.RightArm.Hand.Ring.Proximal.position, rig.RightArm.Hand.Ring.Proximal.rotation);
        xrRigState.RightArm.Hand.Ring.Distal.Set(rig.RightArm.Hand.Ring.Distal.position, rig.RightArm.Hand.Ring.Distal.rotation);
        //Little
        xrRigState.RightArm.Hand.Little.Intermediate.Set(rig.RightArm.Hand.Little.Intermediate.position, rig.RightArm.Hand.Little.Intermediate.rotation);
        xrRigState.RightArm.Hand.Little.Metacarpal.Set(rig.RightArm.Hand.Little.Metacarpal.position, rig.RightArm.Hand.Little.Metacarpal.rotation);
        xrRigState.RightArm.Hand.Little.Proximal.Set(rig.RightArm.Hand.Little.Proximal.position, rig.RightArm.Hand.Little.Proximal.rotation);
        xrRigState.RightArm.Hand.Little.Distal.Set(rig.RightArm.Hand.Little.Distal.position, rig.RightArm.Hand.Little.Distal.rotation);
        #endregion
        
        //Голова
        xrRigState.Head.Set(rig.Head.Head.position,rig.Head.Head.rotation);
        
        input.Set(xrRigState);
        
    }

    #endregion

    #region Unused INetworkRunnerCallbacks

    public void OnInputMissing(NetworkRunner runner, PlayerRef player, NetworkInput input)
    {

    }

    void INetworkRunnerCallbacks.OnConnectedToServer(NetworkRunner runner)
    {

    }

    public void OnDisconnectedFromServer(NetworkRunner runner, NetDisconnectReason reason)
    {

    }

    void INetworkRunnerCallbacks.OnConnectFailed(NetworkRunner runner, NetAddress remoteAddress,
        NetConnectFailedReason reason)
    {

    }

    void INetworkRunnerCallbacks.OnConnectRequest(NetworkRunner runner,
        NetworkRunnerCallbackArgs.ConnectRequest request, byte[] token)
    {

    }

    void INetworkRunnerCallbacks.OnCustomAuthenticationResponse(NetworkRunner runner, Dictionary<string, object> data)
    {

    }

    public void OnHostMigration(NetworkRunner runner, HostMigrationToken hostMigrationToken)
    {

    }


    public void OnObjectExitAOI(NetworkRunner runner, NetworkObject obj, PlayerRef player)
    {

    }

    public void OnObjectEnterAOI(NetworkRunner runner, NetworkObject obj, PlayerRef player)
    {

    }

    void INetworkRunnerCallbacks.OnPlayerJoined(NetworkRunner runner, PlayerRef player)
    {

    }

    void INetworkRunnerCallbacks.OnPlayerLeft(NetworkRunner runner, PlayerRef player)
    {

    }

    void INetworkRunnerCallbacks.OnReliableDataReceived(NetworkRunner runner, PlayerRef player, ReliableKey key,
        ArraySegment<byte> data)
    {

    }

    public void OnReliableDataProgress(NetworkRunner runner, PlayerRef player, ReliableKey key, float progress)
    {
        throw new NotImplementedException();
    }

    void INetworkRunnerCallbacks.OnSceneLoadDone(NetworkRunner runner)
    {

    }

    void INetworkRunnerCallbacks.OnSceneLoadStart(NetworkRunner runner)
    {

    }

    void INetworkRunnerCallbacks.OnSessionListUpdated(NetworkRunner runner, List<SessionInfo> sessionList)
    {

    }

    void INetworkRunnerCallbacks.OnShutdown(NetworkRunner runner, ShutdownReason shutdownReason)
    {

    }

    void INetworkRunnerCallbacks.OnUserSimulationMessage(NetworkRunner runner, SimulationMessagePtr message)
    {

    }

    #endregion

}

public struct RigState : INetworkInput
{
    public Vector3 PlayerPosition;
    public Quaternion PlayerRotation;

    public PosInfo Head;
    public PosInfo UpperChest;
    public PosInfo Chest;
    public PosInfo Spine;
    public PosInfo Hips;
    public Arm LeftArm;
    public Arm RightArm;

    public RigState(int n = 0)
    {
        Head = default;
        PlayerPosition = default;
        PlayerRotation = default;
        UpperChest = default;
        Chest = default;
        Spine = default;
        Hips = default;
        LeftArm = default;
        RightArm = default;
    }
}

public struct Arm
{
    public PosInfo Clavicle;
    public PosInfo UpperArm;
    public PosInfo Forearm;
    public Hand Hand;
}

public struct Hand
{
    public PosInfo Wrist;
    public Finger Thumb;
    public Finger Index;
    public Finger Middle;
    public Finger Ring;
    public Finger Little;
}


public struct Finger
{
    public PosInfo Metacarpal;
    public PosInfo Proximal;
    public PosInfo Intermediate;
    public PosInfo Distal;
}

public struct PosInfo
{
    public Vector3 Pos;
    public Quaternion Rot;

    public void Set(Vector3 pos, Quaternion rot)
    {
        Pos = pos;
        Rot = rot;
    }
}