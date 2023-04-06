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
    private GameObject player;

    private void Awake()
    {
        saveDataBetweenScene = GameObject.Find("SaveDataBetweenScene");
        applyData = saveDataBetweenScene.GetComponent<ApplyData>();
        player = GameObject.FindWithTag("Player");
    }

    public void Interact()
    {
        // Code gi do trong day
        mainDataBattle.levelMap = levelMap;
        mainDataBattle.isPvp = false;
        applyData.saveData();
        panel.SetActive(true);
        StartCoroutine(checkDistance());
    }

    public IEnumerator checkDistance()
    {
        while (true)
        {
            float distance = Vector2.Distance(new Vector2(transform.position.x, transform.position.y), new Vector2(player.transform.position.x, player.transform.position.y));
            if (distance >= 3f)
            {
                panel.SetActive(false);
                break;
            }
            yield return new WaitForSeconds(0.1f);
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
