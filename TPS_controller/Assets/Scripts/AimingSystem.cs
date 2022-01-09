using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations.Rigging;
using DG.Tweening;
public class AimingSystem : MonoBehaviour
{
    [SerializeField]
    float turnSpeed;
   
    [SerializeField]
    Rig bodyIK;
 
    Camera mainCam;

    [SerializeField]
     public Cinemachine.AxisState xAxis;
    [SerializeField]
    public Cinemachine.AxisState yAxis;


    [SerializeField]
    Transform cameraLookAt;

    bool isAiming = false;
    // Start is called before the first frame update
    void Awake()
    {
        mainCam = Camera.main;
    }
    private void Start()
    {
        GameManager.instance.onGameStarted += StartAiming;
    }

    private void StartAiming()
    {
        isAiming = true;
    }

    private void FixedUpdate()
    {
        if(isAiming)
        {
            xAxis.Update(Time.fixedDeltaTime);
            yAxis.Update(Time.fixedDeltaTime);

            cameraLookAt.eulerAngles = new Vector3(yAxis.Value, xAxis.Value, 0f);
            float yRot = mainCam.transform.rotation.eulerAngles.y;
            transform.DORotateQuaternion(Quaternion.Euler(0f, yRot, 0f), 0.05f);

        }

    }

   
}
