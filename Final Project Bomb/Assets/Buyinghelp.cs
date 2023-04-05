using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Buyinghelp : MonoBehaviour
{
    public ScriptableData BombData;
    public ScriptableMoney Moneyyy;
    public List<TextMeshProUGUI> TextBombs;
    public List<TextMeshProUGUI> TextBombs2;
   
    void Start()
    {
        for (int i =0; i < BombData.inventoryPlayerOne.Count; i++)
        {
            TextBombs[i].text= BombData.inventoryPlayerOne[i].numberBomb.ToString();
            
        }
        for (int i = 0; i < BombData.inventoryPlayerOne.Count; i++)
        {
            TextBombs2[i].text = BombData.inventoryPlayerTwo[i].numberBomb.ToString();

        }


    }
    void Update()
    {
        for (int i = 0; i < BombData.inventoryPlayerOne.Count; i++)
        {
            TextBombs[i].text = BombData.inventoryPlayerOne[i].numberBomb.ToString();
            
        }
        for (int i = 0; i < BombData.inventoryPlayerOne.Count; i++)
        {
            TextBombs2[i].text = BombData.inventoryPlayerTwo[i].numberBomb.ToString();

        }

    }
}
