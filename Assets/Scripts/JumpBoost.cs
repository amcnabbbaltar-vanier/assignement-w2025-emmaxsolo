using UnityEngine;

public class JumpBoost : PowerUp
{
    public float duration = 30f;
    public float jumpMultiplier = 2f;
    private CharacterMovement characterMovement;


      void OnTriggerEnter(Collider collider)
    {
         if (collider.CompareTag("Player"))
        {
            characterMovement = collider.GetComponent<CharacterMovement>();

            if (characterMovement != null)
            {
                characterMovement.SetJumpForce(characterMovement.GetJumpForce() * jumpMultiplier);

                PlayerBoost boost = collider.GetComponent<PlayerBoost>();
                if (boost != null)
                {
                    boost.EnableDoubleJump(duration);
                }
            }
            
            Collect();
            Destroy(gameObject);
        }
    }

    void Update()
    {
         if (Time.time >= duration && characterMovement != null)
        {
            //reset
            characterMovement.SetJumpForce(characterMovement.GetJumpForce() / jumpMultiplier);
        }
    }
}
