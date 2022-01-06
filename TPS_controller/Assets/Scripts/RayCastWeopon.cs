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

    bool hasShot;
    [SerializeField]
    float delayBWshots;

    #endregion


    void Awake()
    {
        raycastDestination = GameObject.FindObjectOfType<CrossHairTarget>().transform;
    }

    private void Update()
    {
        Shoot();
        AimWeopon();
    }

    private void Shoot()
    {
        if (isSingleShot)
        {
            if (Input.GetMouseButtonDown(0))
            {
                StartFiring();
            }

        }
        else if (!isSingleShot)
        {
            if (Input.GetMouseButton(0) && !hasShot)
            {
                StartFiring();
                hasShot = true;
                StartCoroutine(nameof(waitforRecoil));

            }
        }
        else if (Input.GetMouseButtonUp(0))
        {
            StopFiring();
        }
    }
    IEnumerator waitforRecoil()
    {
        yield return new WaitForSeconds(delayBWshots);
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
    private void AimWeopon()
    {
        if (Input.GetMouseButton(1))
        {
            CameraManager.instance.ChangeMainCamPriority(true);
        }
        else if (Input.GetMouseButtonUp(1))
        {
            CameraManager.instance.ChangeMainCamPriority(false);
        }
    }


}
