using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.Networking.UnityWebRequest;

public class Changenumbomb : MonoBehaviour
{
    public ScriptableData BombData;
    public ScriptableMoney Moneyyy;
    public List<TextMeshProUGUI> TextBombs;
    public List<TextMeshProUGUI> TextBombs2;
    public List <TMP_InputField> IPF1;
    public List<TMP_InputField> IPF2;

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
    public void doisobom(int i)
    {
        TextBombs[i].text = BombData.inventoryPlayerOne[i].numberBomb.ToString();
        int.TryParse(IPF1[i].text, out int result);
        BombData.inventoryPlayerOne[i].numberBomb = result;
    }
    public void doisobom2(int i)
    {
        TextBombs2[i].text = BombData.inventoryPlayerTwo[i].numberBomb.ToString();
        int.TryParse(IPF2[i].text, out int result);
        BombData.inventoryPlayerTwo[i].numberBomb = result;
    }
    private void Update()
    {
        
    }
}