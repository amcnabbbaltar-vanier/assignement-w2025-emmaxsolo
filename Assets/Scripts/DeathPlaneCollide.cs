using UnityEngine;

public class DeathPlaneCollide : MonoBehaviour
{
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Player"))
        {
            PlayerHealth health = collider.GetComponent<PlayerHealth>();
            if (health != null)
            {
                Debug.Log("Player fell into DeathPlane! Losing 1 HP...");
                health.TakeDamage(1);
                if (GameManager.Instance.playerHealth > 0)
                {
                    health.Respawn();
                }
                else
                {
                    Debug.Log("No health left, restarting level...");
                    GameManager.Instance.RestartLevel();
                }
            }
        }
    }
}
