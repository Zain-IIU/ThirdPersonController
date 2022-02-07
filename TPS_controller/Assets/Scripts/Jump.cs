using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.Events;
public class Jump : MonoBehaviour
{
    [SerializeField]
    Transform groundPos;
    [SerializeField]
    private float jumpPower;
    [SerializeField]
    LayerMask groundLayer;
    [SerializeField]
    float groundDistanceCheck;

    Rigidbody RB;

    bool isGrounded;

    Animator Anim;

    // Start is called before the first frame update
    void Start()
    {
        RB = GetComponent<Rigidbody>();
        Anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundPos.position, groundDistanceCheck, groundLayer);
        AnimateforJump(isGrounded);
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
            DOJump();
        
    }

    private void DOJump()
    {
        RB.AddForce(Vector3.up * jumpPower);
        Debug.Log("Player Jumped");
    }
    private void AnimateforJump(bool isTrue)
    {
        Anim.SetBool("inAir", !isTrue);
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(groundPos.position, groundDistanceCheck);
    }
}
