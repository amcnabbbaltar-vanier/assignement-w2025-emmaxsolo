using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private PlayerHealth playerHealth;

    void Start()
    {
        playerHealth = GetComponent<PlayerHealth>();
    }

    public void GotHit()
    {
        if (playerHealth != null)
        {
            playerHealth.TakeDamage(1);
        }
    }
}