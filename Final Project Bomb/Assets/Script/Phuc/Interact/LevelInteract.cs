using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelInteract : MonoBehaviour, InterfaceInteract
{
    [SerializeField] private string interactText;
    [SerializeField] private ScriptableData mainDataBattle;
    [SerializeField] private int levelMap;
    [SerializeField] private GameObject panel;
    private GameObject saveDataBetweenScene;
    private ApplyData applyData;

    private void Awake()
    {
        saveDataBetweenScene = GameObject.Find("SaveDataBetweenScene");
        applyData = saveDataBetweenScene.GetComponent<ApplyData>();
    }

    public void Interact()
    {
        // Code gi do trong day
        mainDataBattle.levelMap = levelMap;
        mainDataBattle.isPvp = false;
        applyData.saveData();
        panel.SetActive(true);
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
