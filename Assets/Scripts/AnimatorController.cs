using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorController : MonoBehaviour
{
    public Animator animator;
    private CharacterMovement characterMovement;
    private Rigidbody rb;
    //private AudioSource audioSource;

    public void Start()
    {
        animator = GetComponent<Animator>();
        characterMovement = GetComponent<CharacterMovement>();
        rb = GetComponent<Rigidbody>();
        //audioSource = GetComponent<AudioSource>();
    }

    public void LateUpdate()
    {
        UpdateAnimator();
    }

    void UpdateAnimator()
    {
        animator.SetFloat("CharacterSpeed", rb.velocity.magnitude);
        animator.SetBool("IsGrounded", characterMovement.IsGrounded);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (characterMovement.IsGrounded)
            {
                animator.SetTrigger("Jump");
            }
            else
            {
                animator.SetTrigger("FlipTrigger");
            }
        }
    }

}
