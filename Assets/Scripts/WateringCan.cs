using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WateringCan : MonoBehaviour
{
    private ParticleSystem waterParticles;
    private MeshRenderer waterRenderer;
    public GameObject wateringTriggerArea;

    public bool isWatering = false;
    private float wateringTimer = 0;

    void Start()
    {
        waterParticles = transform.GetChild(1).GetComponent<ParticleSystem>();
        waterRenderer = transform.GetChild(0).GetComponent<MeshRenderer>();
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0)) // on LMB click
        {
            if (PickUpObject.itemCurrentlyPickedUp == gameObject) // if the watering can is in player hand
            {
                if (waterRenderer.enabled == true) // if the watering can has water in
                {
                    waterParticles.Play();
                    waterRenderer.enabled = false;
                    isWatering = true;
                }
            }
        }

        if (isWatering == true)
        {
            wateringTimer += Time.deltaTime;

            if (wateringTimer > 4.5f) //after 4.5 seconds, set is watering to false
            {
                wateringTimer = 0;
                isWatering = false;
                wateringTriggerArea.GetComponent<WateringTriggerArea>().slurpSoundPlaying = false;
            }
        }
    }
}
