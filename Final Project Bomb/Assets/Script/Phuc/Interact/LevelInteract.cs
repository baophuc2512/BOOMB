using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelInteract : MonoBehaviour, InterfaceInteract
{
    [SerializeField] private string interactText;
    [SerializeField] private ScriptableData mainDataBattle;
    [SerializeField] private int levelMap;

    public void Interact()
    {
        mainDataBattle.levelMap = levelMap;
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
