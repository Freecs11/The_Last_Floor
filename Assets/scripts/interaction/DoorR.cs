using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DoorR : MonoBehaviour
{

    [SerializeField] private int rayLength = 5;
    [SerializeField] private LayerMask layerMaskInteract;
    [SerializeField] private string excludeLayerName = null;
    
       public GameObject ActionDisplay;
    public GameObject ActionText;


    private MyDoorC raycastedObj;

    [SerializeField] private KeyCode openDoorKey = KeyCode.Tab;
    [SerializeField] private Image crosshair = null;
    private bool isCrosshairActive;
    private bool doOnce;

    private const string interactableTag = "InteractiveObject";

    private void Update()
    {
        RaycastHit hit;
        Vector3 fwd = transform.TransformDirection(Vector3.forward);

        int mask = 1 << LayerMask.NameToLayer(excludeLayerName) | layerMaskInteract.value;

        if(Physics.Raycast(transform.position, fwd, out hit, rayLength, mask))
        {
            if(hit.collider.CompareTag(interactableTag))
            {
                if(!doOnce)
                {
                    raycastedObj = hit.collider.gameObject.GetComponent<MyDoorC>();
                    CrosshairChange(true);
                }

                isCrosshairActive = true;
                doOnce = true;

                if(Input.GetKeyDown(openDoorKey))
                {
                    raycastedObj.PlayAnimation();
                }
            }
        }
        
        else 
        {
            if(isCrosshairActive)
            {
                CrosshairChange(false);
                doOnce = false;
            }
        }

    }
 void CrosshairChange(bool on)
 {
    if(on && !doOnce)
    {
        crosshair.color = Color.red;
        ActionDisplay.SetActive(true);
            ActionText.SetActive(true);
    }
    else
    {
        crosshair.color = Color.white;
        isCrosshairActive = false;
          ActionDisplay.SetActive(false);
            ActionText.SetActive(false);
    }
 }
}
