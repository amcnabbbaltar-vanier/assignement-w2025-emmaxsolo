using UnityEngine;

public class PlayerBoost : MonoBehaviour
{
    private CharacterController controller; 
    private float defaultSpeed = 5f; 
    private float boostedSpeed;
    private bool canDoubleJump = false;
    private float speedBoostEndTime = 0f;
    private float doubleJumpEndTime = 0f;
    void Start()
    {
        controller = GetComponent<CharacterController>();
        boostedSpeed = defaultSpeed;
    }

    void Update()
    {
        if (Time.time >= speedBoostEndTime && boostedSpeed != defaultSpeed)
        {
            boostedSpeed = defaultSpeed; 
            
           // Debug.Log("Speed boost ended. Speed reset to normal.");

            CharacterMovement characterMovement = GetComponent<CharacterMovement>();
            if (characterMovement != null)
            {
                characterMovement.speedMultiplier = 1.0f; 
            }

            AnimatorController animatorController = GetComponent<AnimatorController>();
            if (animatorController != null)
            {
                animatorController.animator.SetFloat("CharacterSpeed", defaultSpeed); 
                Debug.Log("Animator Speed Reset: " + defaultSpeed);
            }
        }

        if (Time.time >= doubleJumpEndTime)
        {
            canDoubleJump = false;
        }
    }


    public void ActivateSpeedBoost(float multiplier, float duration)
    {
        boostedSpeed = defaultSpeed * multiplier;
        speedBoostEndTime = Time.time + duration;

        CharacterMovement characterMovement = GetComponent<CharacterMovement>();
        if (characterMovement != null)
        {
            characterMovement.speedMultiplier = multiplier; 
        }
    }


    public void EnableDoubleJump(float duration)
    {
        canDoubleJump = true;
        doubleJumpEndTime = Time.time + duration;

        AnimatorController animatorController = GetComponent<AnimatorController>();
        if (animatorController != null)
        {
            animatorController.animator.SetTrigger("FlipTrigger"); 
        }
    }


    public float GetCurrentSpeed()
    {
        return boostedSpeed;
    }

    public bool CanDoubleJump()
    {
        return canDoubleJump;
    }
}
