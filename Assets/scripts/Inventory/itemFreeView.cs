using UnityEngine;
using UnityEngine.UI;

public class itemFreeView : MonoBehaviour
{
    GameObject player;
    public InventoryObject inventory;
    private GameObject itemPrefab;
    Button button;

    private GameObject instantiatedItem;
    private bool isFreeViewMode = false;
    Camera camera;

    private float distanceFromCamera = 3f; // Distance from camera to the item
    private float itemSize = 1.5f; // Scale of the item
    public Button otherButton;
    
    private void Start()
    {
        player = GameObject.Find("player");
        button = GetComponent<Button>();
        camera = Camera.main;
        button.onClick.AddListener(OnButtonClicked);
        string itemName = transform.parent.name;
        itemName = itemName.Replace("(Clone)", "");  
        var item = inventory.GetItem(itemName);
        
        itemPrefab = item.model;
    }

    private void FixedUpdate()
    {
        if (isFreeViewMode )
        {       
            RotateItem();
            Vector3 itemPosition = camera.transform.position + camera.transform.forward * distanceFromCamera;
            Vector3 itemScale = Vector3.one * itemSize;

            instantiatedItem.transform.position = itemPosition;
            instantiatedItem.transform.localScale = itemScale;

            if (Input.GetKeyDown(KeyCode.Tab))
            {
                Destroy(instantiatedItem);
                isFreeViewMode = false;
            }    
        }
    }

    public void OnButtonClicked()
    {  
        if (isFreeViewMode)
        {
            // Destroy the instantiated item and exit the mode
            Destroy(instantiatedItem);
            isFreeViewMode = false;
            otherButton.interactable = true;
        }
        else
        {
            if (instantiatedItem != null)
                return;
            // Instantiate the item prefab and enter free view mode
            instantiatedItem = Instantiate(itemPrefab, Vector3.zero, Quaternion.identity);
            isFreeViewMode = true;
            otherButton.interactable = false;      
        }
    }

    private void RotateItem()
    {
        float mouseX;
        float mouseY;
        //on mouse click drag
        if (Input.GetMouseButton(0))
        {
            mouseX = Input.GetAxis("Mouse X");
            mouseY = Input.GetAxis("Mouse Y");
            
        }
        else
        {
            mouseX = 0;
            mouseY = 0;
        }
        // Rotate the item based on mouse input
        instantiatedItem.transform.Rotate(new Vector3(mouseY, mouseX, 0) * 10);
    }
}
