using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            InterfaceInteract interactable = GetInteractableObject();
            if (interactable != null)
            {
                interactable.Interact();
            }
        }
    }

    public InterfaceInteract GetInteractableObject()
    {
        List<InterfaceInteract> interactableList = new List<InterfaceInteract>();
        float interactRange = 1f;
        Collider2D[] colliderArray = Physics2D.OverlapCircleAll(transform.position, interactRange);
        // Bo vao List de quet
        foreach (Collider2D collider in colliderArray)
        {
            if (collider.TryGetComponent(out InterfaceInteract interactable))
            {
                interactableList.Add(interactable);
            }
        }
        // Tim thang gan nhat
        InterfaceInteract closestInteractable = null;
        foreach (InterfaceInteract interactable in interactableList)
        {
            if (closestInteractable == null)
            {
                closestInteractable = interactable;
            } else {
                if (Vector3.Distance(transform.position, interactable.GetTransform().position) <
                    Vector3.Distance(transform.position, closestInteractable.GetTransform().position))
                {
                    closestInteractable = interactable;
                }
            }
        }
        return closestInteractable;
    }
}
