using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    public LayerMask interactableLayer;
    public float interactionDistance = 2f;

    private GameObject currentInteractable;
    private Outline currentOutline;
    private bool isDragging = false;
    private Vector3 initialOffset;
    private Rigidbody currentRigidbody;

    private void Update()
    {
        // Check for interaction input
        if (Input.GetMouseButtonDown(0) && !isDragging)
        {
            if (currentInteractable != null && currentOutline != null)
            {
                // Start dragging if aiming at an interactable object
                isDragging = true;
                currentOutline.enabled = false;
                initialOffset = currentInteractable.transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);

                // Disable physics for the object while dragging
                currentRigidbody.isKinematic = true;
            }
        }
        else if (Input.GetMouseButtonUp(0) && isDragging)
        {
            // Stop dragging
            isDragging = false;
            if (currentOutline != null)
            {
                currentOutline.enabled = true;
                currentRigidbody.isKinematic = false;
            }
        }

        // Update dragging position
        if (isDragging && currentInteractable != null)
        {
            // Calculate the new offset continuously based on the object's position and mouse position
            Vector3 currentOffset = currentInteractable.transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3 newPosition = currentInteractable.transform.position + (initialOffset - currentOffset);
            currentInteractable.transform.position = newPosition;
        }
    }

    private void FixedUpdate()
    {
        // Perform raycast to detect interactable objects
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        GameObject previousInteractable = currentInteractable;

        if (Physics.Raycast(ray, out hit, interactionDistance, interactableLayer))
        {
            // Store the interactable object and enable the outline script
            currentInteractable = hit.collider.gameObject;
            currentOutline = currentInteractable.GetComponent<Outline>();
            currentRigidbody = currentInteractable.GetComponent<Rigidbody>();

            if (previousInteractable != currentInteractable)
            {
                // Disable the outline of the previous interactable object
                if (previousInteractable != null)
                {
                    Outline previousOutline = previousInteractable.GetComponent<Outline>();
                    if (previousOutline != null)
                    {
                        previousOutline.enabled = false;
                    }
                }
            }

            if (currentOutline != null)
            {
                currentOutline.enabled = true;
            }
        }
        else
        {
            // Disable the outline if not aiming at an interactable object
            if (currentOutline != null)
            {
                currentOutline.enabled = false;
            }
            currentInteractable = null;
            currentRigidbody = null;
            currentOutline = null;
        }
    }
}
