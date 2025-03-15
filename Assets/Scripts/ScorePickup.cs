using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScorePickup : PowerUp
{
    public int scoreAmount = 50;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Collision detected with: " + other.name);
            GameManager.Instance.AddScore(scoreAmount);
            Collect();
            Destroy(gameObject);
        }
    }
}


