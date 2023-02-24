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
    private void Awake()
    {
        thistext.text = thistext.text + Datadata.maxHealth;
    }
    public void Changmau()
    {
        float result;
        float.TryParse(thisinput.text, out result);
        Datadata.maxHealth = result;
    }
}
