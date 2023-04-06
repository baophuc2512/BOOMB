using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class Attk : MonoBehaviour
{
    public ScriptableData data;
    public TextMeshProUGUI currenttext;
    private bool isbinding = false;
    KeyCode vkey2;
    public void Awake()
    {
        currenttext.text = data.inputPlaceBomb.ToString();
    }
    public void Update()
    {
        if (isbinding == true)
        {
            foreach(KeyCode vkey in System.Enum.GetValues(typeof(KeyCode)))
                {
            if (Input.GetKey(vkey))
            {
                currenttext.text=data.inputPlaceBomb.ToString();
            }
        }
        }
        
       
    }
    public void changeButton()
        {
            StartCoroutine(setBinding());
        }
    public IEnumerator setBinding()
    {
        isbinding = true;
        yield return new WaitForSeconds(3f);
        isbinding = false;
    }
}
