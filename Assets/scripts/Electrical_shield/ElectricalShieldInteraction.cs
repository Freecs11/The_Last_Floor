using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectricalShieldInteraction : MonoBehaviour
{
    public Animation electricalShieldAnimation;
    public GameObject mainKnop;
    public Animation mainKnopAnimation;
    public Light[] lights;

    private bool isElectricalShieldOpen = false;
    private bool areLightsOn = true;

    private void Start()
    {
        electricalShieldAnimation = GetComponent<Animation>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (IsPlayerNearby())
            {
                if (!isElectricalShieldOpen)
                {
                    OpenElectricalShield();
                }
                else
                {
                    CloseElectricalShield();
                }
            }

            if (mainKnop != null && mainKnopAnimation != null)
            {
                ToggleLights();
                mainKnopAnimation.Play("animationDesjonct");
            }
        }
    }

  private bool IsPlayerNearby()
{
    float detectionDistance = 2f; // Distance de détection maximale
    RaycastHit hit;

    // Lance un raycast en avant depuis la position du joueur
    if (Physics.Raycast(transform.position, transform.forward, out hit, detectionDistance))
    {
        if (hit.collider.CompareTag("ElectricalShield"))
        {
            return true; // Le joueur est à proximité du bouclier électrique
        }
    }

    return false; // Le joueur n'est pas à proximité du bouclier électrique
}


    private void OpenElectricalShield()
    {
        electricalShieldAnimation.Play("changeCup");
        isElectricalShieldOpen = true;
    }

    private void CloseElectricalShield()
    {
        electricalShieldAnimation.Stop("changeCup");
        isElectricalShieldOpen = false;
    }

    private void ToggleLights()
    {
        areLightsOn = !areLightsOn;

        foreach (Light light in lights)
        {
            light.enabled = areLightsOn;
        }
    }
}



