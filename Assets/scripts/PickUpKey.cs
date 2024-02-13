using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class PickUpKey : MonoBehaviour
{
    public GameObject keyOB;
    public GameObject invOB;
    public GameObject pickUpText;
    public AudioSource keySound;

    public bool inReach;
    private Camera mainCamera; // Référence à la caméra principale

    void Start()
    {
        inReach = false;
        pickUpText.SetActive(false);
        invOB.SetActive(false);
        mainCamera = Camera.main; // Récupérer la caméra principale dans la scène
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Reach")
        {
            inReach = true;
            pickUpText.SetActive(true);
            Debug.Log("Correct Code");
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Reach")
        {
            inReach = false;
            pickUpText.SetActive(false);
            Debug.Log("Correct Code");
        }
    }

    void Update()
    {
        if (inReach && Input.GetKeyDown(KeyCode.E))
        {
            // Lancer un raycast entre le joueur et la clé
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.gameObject == keyOB)
                {
                    keyOB.SetActive(false);
                    keySound.Play();
                    invOB.SetActive(true);
                    pickUpText.SetActive(false);
                }
            }
        }
    }
}
