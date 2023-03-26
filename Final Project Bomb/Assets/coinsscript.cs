using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class coinsscript : MonoBehaviour
{
    public Text Txt;
    public ScriptableMoney Moneydata;
    void Awake()
    {
        Txt.text = Moneydata.currentMoney.ToString();
    }
    void Update()
    {
        if(Txt.text != Moneydata.currentMoney.ToString())
        {
            Txt.text =Moneydata.currentMoney.ToString();
        }
        
    }
}
