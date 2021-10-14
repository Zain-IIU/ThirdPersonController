using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCastWeopon : MonoBehaviour
{
    [SerializeField]
    bool isFiring = false;
    [SerializeField]
    ParticleSystem[] particles;
    public WeoponType Type;

    public  AnimationClip pivotingAnimation;

    public void StartFiring()
    {
        isFiring = true;
        foreach(var particle in particles)
        {
            particle.Emit(0);
        }
    }
    public void StopFiring()
    {
        isFiring = false;
    }
    
}
