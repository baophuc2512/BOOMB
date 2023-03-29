using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

using UnityEngine;
using UnityEngine.UI;

public class KeyBinding : MonoBehaviour
{
    public ScriptableData dataManager;
    public Text currentText;
    private bool isBinding = false;
    public Text Playertext;
    KeyCode vkey2;
    public void Awake()
    {   
        if (Playertext.text =="Player1")
        {
             if (currentText.text.Contains("Down"))
        {
            currentText.text = "KeyDown: " + dataManager.inputMoveDown;
        }
        else if (currentText.text.Contains("Up"))
        {
            currentText.text = "KeyUp: " + dataManager.inputMoveUp;
        }

        else if (currentText.text.Contains("Left"))
        {
            currentText.text = "KeyLeft: " + dataManager.inputMoveLeft;
        }
        else if (currentText.text.Contains("Right"))
        {
            currentText.text = "KeyRight: " + dataManager.inputMoveRight;
        }
        }
        else if (Playertext.text =="Player2")
        {
            if (currentText.text.Contains("Down"))
            {
                currentText.text = "KeyDown: " + dataManager.inputMoveDownTwo;
            }
            else if (currentText.text.Contains("Up"))
            {
                currentText.text = "KeyUp: " + dataManager.inputMoveUpTwo;
            }

            else if (currentText.text.Contains("Left"))
            {
                currentText.text = "KeyLeft: " + dataManager.inputMoveLeftTwo;
            }
            else if (currentText.text.Contains("Right"))
            {
                currentText.text = "KeyRight: " + dataManager.inputMoveRightTwo;
            }
        }
        
    }
    private void Update()
    {
        if (isBinding == true)
        {
            if (Playertext.text =="Player1")
            {
                foreach (KeyCode vKey in System.Enum.GetValues(typeof(KeyCode)))
                {
                    if (Input.GetKey(vKey))
                    {
                        // Doi cai current text

                        if (currentText.text.Contains("Down"))
                        {
                            dataManager.inputMoveDown = vKey;
                            currentText.text = "KeyDown: " + dataManager.inputMoveDown;
                        }
                        else if (currentText.text.Contains("Up"))
                        {
                            dataManager.inputMoveUp = vKey;
                            currentText.text = "KeyUp: " + dataManager.inputMoveUp;
                        }

                        else if (currentText.text.Contains("Left"))
                        {
                            dataManager.inputMoveLeft = vKey;
                            currentText.text = "KeyLeft: " + dataManager.inputMoveLeft;
                        }
                        else if (currentText.text.Contains("Right"))
                        {
                            dataManager.inputMoveRight = vKey;
                            currentText.text = "KeyRight: " + dataManager.inputMoveRight;
                        }

                        isBinding = false;
                        vkey2 = vKey;
                    }
                }
            
            }
            else if (Playertext.text =="Player2")
            {
                foreach (KeyCode vKey in System.Enum.GetValues(typeof(KeyCode)))
                {
                    if (Input.GetKey(vKey))
                    {
                        // Doi cai current text

                        if (currentText.text.Contains("Down"))
                        {
                            dataManager.inputMoveDown = vKey;
                            currentText.text = "KeyDown: " + dataManager.inputMoveDownTwo;
                        }
                        else if (currentText.text.Contains("Up"))
                        {
                            dataManager.inputMoveUp = vKey;
                            currentText.text = "KeyUp: " + dataManager.inputMoveUpTwo;
                        }

                        else if (currentText.text.Contains("Left"))
                        {
                            dataManager.inputMoveLeft = vKey;
                            currentText.text = "KeyLeft: " + dataManager.inputMoveLeftTwo;
                        }
                        else if (currentText.text.Contains("Right"))
                        {
                            dataManager.inputMoveRight = vKey;
                            currentText.text = "KeyRight: " + dataManager.inputMoveRightTwo;
                        }

                        isBinding = false;
                        vkey2 = vKey;
                    }
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
        isBinding = true;
        yield return new WaitForSeconds(3f);
        isBinding = false;
    }

}
