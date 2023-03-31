using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopInteract : MonoBehaviour, InterfaceInteract
{
    [SerializeField] private string interactText;
    [SerializeField] private GameObject panelShop;

    public void Interact()
    {
        panelShop.SetActive(true);
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
