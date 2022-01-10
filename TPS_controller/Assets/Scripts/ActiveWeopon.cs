using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations.Rigging;
//using UnityEditor.Animations;
using Cinemachine;

public class ActiveWeopon : MonoBehaviour
{
    public static ActiveWeopon instance;
    public RayCastWeopon weopon;
    [SerializeField]
    AimingSystem playerCam;
    [Header("Constraints")]
    [SerializeField]
    Transform refLeftHand;
    [SerializeField]
    Transform refRightHand;
   
    [Header("Weopon Positions")]
    [SerializeField]
    Transform weoponParent;
    [SerializeField]
    Transform AssualtPos;
    [SerializeField]
    Transform GunPos;
    
    [SerializeField]
    Transform RocketPos;
    [SerializeField]
    Transform SniperPos;
    [SerializeField]
    Transform ShotGunPos;
    [SerializeField] Cinemachine3rdPersonFollow _camera;
    public Animator RigController;
    bool isEquied;

    private void Awake()
    {
        instance = this;
    }
    
    // Start is called before the first frame update
    void Start()
    {
        playerCam = GetComponent<AimingSystem>();
        RayCastWeopon curWeopon = GetComponentInChildren<RayCastWeopon>();
        if (curWeopon)
            EquipWeopon(curWeopon);
    }

    public void EquipWeopon(RayCastWeopon newWeopon)
    {
        isEquied = true;
        weopon = newWeopon;    
        weopon.GetComponent<WeaponRecoil>().playerCamera = playerCam;
        weopon.Rig = RigController;
        RigController.Play(weopon.Type.ToString());
    }

   
    public bool hasWeopon()
    {
        return isEquied;
    }
  
}
