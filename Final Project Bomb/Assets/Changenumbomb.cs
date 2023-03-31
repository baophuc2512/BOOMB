using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Changenumbomb : MonoBehaviour
{
    public ScriptableData BombData;
    public ScriptableMoney Moneyyy;
    public List<Text> TextBombs;
    public List<Text> TextBombs2;
    public List<InputField> IPF1;
    public List<InputField> IPF2;

    void Awake()
    {
        for (int i = 0; i < BombData.inventoryPlayerOne.Count; i++)
        {
            IPF1[i].text= BombData.inventoryPlayerOne[i].numberBomb.ToString();
            TextBombs[i].text = BombData.inventoryPlayerOne[i].numberBomb.ToString();

        }
        for (int i = 0; i < BombData.inventoryPlayerOne.Count; i++)
        {
            IPF2[i].text = BombData.inventoryPlayerTwo[i].numberBomb.ToString();
            TextBombs2[i].text = BombData.inventoryPlayerTwo[i].numberBomb.ToString();

        }


    }
    void Update()
    {
        int result;
        for (int i = 0; i < BombData.inventoryPlayerOne.Count; i++)
        {
            TextBombs[i].text = BombData.inventoryPlayerOne[i].numberBomb.ToString();
            int.TryParse(IPF1[i].text, out result);
            BombData.inventoryPlayerOne[i].numberBomb = result;

        }
        for (int i = 0; i < BombData.inventoryPlayerOne.Count; i++)
        {
            TextBombs2[i].text = BombData.inventoryPlayerTwo[i].numberBomb.ToString();
            int.TryParse(IPF2[i].text, out result);
            BombData.inventoryPlayerTwo[i].numberBomb = result;

        }

    }
}