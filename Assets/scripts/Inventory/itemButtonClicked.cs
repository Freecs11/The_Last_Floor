using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class itemButtonClicked : MonoBehaviour
{
    GameObject player;
    Button button;
    public InventoryObject inventory;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("player");
        button = GetComponent<Button>();
        button.onClick.AddListener(onItemClicked);
    }

    public void onItemClicked(){
            // get the parent of the button
            string itemName = transform.parent.name;
            // remove (clone) from the name
            itemName = itemName.Replace("(Clone)", "");  
            // we will get the item from the inventory
            var item = inventory.GetItem(itemName);

            // we will remove the item from the inventory 
            inventory.removeItem(item, 1);
            GameObject obj = GameObject.Find(itemName);
            GameObject instObj = Instantiate(obj, player.transform.position, player.transform.rotation);

            Destroy(obj);
            // put the item in the world in front of the player
            instObj.transform.position = new Vector3(instObj.transform.position.x , instObj.transform.position.y + 1.2f, instObj.transform.position.z+1f);
            // add a rigidbody to the item
            instObj.AddComponent<Rigidbody>();
            
    }
     
    
}
