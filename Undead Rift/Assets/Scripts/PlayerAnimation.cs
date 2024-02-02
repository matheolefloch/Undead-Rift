using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
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
        bool isWalking = animator.GetBool("isWalking");
        bool forwardPressed = Input.GetKey("q");
        
        if(!isWalking && forwardPressed)
        {
            animator.SetBool("isWalking", true);
        }
        if(isWalking && !forwardPressed)
        {
            animator.SetBool("isWalking", false);
        }
    }
}
