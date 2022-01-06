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
            DOTween.To(() => mainCam_Normal.m_Lens.FieldOfView, x => mainCam_Normal.m_Lens.FieldOfView = x, 25f, 0.15f);
        }
        else
        {
            DOTween.To(() => mainCam_Normal.m_Lens.FieldOfView, x => mainCam_Normal.m_Lens.FieldOfView = x,40f, 0.15f);

        }

    }

  
}
