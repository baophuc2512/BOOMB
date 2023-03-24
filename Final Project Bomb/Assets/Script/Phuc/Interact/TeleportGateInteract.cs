using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportGateInteract : MonoBehaviour, InterfaceInteract
{
    [SerializeField] private string interactText;
    [SerializeField] private int idGate;

    public void Interact()
    {
        GameObject player = null;
        GameObject[] teleportGates;
        player = GameObject.FindWithTag("Player");
        teleportGates = GameObject.FindGameObjectsWithTag("TeleportGate");
        if (player != null && teleportGates.Length != 0)
        {
            foreach (GameObject teleportGate in teleportGates)
            {
                if (Mathf.Abs(teleportGate.GetComponent<TeleportGateInteract>().idGate - idGate) == 1)
                {
                    player.transform.position = teleportGate.transform.position;
                    break;
                }
            }
        }
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
