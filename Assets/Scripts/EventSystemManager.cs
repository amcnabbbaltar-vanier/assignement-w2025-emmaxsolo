using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class EventSystemManager : MonoBehaviour
{
    private void Awake()
    {
        EventSystem[] eventSystems = FindObjectsOfType<EventSystem>();

        if (eventSystems.Length > 1)
        {
            // Keep only one, destroy the extras
            for (int i = 1; i < eventSystems.Length; i++)
            {
                Destroy(eventSystems[i].gameObject);
            }
        }

    }
}
