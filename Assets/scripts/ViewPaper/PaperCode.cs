using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class PaperCode : MonoBehaviour
{
    public GameObject noteUI;
    public GameObject pickUpText;
    public AudioSource pickUpSound;
    public bool inReach;

    void Start()
    {
        noteUI.SetActive(false);
        pickUpText.SetActive(false);
        inReach = false;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            inReach = true;
            pickUpText.SetActive(true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            inReach = false;
            pickUpText.SetActive(false);
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A) && inReach)
        {
            noteUI.SetActive(true);
            pickUpSound.Play();
           
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
    }

    public void ExitButton()
    {
        noteUI.SetActive(false);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
}
