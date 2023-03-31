using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Currenthealthchange : MonoBehaviour
{
    
    public ScriptableData Datadata;
    public Text thistext;
    public InputField thisinput;
    float somau;
    KeyCode vkey;
    private void Start()
    {
        Datadata.maxHealth = 100;
        thistext.text = Datadata.maxHealth + "";
    }
    
    private void Update()
    {
        float result;
        thistext.text = Datadata.maxHealth + "";
        float.TryParse(thisinput.text, out result);
        Datadata.maxHealth = result;
    }
}
