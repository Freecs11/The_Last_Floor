using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class passcodeDoor : MonoBehaviour
{
    string Code;
    string Nr = null;
    int NrIndex = 0;
    string alpha;
    public TextMeshProUGUI UiText = null;
    public GameObject door;
    public static bool CodeOK = false;
    private GameObject player;
    public float maxDistance = 2f;
    public GameObject activator;

    public void CodeFunction(string Numbers)
    {
        NrIndex++;
        Nr = Nr + Numbers;
        UiText.text = Nr;
    }

    public void Enter()
    {
        if (Nr == Code)
        {
            Debug.Log("Correct Code");
            // Ouvrir la porte
            door.SetActive(false);
            gameObject.SetActive(false);
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            CodeOK = true;
            //SceneManager.LoadScene(1);
        }
        else
        {
            Debug.Log("Wrong Code");
            Nr = null;
            UiText.text = Nr;
        }
    }

    public void Delete()
    {
        NrIndex++;
        Nr = null;
        UiText.text = Nr;
    }

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        gameObject.SetActive(false);
        Code = randomizeHints.finalCode;
        Debug.Log(Code);
    }

    private void Update()
    {
        Debug.Log(Vector3.Distance(activator.transform.position, player.transform.position));
        if (Vector3.Distance(activator.transform.position, player.transform.position) < maxDistance)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                gameObject.SetActive(false);
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            }

            bool inCameraView = false;
            Camera cam = Camera.main;
            Vector3 screenPoint = cam.WorldToViewportPoint(activator.transform.position);
            if (screenPoint.z > 0 && screenPoint.x > 0 && screenPoint.x < 1 && screenPoint.y > 0 && screenPoint.y < 1)
            {
                inCameraView = true;
            }
            if (!inCameraView)
            {
                Debug.Log("Out of view");
                gameObject.SetActive(false);
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            }
        }
        else
        {
            Debug.Log("Too far");
            gameObject.SetActive(false);
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }
}
