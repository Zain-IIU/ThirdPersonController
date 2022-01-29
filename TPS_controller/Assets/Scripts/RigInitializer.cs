using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations.Rigging;

public class RigInitializer : MonoBehaviour
{
    [SerializeField]
    RigBuilder rigbuilder;
    [Header("Rig Components")]
    [Header("Body IK")]
    [SerializeField]    MultiAimConstraint spine1_IK;
    [SerializeField]    MultiAimConstraint spine2_IK;
    [SerializeField]    MultiAimConstraint Head_IK;
    [SerializeField]    OverrideTransform bodyRecoil_IK;

    [Header("Weopon Holding IK")]
    [SerializeField]    MultiPositionConstraint pose_IK;
    [SerializeField]    MultiAimConstraint aim_IK;
    [SerializeField]    OverrideTransform recoil_IK;

    [Header("Hands IK")]
    [SerializeField]    TwoBoneIKConstraint rightHand_IK;
    [SerializeField]    TwoBoneIKConstraint leftHand_IK;

    [Header("Bones")]
    [SerializeField]    Transform spine_1;
    [SerializeField]    Transform spine_2;
    [SerializeField]    Transform head_bone;
    [SerializeField]    Transform rightShoulder;
    [Header("left Arm")]
    [SerializeField] Transform root_L;
    [SerializeField] Transform mid_L;
    [SerializeField] Transform tip_L;

    [SerializeField] Transform ref_L;
    [SerializeField] Transform hint_L;

    [Header("Right Arm")]
    [SerializeField] Transform root_R;
    [SerializeField] Transform mid_R;
    [SerializeField] Transform tip_R;

    [SerializeField] Transform ref_R;
    [SerializeField] Transform hint_R;

    [Header("Targets")]
    [SerializeField]    Transform aimTarget;
    [SerializeField]    Transform curWeoponPos;

    private void Awake()
    {
        AddRigComponents();
    }

    [ContextMenu("Add Rig Components")]
    public void AddRigComponents()
    {
        //setting up Body IK
        spine1_IK.data.constrainedObject = spine_1;
         spine1_IK.data.constrainedObject = spine_1;
         spine2_IK.data.constrainedObject = spine_2;
        Head_IK.data.constrainedObject = head_bone;
         bodyRecoil_IK.data.constrainedObject = spine_2;
        bodyRecoil_IK.data.sourceObject = bodyRecoil_IK.gameObject.transform;

        //setting up Weopon IK
        pose_IK.data.constrainedObject = curWeoponPos;
        WeightedTransform newTransform = new WeightedTransform(rightShoulder, 1);

        aim_IK.data.constrainedObject = curWeoponPos;
        recoil_IK.data.constrainedObject = curWeoponPos;
        recoil_IK.data.sourceObject = recoil_IK.gameObject.transform;

       
        aim_IK.data.sourceObjects.Add(new WeightedTransform(aimTarget, 1));

        pose_IK.data.sourceObjects.Add(newTransform);

        //setting up Hand_Ik
        rightHand_IK.data.root = root_R;
        rightHand_IK.data.mid = mid_R;
        rightHand_IK.data.tip = tip_R;
        rightHand_IK.data.target = ref_R;
        rightHand_IK.data.hint = hint_R;

        leftHand_IK.data.root = root_L;
        leftHand_IK.data.mid = mid_L;
        leftHand_IK.data.tip = tip_L;
        leftHand_IK.data.target = ref_L;
        leftHand_IK.data.hint = hint_L;


        rigbuilder.Build();
        Debug.Log("Transforms Added");
    }
}
