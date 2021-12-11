using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCastWeopon : MonoBehaviour
{
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
    void Awake()
    {
        raycastDestination = GameObject.FindObjectOfType<CrossHairTarget>().transform;
    }
    public void StartFiring()
    {
        isFiring = true;
        ray.origin = raycastOrigin.position;
        ray.direction = raycastDestination.position - raycastOrigin.position;
        if(Physics.Raycast(ray, out hitInfo))
        {
            //bulletEffect.transform.position = hitInfo.point;
            //bulletEffect.transform.forward = hitInfo.normal;
            //bulletEffect.Emit(1);
            Debug.DrawLine(ray.origin, hitInfo.point, Color.red, 1.0f);
        }

        particles.Emit(1);
    }
    public void StopFiring()
    {
        isFiring = false;
    }
    
}
