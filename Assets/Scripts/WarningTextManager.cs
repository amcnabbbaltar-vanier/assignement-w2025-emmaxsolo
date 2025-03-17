using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarningTextManager : MonoBehaviour
{
     public GameObject warningText;  

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Player"))
        {
            warningText.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider collider)
    {
        if (collider.CompareTag("Player"))
        {
            warningText.SetActive(false);
        }
    }
}
