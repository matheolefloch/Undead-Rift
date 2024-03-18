using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationStateController : MonoBehaviour
{
    CharacterController characterController;
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        characterController = GetComponentInParent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        bool isRunning = animator.GetBool("IsRunning");
        bool isWalking = animator.GetBool("IsWalking");
        bool isJumping = animator.GetBool("IsJumping");
        bool forwardPressed = Input.GetKey("w");
        bool runPressed = Input.GetKey("left shift");
        bool jumpPressed = Input.GetKey("space");
        
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
        if(jumpPressed && characterController.isGrounded)
        {
            animator.SetBool("IsJumping", true);
        }
        if(!jumpPressed && characterController.isGrounded)
        {
            animator.SetBool("IsJumping", false);
        }
        
    }
}
