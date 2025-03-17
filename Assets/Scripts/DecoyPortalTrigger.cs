using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*SCRIPT FOR DECOY PORTALS IN LEVEL3 --
    They bring u back to the beginning of the level.
    Player does not lose anything just a set back.
*/
public class DecoyPortalTrigger : MonoBehaviour
{
     private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) 
        {
            PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.Respawn(); 
            }
        }
    }
}
