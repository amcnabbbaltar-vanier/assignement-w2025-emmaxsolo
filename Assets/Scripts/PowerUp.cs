using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public ParticleSystem pickupEffect;
    public float rotationSpeed = 50f;
    public float hoverHeight = 0.2f;
    private Vector3 startPosition;
    private bool isEffectPlaying = false;
    private float effectEndTime;

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        transform.Rotate(0, rotationSpeed * Time.deltaTime, 0);
        transform.position = startPosition + new Vector3(0, Mathf.PingPong(Time.time * 0.5f, hoverHeight), 0);

        if (isEffectPlaying && Time.time >= effectEndTime)
        {
            pickupEffect.Stop();
            isEffectPlaying = false;
        }
    }

    public void Collect()
    {
        pickupEffect.transform.position = transform.position;
        pickupEffect.Play();
        gameObject.SetActive(false); 

        isEffectPlaying = true;
        effectEndTime = Time.time + pickupEffect.main.duration;
    }
}


