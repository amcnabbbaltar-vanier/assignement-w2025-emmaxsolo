using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PortalTrigger : MonoBehaviour
{
     private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.Instance.checkpointScore = GameManager.Instance.playerScore;
            GameManager.Instance.checkpointTime = GameManager.Instance.timePassed;

            // Load next scene
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
