using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationHandler : MonoBehaviour
{

    private Animator Anim;
    private bool startAnimating;
    
    private void Awake()
    {
        Anim = GetComponent<Animator>();
    }
    private void Start()
    {
        //Cursor.lockState = CursorLockMode.Locked;
        GameManager.instance.onGameStarted += startAnimator;
    }

    private void startAnimator()
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
            Anim.SetFloat("Vertical", Y);
            Anim.SetFloat("Horizontal", X);
            Anim.SetBool("run", Input.GetButton("Run"));
            Anim.SetBool("isEquiped", ActiveWeopon.instance.hasWeopon());
        }
        
    }

 
}
