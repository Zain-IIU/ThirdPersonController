using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

using DG.Tweening;

public class CameraManager : MonoBehaviour
{
    public static CameraManager instance;

    [SerializeField]
    Cinemachine.CinemachineVirtualCamera  mainCam_Normal;

    [SerializeField]
    Cinemachine.CinemachineVirtualCamera mainCam_Aim;


    private void Awake()
    {
        if (instance != null)
            Destroy(instance);
        else
         instance = this;
    }
   public void ChangeMainCamPriority(bool flag)
    {
        if (flag)
        {
            mainCam_Aim.m_Priority = 20;
            mainCam_Normal.m_Priority = 10;
        }
        else
        {
            mainCam_Aim.m_Priority = 10;
            mainCam_Normal.m_Priority = 20;

        }

    }

  
}
