using UnityEngine;

public class SpeedBoost : PowerUp
{
    public float speedMultiplier = 1.5f;
    public float duration = 5f;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerBoost boost = other.GetComponent<PlayerBoost>();
            if (boost != null)
            {
                boost.ActivateSpeedBoost(speedMultiplier, duration);
            }
            Collect();
            Destroy(gameObject);
        }
    }
}
