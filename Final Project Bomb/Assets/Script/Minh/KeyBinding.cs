using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class KeyBinding : MonoBehaviour
{
    public ScriptableData dataManager;
    public TextMeshProUGUI nowtext;
    public Text currentText;
    private bool isBinding = false;
    public int i;
    KeyCode vkey2;
    public void Awake()
    {   
        if (i==1)
        {
            if (currentText.text.Contains("RightInv"))
            {
                //nowtext.text = dataManager.inputPlaceBomb.ToString();
            }
            else if (currentText.text.Contains("LeftInv"))
            {
                //nowtext.text = dataManager.inputPlaceBomb.ToString();
            }
            else if (currentText.text.Contains("Attk"))
            {
                nowtext.text = dataManager.inputPlaceBomb.ToString();
            }
        }
        

    }
    private void Update()
    {
        if (isBinding == true)
        {
            if (i == 1)
            {
                foreach (KeyCode vKey in System.Enum.GetValues(typeof(KeyCode)))
                {
                    if (Input.GetKey(vKey))
                    {
                        // Doi cai current text

                        if (currentText.text.Contains("Rightinv"))
                        {
                            //dataManager.input = vKey;
                            //currentText.text = "KeyDown: " + dataManager.inputMoveDown;
                        }
                        else if (currentText.text.Contains("LeftInv"))
                        {
                            //dataManager.inputMoveUp = vKey;
                            //currentText.text = "KeyUp: " + dataManager.inputMoveUp;
                        }
                        else if (currentText.text.Contains("Attk1"))
                        {
                            dataManager.inputPlaceBomb = vKey;
                            currentText.text = dataManager.inputPlaceBomb.ToString();
                        }
                        isBinding = false;
                        vkey2 = vKey;
                    }
                }

            }
            else if (i == 2)
            {

            }
            
              
            
            
        }
    
    }
    public void changeButton()
    {
        StartCoroutine(setBinding());
    }

    public IEnumerator setBinding()
    {
        isBinding = true;
        yield return new WaitForSeconds(3f);
        isBinding = false;
    }

}
