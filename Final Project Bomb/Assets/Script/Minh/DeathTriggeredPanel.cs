using System.Collections;
using System.Collections.Generic;
using System.Transactions;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class DeathTriggeredPanel : MonoBehaviour
{
    
    [SerializeField] PanelOpener PanelOpener;
    GameObject[] playerArrays;
    GameObject[] enemyArrays;
    bool pvp = false;
    public Text Txt;
    public GameObject panel;
    public Button button;
    private void Update()
    {
        playerArrays = GameObject.FindGameObjectsWithTag("Player");
        enemyArrays = GameObject.FindGameObjectsWithTag("Enemy");
        if (pvp==true)
        {
            
            if (playerArrays.Length ==   1)
            {
                panel.gameObject.SetActive(true);
                button.gameObject.SetActive(false);
                Txt.text = playerArrays[0].name+ " WIN!";               
            }
            else if (playerArrays.Length == 0)
            {
                panel.gameObject.SetActive(true);
                button.gameObject.SetActive(false);
                Txt.text = "DRAW!!";
            }
        }
        else if (pvp==false)
        {
            if (playerArrays.Length == 0)
            {
                panel.gameObject.SetActive(true);
                button.gameObject.SetActive(false);
                Txt.text = "GAMEOVER!!";
            }
            else if (enemyArrays.Length==0)
            {
                panel.gameObject.SetActive(true);
                button.gameObject.SetActive(false);
                Txt.text = "YOU WIN!";
            }
        }
        
        
    }
    private void Awake()
    {
        enemyArrays = GameObject.FindGameObjectsWithTag("Enemy");
        if (enemyArrays.Length > 0)
        {
            pvp = false;
        }
        else pvp = true;
    }

}
