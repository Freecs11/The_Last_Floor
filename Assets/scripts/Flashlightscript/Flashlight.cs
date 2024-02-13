using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Flashlight : MonoBehaviour
{

    public AudioSource flashOn;
    public AudioSource flashOff; 

    public Light light;
    public TMP_Text lifetimeText;
    public TMP_Text batteryText;
    public GameObject imgflashoff;
    public GameObject imgflashon;

    public float lifetime = 100;
    public float numberOfBatteries = 0;

    private bool on;
    private bool off;

    void Start()
    {
        light = GetComponent<Light>();
        off = true;
        light.enabled = false;
          imgflashoff.SetActive(true);
    }


    void Update()
    {
        lifetimeText.text = lifetime.ToString("0") + "%";
        batteryText.text = numberOfBatteries.ToString();

        if(Input.GetKeyDown(KeyCode.F) && off)
        {
            flashOn.Play();
            light.enabled = true;
            on = true;
            off = false;
          imgflashoff.SetActive(false);
            imgflashon.SetActive(true);
        
        }

        else if (Input.GetKeyDown(KeyCode.F) && on)
        {
            flashOff.Play();
            light.enabled = false;
            on = false;
            off = true;
            imgflashoff.SetActive(true);
            imgflashon.SetActive(false);
        }

        if (on)
        {
            lifetime -= Time.deltaTime * 1;
        }

        if(lifetime <= 0)
        {
            light.enabled = false;
            on = false;
            off = true;
            lifetime = 0;
        }

        if (lifetime >= 100)
        {
            lifetime = 100;
        }

        if (Input.GetKeyDown(KeyCode.R) && numberOfBatteries >= 1)
        {
            numberOfBatteries -= 1;
            lifetime += 50;
        }

        if (Input.GetKeyDown(KeyCode.R) && numberOfBatteries == 0)
        {
            return;
        }

        if(numberOfBatteries <= 0)
        {
            numberOfBatteries = 0;
        }



    }

}