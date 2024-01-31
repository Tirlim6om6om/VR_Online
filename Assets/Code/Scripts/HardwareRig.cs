using System;
using System.Collections;
using System.Collections.Generic;
using Fusion;
using Fusion.Sockets;
using UltimateXR.Avatar;
using UltimateXR.Avatar.Rig;
using UnityEngine;

namespace Code.Scripts
{
    public class HardwareRig : MonoBehaviour, INetworkRunnerCallbacks
    {
        public static HardwareRig Instance;
        public Transform playerTransform;
        public UxrAvatar avatar;

        
        private void Awake()
        {
            if (Instance)
            {
                Destroy(this);
            }
            else
            {
                Instance = this;
            }
        }

        void Start()
        {
            NetworkManager.Instance.Runner.AddCallbacks(this);
        }

        #region INetworkRunnerCallbacks

        void INetworkRunnerCallbacks.OnInput(NetworkRunner runner, NetworkInput input)
        {
            RigState xrRigState = new RigState();
            UxrAvatarRig rig = avatar.AvatarRig;
        
            xrRigState.Player = new PosInfo(playerTransform.position, playerTransform.rotation);
            xrRigState.UpperChest = new PosInfo(rig.UpperChest.position, rig.UpperChest.rotation);
            xrRigState.Chest = new PosInfo(rig.Chest.position, rig.Chest.rotation);
            xrRigState.Spine = new PosInfo(rig.Spine.position, rig.Spine.rotation);
            xrRigState.Hips = new PosInfo(rig.Hips.position, rig.Hips.rotation);
            xrRigState.LeftArm = CreateArm(rig.LeftArm);
            xrRigState.RightArm = CreateArm(rig.RightArm);

            xrRigState.Head = new Head();
            xrRigState.Head.HeadPos = new PosInfo(rig.Head.Head.position, rig.Head.Head.rotation);
            xrRigState.Head.Neck = new PosInfo(rig.Head.Neck.position, rig.Head.Neck.rotation);
        
            input.Set(xrRigState);
        
        }
        #endregion

        private Arm CreateArm(UxrAvatarArm avatarArm)
        {
            Arm arm = new Arm();
            arm.Clavicle = new PosInfo(avatarArm.Clavicle.position, avatarArm.Clavicle.rotation);
            arm.UpperArm = new PosInfo(avatarArm.UpperArm.position, avatarArm.UpperArm.rotation);
            arm.Forearm = new PosInfo(avatarArm.Forearm.position, avatarArm.Forearm.rotation);
            arm.Hand = CreateHand(avatarArm.Hand);
            return arm;
        }

        private Hand CreateHand(UxrAvatarHand avatarHand)
        {
            Hand hand = new Hand();
        
            hand.Wrist = new PosInfo(avatarHand.Wrist.position, avatarHand.Wrist.rotation);
            hand.Thumb = CreateFinger(avatarHand.Thumb);
            hand.Index = CreateFinger(avatarHand.Index);
            hand.Middle = CreateFinger(avatarHand.Middle);
            hand.Ring = CreateFinger(avatarHand.Ring);
            hand.Little = CreateFinger(avatarHand.Little);

            return hand;
        }

        private Finger CreateFinger(UxrAvatarFinger avatarFinger)
        {
            Finger finger = new Finger();
            if(avatarFinger.Intermediate != null)
                finger.Intermediate = new PosInfo(avatarFinger.Intermediate.position, avatarFinger.Intermediate.rotation);
        
            if(avatarFinger.Metacarpal != null)
                finger.Metacarpal = new PosInfo(avatarFinger.Metacarpal.position, avatarFinger.Metacarpal.rotation);
        
            if(avatarFinger.Proximal != null)
                finger.Proximal = new PosInfo(avatarFinger.Proximal.position, avatarFinger.Proximal.rotation);
        
            if(avatarFinger.Distal != null)
                finger.Distal = new PosInfo(avatarFinger.Distal.position, avatarFinger.Distal.rotation);
            return finger;
        }

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
        public PosInfo Player;
        public Head Head;
        public PosInfo UpperChest;
        public PosInfo Chest;
        public PosInfo Spine;
        public PosInfo Hips;
        public Arm LeftArm;
        public Arm RightArm;
    }

    public struct Head : INetworkInput
    {
        public PosInfo HeadPos;
        public PosInfo Neck;
    }

    public struct Arm : INetworkInput
    {
        public PosInfo Clavicle;
        public PosInfo UpperArm;
        public PosInfo Forearm;
        public Hand Hand;
    }

    public struct Hand : INetworkInput
    {
        public PosInfo Wrist;
        public Finger Thumb;
        public Finger Index;
        public Finger Middle;
        public Finger Ring;
        public Finger Little;
    }


    public struct Finger : INetworkInput
    {
        public PosInfo Metacarpal;
        public PosInfo Proximal;
        public PosInfo Intermediate;
        public PosInfo Distal;
    }

    public struct PosInfo : INetworkInput
    {
        public Vector3 Pos;
        public Quaternion Rot;

        public PosInfo(Vector3 pos, Quaternion rot)
        {
            Pos = pos;
            Rot = rot;
        }
    }
}