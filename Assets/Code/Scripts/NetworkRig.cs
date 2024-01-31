using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fusion;
using UltimateXR.Avatar;
using UltimateXR.Avatar.Rig;
using UltimateXR.Extensions.Unity;

public class NetworkRig : NetworkBehaviour
{
    public bool IsLocalNetworkRig => Object.HasStateAuthority;

    [Header("RigComponents")]
    [SerializeField]
    private NetworkTransform playerTransform;

    [SerializeField] private UxrAvatar avatar;
    [SerializeField] private UxrAvatarRig rig;

    private HardwareRig hardwareRig;

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
            playerTransform.transform.SetPositionAndRotation(input.Player.Pos, input.Player.Rot);
            rig.Head.Head.SetPositionAndRotation(input.Head.HeadPos.Pos, input.Head.HeadPos.Rot);
            rig.Head.Head.SetPositionAndRotation(input.Head.Neck.Pos, input.Head.Neck.Rot);
            rig.UpperChest.SetPositionAndRotation(input.UpperChest.Pos, input.UpperChest.Rot);
            rig.Chest.SetPositionAndRotation(input.Chest.Pos, input.Chest.Rot);
            rig.Hips.SetPositionAndRotation(input.Hips.Pos, input.Hips.Rot);
            rig.Spine.SetPositionAndRotation(input.Spine.Pos, input.Spine.Rot);
            SetArm(input.LeftArm, rig.LeftArm);
            SetArm(input.RightArm, rig.RightArm);
        }
    }

    private void SetArm(Arm arm, UxrAvatarArm avatarArm)
    {
        avatarArm.Clavicle.SetPositionAndRotation(arm.Clavicle.Pos, arm.Clavicle.Rot);
        avatarArm.Forearm.SetPositionAndRotation(arm.Forearm.Pos, arm.Forearm.Rot);
        avatarArm.UpperArm.SetPositionAndRotation(arm.UpperArm.Pos, arm.UpperArm.Rot);
        SetHand(arm.Hand, avatarArm.Hand);
    }

    private void SetHand(Hand hand, UxrAvatarHand avatarHand)
    {
        avatarHand.Wrist.SetPositionAndRotation(hand.Wrist.Pos, hand.Wrist.Rot);
        SetFingers(hand.Thumb, avatarHand.Thumb);
        SetFingers(hand.Index, avatarHand.Index);
        SetFingers(hand.Middle, avatarHand.Middle);
        SetFingers(hand.Ring, avatarHand.Ring);
        SetFingers(hand.Little, avatarHand.Little);
    }

    private void SetFingers(Finger finger, UxrAvatarFinger avatarFinger)
    {
        if(avatarFinger.Distal != null) 
            avatarFinger.Distal.SetPositionAndRotation(finger.Distal.Pos, finger.Distal.Rot);
        if(avatarFinger.Intermediate != null)
            avatarFinger.Intermediate.SetPositionAndRotation(finger.Intermediate.Pos, finger.Intermediate.Rot);
        if(avatarFinger.Metacarpal != null)
            avatarFinger.Metacarpal.SetPositionAndRotation(finger.Metacarpal.Pos, finger.Metacarpal.Rot);
        if(avatarFinger.Proximal != null)
            avatarFinger.Proximal.SetPositionAndRotation(finger.Proximal.Pos, finger.Proximal.Rot);
    }

    public override void Render()
    {
        base.Render();
        if (IsLocalNetworkRig)
        {
            UxrAvatarRig rigLocal = hardwareRig.avatar.AvatarRig;
            playerTransform.transform.SetPositionAndRotation(hardwareRig.playerTransform.position,
                hardwareRig.playerTransform.rotation);
            //head
            SetPos(rig.Head.Head, rigLocal.Head.Head);
            SetPos(rig.Head.Neck, rigLocal.Head.Neck);
            SetPos(rig.Head.LeftEye, rigLocal.Head.LeftEye);
            SetPos(rig.Head.RightEye, rigLocal.Head.RightEye);

            //Chest
            SetPos(rig.UpperChest, rigLocal.UpperChest);
            SetPos(rig.Chest, rigLocal.Chest);
            SetPos(rig.Hips, rigLocal.Hips);
            SetPos(rig.Spine, rigLocal.Spine);
            
            //Arms
            SetArm(rig.LeftArm, rigLocal.LeftArm);
            SetArm(rig.RightArm, rigLocal.RightArm);
        }
    }
    
    private void SetArm(UxrAvatarArm arm, UxrAvatarArm avatarArm)
    {
        SetPos(arm.Clavicle, avatarArm.Clavicle);
        SetPos(arm.Forearm, avatarArm.Forearm);
        SetPos(arm.UpperArm, avatarArm.UpperArm);
        SetHand(arm.Hand, avatarArm.Hand);
    }

    private void SetHand(UxrAvatarHand hand, UxrAvatarHand avatarHand)
    {
        SetPos(hand.Wrist, avatarHand.Wrist);
        SetFingers(hand.Thumb, avatarHand.Thumb);
        SetFingers(hand.Index, avatarHand.Index);
        SetFingers(hand.Middle, avatarHand.Middle);
        SetFingers(hand.Ring, avatarHand.Ring);
        SetFingers(hand.Little, avatarHand.Little);
    }

    private void SetFingers(UxrAvatarFinger finger, UxrAvatarFinger avatarFinger)
    {
        SetPos(finger.Distal, avatarFinger.Distal);
        SetPos(finger.Intermediate, avatarFinger.Intermediate);
        SetPos(finger.Metacarpal, avatarFinger.Metacarpal);
        SetPos(finger.Proximal, avatarFinger.Proximal);
    }
    
    private void SetPos(Transform set, Transform get)
    {
        if (get == null || set == null)
            return;
        set.SetPositionAndRotation(get.position, get.rotation);
    }
}
