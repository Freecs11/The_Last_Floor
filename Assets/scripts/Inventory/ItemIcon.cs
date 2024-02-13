using UnityEngine;
using UnityEngine.UI;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;


public class ItemIcon : MonoBehaviour
{
    GameObject player;
    public float maxDistance = 2f;
    public GameObject text;

    public InventoryObject inventory;
    Camera camera;

    private void Start()
    {
        player = GameObject.Find("player");
        camera = Camera.main.GetComponent<Camera>();
        
        SetIconVisibility(false);
    }

    private void Update()
    {
        if (Vector3.Distance(transform.position, player.transform.position) < maxDistance)
        {
            text.transform.rotation = Quaternion.Euler(0, camera.transform.rotation.eulerAngles.y, 0);
            SetIconVisibility(true);
        }
        else
        {
            SetIconVisibility(false);
        }

        if(Input.GetKeyDown(KeyCode.E) && text.activeSelf)
        {
           // make a clone of the parent 
            GameObject clone = Instantiate(transform.parent.gameObject, transform.parent.position, transform.parent.rotation);
            
            clone.name = clone.name.Replace("(Clone)", "");
            clone.GetComponent<Item>().item.model = clone;
          

            // put the clone in a far away place 0, -1000, 0
            clone.transform.position = new Vector3(0, -1000, 0);
            // remove the rigidbody from the clone
            Destroy(clone.GetComponent<Rigidbody>());
            Destroy(clone.GetComponent<RandomClipboardPosition>());
            
            // add the item ( copy ) to the inventory
            inventory.addItem(clone.GetComponent<Item>().item, 1);
            // destroy the object
            Destroy(transform.parent.gameObject);
        }
    }

    private void SetIconVisibility(bool visible)
    {
       
        // if there is no other item blocking the view of the item
        // use raycast to check if there is an item blocking the view 
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit, maxDistance))
        {
            if (hit.transform.gameObject == transform.parent.gameObject)
            {
                text.SetActive(visible);
            }
            else
            {
                text.SetActive(false);
            }
        }
        else
        {
            text.SetActive(false);
        }
    }

    
       
}