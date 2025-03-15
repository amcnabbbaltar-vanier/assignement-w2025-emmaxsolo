using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    private Vector3 startPosition;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        startPosition = transform.position;
    }

    public void TakeDamage(int damage)
    {
        GameManager.Instance.TakeDamage(damage);
    }

    public int GetCurrentHealth()
    {
        return GameManager.Instance.playerHealth;
    }

    public void Respawn()
    {
        transform.position = startPosition;
        rb.velocity = Vector3.zero;
    }
}
