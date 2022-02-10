using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationHandler : MonoBehaviour
{

    private Animator anim;
    private bool startAnimating;

    
    private void Start()
    {
        anim = GetComponent<Animator>();
      
        GameManager.instance.onGameStarted += StartAnimator;
    }

    private void StartAnimator()
    {
        startAnimating = true;
    }
    // Update is called once per frame
    void Update()
    {
        float X = Input.GetAxis("Horizontal");
        float Y = Input.GetAxis("Vertical");
        SetTransition(X, Y);
        
    }
    
    void SetTransition(float X,float Y)
    {
        if(startAnimating)
        {
            anim.SetFloat("Vertical", Y);
            anim.SetFloat("Horizontal", X);
            anim.SetBool("run", Input.GetButton("Run"));
            anim.SetBool("isEquiped", ActiveWeopon.instance.hasWeopon());
        }
        
    }

 
}
