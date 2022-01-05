using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraManager : MonoBehaviour
{
    public static CameraManager instance;

    [SerializeField]
    CinemachineVirtualCamera mainCam_Normal;
    [SerializeField]
    CinemachineVirtualCamera mainCam_Aim;


    private void Awake()
    {
        if (instance != null)
            Destroy(instance);
        else
         instance = this;
    }
   public void ChangeMainCamPriority(bool value)
    {
        mainCam_Normal.gameObject.SetActive(!value);
        mainCam_Aim.gameObject.SetActive(value);
    }
}
