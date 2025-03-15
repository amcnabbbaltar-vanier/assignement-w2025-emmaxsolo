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
        // Check if speed boost should end
        if (Time.time >= speedBoostEndTime && boostedSpeed != defaultSpeed)
        {
            boostedSpeed = defaultSpeed; // Reset to normal speed
            
            // Log for debugging
            Debug.Log("Speed boost ended. Speed reset to normal.");
            
            // Optionally, reset the multiplier in CharacterMovement to 1 if you're using a multiplier
            CharacterMovement characterMovement = GetComponent<CharacterMovement>();
            if (characterMovement != null)
            {
                characterMovement.speedMultiplier = 1.0f; // Reset multiplier to 1 when speed boost ends
            }

            // Update the animator to reflect normal speed after boost ends
            AnimatorController animatorController = GetComponent<AnimatorController>();
            if (animatorController != null)
            {
                animatorController.animator.SetFloat("CharacterSpeed", defaultSpeed); // Set speed back to normal
                Debug.Log("Animator Speed Reset: " + defaultSpeed);
            }
        }

        // Check if double jump should end
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
