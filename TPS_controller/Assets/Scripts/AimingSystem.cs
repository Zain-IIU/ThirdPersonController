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

    float yRot;
    // Start is called before the first frame update
    void Awake()
    {
        mainCam = Camera.main;
    }
    private void Start()
    {
        Cursor.visible = false;
    }

    private void FixedUpdate()
    {
        if(Input.GetKey(KeyCode.Q)==false)
        {
            xAxis.Update(Time.fixedDeltaTime);
            yAxis.Update(Time.fixedDeltaTime);
            cameraLookAt.eulerAngles = new Vector3(yAxis.Value, xAxis.Value, 0f);
            yRot = mainCam.transform.rotation.eulerAngles.y;
         
        }
       
        transform.DORotateQuaternion(Quaternion.Euler(0f, yRot, 0f), turnSpeed);


    }

   
}
