using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class firstFloorCheckPoint : MonoBehaviour
{
    public GameObject TimerFloor1;
    public GameObject TimerFloor2;
    public GameObject Barrier;

    private void Start() {
        TimerFloor1.SetActive(true);
        TimerFloor2.SetActive(false);
       //   audioSource = GetComponent<AudioSource>();
    }


    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            TimerFloor1.SetActive(false);
            TimerFloor2.SetActive(true);
            Barrier.SetActive(true);
        }
    }
}
