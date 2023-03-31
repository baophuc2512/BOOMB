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
    private void Start()
    {
        Datadata.maxHealthTwo = 100;
        thisinput1.text = Datadata.maxHealthTwo + "";
        thistext1.text = Datadata.maxHealthTwo + "";
    }

    private void Update()
    {
        float result;
        thistext1.text = Datadata.maxHealthTwo + "";
        float.TryParse(thisinput1.text, out result);
        Datadata.maxHealthTwo = result;
    }
}
