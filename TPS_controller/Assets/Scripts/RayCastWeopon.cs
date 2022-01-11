using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCastWeopon : MonoBehaviour
{
    #region Variables
    [SerializeField]
    bool isFiring = false;
    [SerializeField]
    ParticleSystem particles;
    public WeoponType Type;
    
    public Animator Rig;
    public  AnimationClip pivotingAnimation;

    [SerializeField]
    Transform raycastOrigin;
    [SerializeField]
    Transform raycastDestination;
    [SerializeField]
    ParticleSystem bulletEffect;
    Ray ray;
    RaycastHit hitInfo;

    [SerializeField]
    bool isSingleShot;

    bool isAiming;

    bool hasShot;
    [SerializeField]
    float _Multi;
    [SerializeField]
    float _Single;
    [SerializeField]
    WeaponRecoil recoil;
    #endregion

  
    void Awake()
    {
        raycastDestination = GameObject.FindObjectOfType<CrossHairTarget>().transform;
        recoil = this.gameObject.GetComponent<WeaponRecoil>();
    }

    private void Start()
    {
        EventsManager.instance.onRecoil += RecoilAnimation; 
    }
    private void Update()
    {
        Shoot();
        Aim();
    }

    private void Shoot()
    {
        if(Input.GetKey(KeyCode.Q) == false)
        {
            if (isSingleShot)
            {
                if (Input.GetMouseButtonDown(0) && !hasShot)
                {
                    StartFiring();
                    hasShot = true;
                    StartCoroutine(nameof(waitforNextShot));
                }

            }
            else if (!isSingleShot)
            {
                if (Input.GetMouseButton(0) && !hasShot)
                {
                    StartFiring();
                    hasShot = true;
                    StartCoroutine(nameof(waitforNextShot));

                }
            }
            else if (Input.GetMouseButtonUp(0))
            {
                StopFiring();
            }
        }
       
    }
    IEnumerator waitforNextShot()
    {
        if(!isSingleShot)
         yield return new WaitForSeconds(_Multi);
        else
            yield return new WaitForSeconds(_Single);
        hasShot = false;
    }

    public void StartFiring()
    {
        isFiring = true;
        ray.origin = raycastOrigin.position;
        ray.direction = raycastDestination.position - raycastOrigin.position;
        if(Physics.Raycast(ray, out hitInfo))
        {
            Debug.DrawLine(ray.origin, hitInfo.point, Color.red, 1.0f);
            if(hitInfo.collider && hitInfo.collider.GetComponent<Rigidbody>())
            {
                hitInfo.collider.GetComponent<Rigidbody>().AddForce(ray.direction*100f);
            }
        }
        EventsManager.instance.RecoilEvent(Type.ToString());
        if (isAiming)
            recoil.GenerateRecoil(true);
        else
            recoil.GenerateRecoil();
        particles.Emit(1);
    }

    public void StopFiring()
    {
        isFiring = false;
    }

    public bool getShotType()
    {
        return isSingleShot;
    }

    private void Aim()
    {
        if (Input.GetMouseButton(1))
        {
            isAiming = true;
            CameraManager.instance.ChangeMainCamPriority(true);
        }
        else if (Input.GetMouseButtonUp(1))
        {
            isAiming = false;
            CameraManager.instance.ChangeMainCamPriority(false);
        }
    }

    private void RecoilAnimation(string weoponName)
    {
        Debug.Log("weoponRecoil" + weoponName);
        Rig.Play("weoponRecoil" + weoponName, 1, 0.0f);
    }
  

}
