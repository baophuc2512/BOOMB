using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueInteract : MonoBehaviour, InterfaceInteract
{
    [SerializeField] private string interactText;

    public void Interact()
    {
        Debug.Log("Hello");
    }

    public string GetInteractText()
    {
        return interactText;
    }

    public Transform GetTransform()
    {
        return transform;
    }
}
