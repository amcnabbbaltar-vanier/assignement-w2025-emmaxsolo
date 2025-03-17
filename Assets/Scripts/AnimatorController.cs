using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorController : MonoBehaviour
{
    public Animator animator;
    private CharacterMovement characterMovement;
    private Rigidbody rb;
    private PlayerBoost playerBoost;
    public ParticleSystem flipEffect;


    public void Start()
    {
        animator = GetComponent<Animator>();
        characterMovement = GetComponent<CharacterMovement>();
        rb = GetComponent<Rigidbody>();
        playerBoost = GetComponent<PlayerBoost>();

    }

    public void LateUpdate()
    {
        UpdateAnimator();
    }

    void UpdateAnimator()
    {
        bool isRunning = Input.GetButton("Run"); 
        animator.SetBool("IsRunning", isRunning);

        float walk = 2.5f; 
        float run = 5f;   
        float moveSpeed = rb.velocity.magnitude; 

        if (isRunning)
        {
            animator.SetFloat("CharacterSpeed", run); 
        }
        else 
        {
            animator.SetFloat("CharacterSpeed", Mathf.Min(moveSpeed, walk));
        }

        animator.SetBool("IsGrounded", characterMovement.IsGrounded);

        if (playerBoost != null)
        {
            animator.speed = characterMovement.speedMultiplier;
        }
        else
        {
            animator.speed = 1.0f;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (characterMovement.IsGrounded)
            {
                animator.SetTrigger("Jump");
            }
            else
            {
                if (playerBoost != null && playerBoost.CanDoubleJump())
                {
                    animator.SetTrigger("FlipTrigger");
                    flipEffect.Play();
                    rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);
                    rb.AddForce(Vector3.up * 5f, ForceMode.Impulse);
                }
            }
        }
    }
}



