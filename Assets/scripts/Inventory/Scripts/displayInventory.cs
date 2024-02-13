using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class displayInventory : MonoBehaviour
{
    public InventoryObject inventory;
    public int X_START;
    public int Y_START;
    public int X_SPACE_BETWEEN_ITEM;
    public int NUMBER_OF_COLUMN;
    public int Y_SPACE_BETWEEN_ITEM;
    public static Dictionary<InventorySlot, GameObject> itemsDisplayed = new Dictionary<InventorySlot, GameObject>();
    

    // Start is called before the first frame update
    void Start()
    {
        createDisplay();
    }

    // Update is called once per frame
    void Update()
    {
        updateDisplay();
    }

    public void createDisplay(){
        for (int i = 0; i < inventory.Container.Count; i++){
            var obj = Instantiate(inventory.Container[i].item.prefab, Vector3.zero, Quaternion.identity, transform);
            obj.GetComponent<RectTransform>().localPosition = getPosition(i);
            obj.GetComponentInChildren<TextMeshProUGUI>().text = inventory.Container[i].amount.ToString("n0");
            if(!itemsDisplayed.ContainsKey(inventory.Container[i])) {
                itemsDisplayed.Add(inventory.Container[i], obj);
            }
        }
    }

    public Vector3 getPosition(int i){
        return new Vector3(X_START + (X_SPACE_BETWEEN_ITEM * (i % NUMBER_OF_COLUMN)), Y_START + (-Y_SPACE_BETWEEN_ITEM * (i / NUMBER_OF_COLUMN)), 0f);
    }

    public void updateDisplay(){
        for (int i = 0; i < inventory.Container.Count; i++){
            if(itemsDisplayed.ContainsKey(inventory.Container[i])){
                // if the item is not in the inventory we will remove it from the itemsDisplayed
                if( inventory.Container[i].amount <= 0){
                    Destroy(itemsDisplayed[inventory.Container[i]]);
                    itemsDisplayed.Remove(inventory.Container[i]);
                    // also destroy the item from the inventory 
                    inventory.Container.Remove(inventory.Container[i]);
                    continue;
                }

                itemsDisplayed[inventory.Container[i]].GetComponent<RectTransform>().localPosition = getPosition(i);
                itemsDisplayed[inventory.Container[i]].GetComponentInChildren<TextMeshProUGUI>().text = inventory.Container[i].amount.ToString("n0");
            }else{
                var obj = Instantiate(inventory.Container[i].item.prefab, Vector3.zero, Quaternion.identity, transform);
                obj.GetComponent<RectTransform>().localPosition = getPosition(i);
                obj.GetComponentInChildren<TextMeshProUGUI>().text = inventory.Container[i].amount.ToString("n0");
                itemsDisplayed.Add(inventory.Container[i], obj);
            }

        }
    }


}
