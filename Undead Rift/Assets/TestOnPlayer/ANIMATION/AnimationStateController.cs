using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationStateController : MonoBehaviour
{
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        bool isRunning = animator.GetBool("IsRunning");
        bool isWalking = animator.GetBool("IsWalking");
        bool forwardPressed = Input.GetKey("w");
        bool runPressed = Input.GetKey("left shift");
        //bool jumpPressed = Input.GetKey("space");
        
        if(!isWalking && forwardPressed)
        {
            animator.SetBool("IsWalking", true);
        }
        if(isWalking && !forwardPressed)
        {
            animator.SetBool("IsWalking", false);
        }
        if(!isRunning && (forwardPressed && runPressed))
        {
            animator.SetBool("IsRunning", true);
        }
        if(isRunning && (!forwardPressed || !runPressed))
        {
            animator.SetBool("IsRunning", false);
        }
        /*if(ShouldJump)
        {
            animator.SetBool("IsJumping", true);
        }
        if(!ShouldJump)
        {
            animator.SetBool("IsJumping", false);
        }*/
    }
}
