using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class player : MonoBehaviour
{
    public InventoryObject inventory;
    public Canvas inventoryCanvas;
    private bool isInventoryOpen = false; 
    private bool shouldResetYPosition = false; 

    public GameObject pauseCanvas;
   public GameObject ReadnoteCanvas;
   public GameObject ReadnoteCanvas2;
    public GameObject ReadnoteCanvas3;
    public GameObject keypad;
    public GameObject keypad2;
    public GameObject keypad3;

    public GameObject flashlight;

    private Camera cam;

    // variable isHiding is used to check if the player is hiding in the locker or not
    public bool isHiding = false;


    private void OnApplicationQuit()
    {
        inventory.Container.Clear();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.G))
        {
            flashlight.gameObject.SetActive(!flashlight.gameObject.activeSelf);
            
        }

        if (Input.GetKeyDown(KeyCode.Tab) && !keypad.activeSelf)
        {
            inventory.Save();
            isInventoryOpen = !isInventoryOpen; 
            inventoryCanvas.gameObject.SetActive(isInventoryOpen);
            if (isInventoryOpen)
            {
                
                Debug.Log("Inventory Opened");
                inventory.Load();
                // cursor visible when inventory is open
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
            else
            {
                
                Debug.Log("Inventory Closed");
                inventory.Save();
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            }
        }
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (!isInventoryOpen && Physics.Raycast(ray, out hit, 2.0f))
        {
            if (hit.collider.gameObject.CompareTag("keypad") && Input.GetKeyDown(KeyCode.E) 
            )
            {
                Debug.Log("E pressed");
                keypad.gameObject.SetActive(true);
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }

            if (hit.collider.gameObject.CompareTag("keypad2") && Input.GetKeyDown(KeyCode.E) 
            )
            {
                Debug.Log("E pressed");
                keypad2.gameObject.SetActive(true);
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }

            if (hit.collider.gameObject.CompareTag("keypad3") && Input.GetKeyDown(KeyCode.E) 
            )
            {
                Debug.Log("E pressed");
                keypad3.gameObject.SetActive(true);
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
        }

        if (Input.GetKeyDown(KeyCode.Escape) && !keypad.activeSelf && !ReadnoteCanvas.activeSelf 
        && !ReadnoteCanvas2.activeSelf && !ReadnoteCanvas3.activeSelf && !keypad2.activeSelf
        && !keypad3.activeSelf)
        {
            // desactive all the canvas 
            inventoryCanvas.gameObject.SetActive(false);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            // desactive the player movement
            Time.timeScale = 0;
            gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
            pauseCanvas.gameObject.SetActive(true);
        }

    }

    public void shakeCamera(){
        StartCoroutine(shakeCameraCoroutine());
    }

    IEnumerator shakeCameraCoroutine(){
        // shake camera abit on hurt
        cam = Camera.main;
        Vector3 originalPos = cam.transform.localPosition;
        float elapsed = 0.0f;
        float duration = 0.3f;
        float magnitude = 0.4f;
        while (elapsed < duration)
        {
            float x = Random.Range(-1f, 1f) * magnitude;
            float y = Random.Range(-1f, 1f) * magnitude;
            cam.transform.localPosition = new Vector3(x, y, originalPos.z);
            elapsed += Time.deltaTime;
            yield return null;
        }
        cam.transform.localPosition = originalPos;

    }
        
        
}
