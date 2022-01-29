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
    float horizontalRecoil;
    [SerializeField]
    float[] horizontalPatterns;


    [SerializeField] bool doShake;

    float curVerticalRecoil;
    
    private void Awake()
    {
        cameraShake = GetComponent<CinemachineImpulseSource>();
    }

    private void Start()
    {
        curVerticalRecoil = verticalRecoil;
    }
    private void Update()
    {
        if(curTime>0)
        {
          
            playerCamera.yAxis.Value -= ((curVerticalRecoil / 10) * Time.deltaTime) / recoilDuration;
            playerCamera.xAxis.Value -= ((horizontalRecoil / 10) * Time.deltaTime) / recoilDuration;
            curTime -= Time.deltaTime;
        }
        else
        {
            curVerticalRecoil = verticalRecoil;
        }
    }

    public void GenerateRecoil()
    {
        curVerticalRecoil = verticalRecoil;
          curTime = recoilDuration;
        if(doShake)
            cameraShake.GenerateImpulse(Camera.main.transform.forward);
    }
    public void GenerateRecoil(bool isAim)
    {
        if(horizontalPatterns.Length>0)
            horizontalRecoil = horizontalPatterns[Random.Range(0, horizontalPatterns.Length)];
        curVerticalRecoil /= 2;
        horizontalRecoil /= 2;
        curTime = recoilDuration;
    }

}
