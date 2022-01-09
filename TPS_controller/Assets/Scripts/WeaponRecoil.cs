using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class WeaponRecoil : MonoBehaviour
{
    [HideInInspector]
     public AimingSystem playerCamera;
    [HideInInspector]
    public CinemachineImpulseSource cameraShake;
   
    [SerializeField]
    float recoilDuration;

    float curTime;
    [SerializeField]
    float verticalRecoil;    
    [SerializeField]
    float[] horizontalPatterns;
    public bool doShake;

    
    private void Awake()
    {
        cameraShake = GetComponent<CinemachineImpulseSource>();
    }
   

    private void Update()
    {
        if(curTime>0)
        {         
            playerCamera.yAxis.Value -= ((verticalRecoil / 10) * Time.deltaTime) / recoilDuration;
            playerCamera.xAxis.Value -= ((horizontalPatterns[Random.Range(0, horizontalPatterns.Length)] / 10) * Time.deltaTime) / recoilDuration;
            curTime -= Time.deltaTime;
        }
    }

    public void GenerateRecoil()
    {
          curTime = recoilDuration;
        if(doShake)
            cameraShake.GenerateImpulse(Camera.main.transform.forward);
    }
    public void GenerateRecoil(bool isAim)
    {
        verticalRecoil /= 2;

        curTime = recoilDuration;
        if (doShake)
            cameraShake.GenerateImpulse(Camera.main.transform.forward);
    }

}
