using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CurrentHealth2 : MonoBehaviour
{
   public ScriptableData Datadata;
    public Text thistext1;
    public InputField thisinput1;
    float somau;
    KeyCode vkey;
    private void Awake()
    {
        thistext1.text = thistext1.text + Datadata.maxHealthTwo;
    }
    public void Changmau()
    {
        int result1;
        int.TryParse(thisinput1.text, out result1);
        Datadata.maxHealthTwo = result1;
    }
}
