using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatteryPickUp : MonoBehaviour
{

    private GameObject flashlight;
    public GameObject batteryText;
    private bool detection;
    public AudioSource batterySound;
    private Camera cam;

    void Start()
    {
        detection = false;
        batteryText.SetActive(false);
        flashlight = GameObject.Find("flashlight");
        cam = Camera.main;
    }


    void Update()
    {
        // camera has crosshair in the middle of the screen so we can use it to detect if we are looking at the battery
        RaycastHit hit;
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, 3))
        {
            if (hit.collider.gameObject == gameObject)
            {
                detection = true;
                batteryText.SetActive(true);
            }
            else
            {
                detection = false;
                batteryText.SetActive(false);
            }
        }
        else
        {
            detection = false;
            batteryText.SetActive(false);
        }
        if (Input.GetKeyDown(KeyCode.E) && detection)
        {
            flashlight.GetComponent<Flashlight>().numberOfBatteries += 1;
            batterySound.Play();
            detection = false;
            batteryText.SetActive(false);
            Destroy(gameObject);
        }

    }
}