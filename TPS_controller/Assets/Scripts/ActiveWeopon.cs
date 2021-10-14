using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations.Rigging;
using UnityEditor.Animations;


public class ActiveWeopon : MonoBehaviour
{
    public static ActiveWeopon instance;
    public RayCastWeopon weopon;
    
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

    public Animator RigController;

   
   
    bool isEquied;
    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
       
        RayCastWeopon curWeopon = GetComponentInChildren<RayCastWeopon>();
        if (curWeopon)
            EquipWeopon(curWeopon);
    }

    // Update is called once per frame
    void Update()
    {
        

        if(weopon)
         {
            bool hostle = Input.GetKeyDown(KeyCode.X);
            RigController.SetBool("Hostle", hostle);

            if (Input.GetMouseButtonDown(0))
            {
                weopon.StartFiring();
            }
            else if (Input.GetMouseButtonUp(0))
            {
                weopon.StopFiring();
            }


        }
       
     }

    public void EquipWeopon(RayCastWeopon newWeopon)
    {
        
        isEquied = true;
        weopon = newWeopon;
        RigController.Play(weopon.Type.ToString());
        Debug.Log(weopon.Type.ToString());
        
    }

  
    
    public bool hasWeopon()
    {
        return isEquied;
    }
  
}
