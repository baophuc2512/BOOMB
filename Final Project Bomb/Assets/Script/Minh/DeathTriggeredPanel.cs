using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Transactions;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class DeathTriggeredPanel : MonoBehaviour
{
    
    [SerializeField] PanelOpener PanelOpener;
    GameObject[] playerArrays;
    GameObject[] enemyArrays;
    [SerializeField] private ScriptableData mainData;
    public Text Txt;
    public GameObject panel;
    public Button button;
    public GameObject imagewon;
    public GameObject imagelose;
    public GameObject player1won;
    public GameObject player2won;
    private void Update()
    {
        playerArrays = GameObject.FindGameObjectsWithTag("Player");
        enemyArrays = GameObject.FindGameObjectsWithTag("Enemy");
        if (mainData.isPvp == true)
        {
            
            if (playerArrays.Length ==1)
            {
                Debug.Log("Co vo");
                panel.gameObject.SetActive(true);
                button.gameObject.SetActive(false);
   
                if (playerArrays[0].name=="PlayerOne")
                {
                    player1won.gameObject.SetActive(true);
                    player2won.gameObject.SetActive(false);
                }
                else
               {
                   player1won.gameObject.SetActive(false);
                    player2won.gameObject.SetActive(true) ;
                  }
            }
            else if (playerArrays.Length == 0)
            {
                panel.gameObject.SetActive(true);
                button.gameObject.SetActive(false);
                Txt.text = "DRAW!!";
            }
        }
        else if (mainData.isPvp == false)
        {
            if (playerArrays.Length == 0)
            {
                panel.gameObject.SetActive(true);
                button.gameObject.SetActive(false);
                imagelose.gameObject.SetActive(true) ;
                imagewon.gameObject.SetActive(false) ;
            }
            else if (enemyArrays.Length==0)
            {
                panel.gameObject.SetActive(true);
                button.gameObject.SetActive(false);
                Txt.text = "YOU WIN!";
                imagelose.gameObject.SetActive(false);
                imagewon.gameObject.SetActive(true);
            }
        }
        
        
    }
    private void Awake()
    {
        enemyArrays = GameObject.FindGameObjectsWithTag("Enemy");
    }
}
