using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
public class Passcode : MonoBehaviour
{
    string Code ;
    string Nr = null;
    int NrIndex = 0;
    string alpha;
    public TextMeshProUGUI UiText =null ;
    public GameObject barrier;
    public static bool CodeOK=false;
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
            // barrier set active to false
            barrier.gameObject.SetActive(false);
            gameObject.SetActive(false);
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            CodeOK=true;
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

    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    
    Camera cam;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        gameObject.SetActive(false);
        Code = randomizeHints.finalCode;
        Debug.Log(Code);
        cam = Camera.main.GetComponent<Camera>();   
        }

    
    private void Update() {
        Debug.Log(Vector3.Distance(activator.transform.position, player.transform.position));
        if (Vector3.Distance(activator.transform.position, player.transform.position) < maxDistance)
        {
            
            if(Input.GetKeyDown(KeyCode.E)){
                        gameObject.SetActive(false);
                        Cursor.lockState = CursorLockMode.Locked;
                        Cursor.visible = false;
            }
            
            bool inCameraView = false;
            Vector3 screenPoint = cam.WorldToViewportPoint(activator.transform.position);
            if (screenPoint.z > 0 && screenPoint.x > 0 && screenPoint.x < 1 && screenPoint.y > 0 && screenPoint.y < 1)
            {
                inCameraView = true;
            }
            if (!inCameraView)
            {
                Debug.Log("NO i did it ");
                gameObject.SetActive(false);
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            }

        }
        else
        {
            Debug.Log("i did it ");
            gameObject.SetActive(false);
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        
    }

   
}
