using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class WeaponRecoil : MonoBehaviour
{
    [HideInInspector]
     public Cinemachine3rdPersonFollow playerCamera;

    [SerializeField]
    float recoilAmount;
    

    public void GenerateRecoil()
    {
        playerCamera.ShoulderOffset.y -= recoilAmount;
    }
    
}
