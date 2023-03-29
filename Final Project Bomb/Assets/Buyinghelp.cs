using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Buyinghelp : MonoBehaviour
{
    public ScriptableData BombData;
    public ScriptableMoney Moneyyy;
    public List<Text> TextBombs;
   
    void Start()
    {
        for (int i =0; i < BombData.inventoryPlayerOne.Count; i++)
        {
            TextBombs[i].text= BombData.inventoryPlayerOne[i].numberBomb.ToString();
            
        }
           
    }
    void Update()
    {
        for (int i = 0; i < BombData.inventoryPlayerOne.Count; i++)
        {
            TextBombs[i].text = BombData.inventoryPlayerOne[i].numberBomb.ToString();
            
        }
    }
}
