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
    public TextMeshProUGUI text;
    private bool isBinding = false;
    public int type;

    // 1: player 1 key up, 2: player 1 key down, 3: player 1 key attack
    // 4: player 2 key up, 5: player 2 key down, 6: player 2 key attack

    private void Update()
    {
        if (type == 1) text.text = dataManager.inputChangeInventoryUp.ToString();
        if (type == 2) text.text = dataManager.inputChangeInventoryDown.ToString();
        if (type == 3) text.text = dataManager.inputPlaceBomb.ToString();
        if (type == 4) text.text = dataManager.inputChangeInventoryUpTwo.ToString();
        if (type == 5) text.text = dataManager.inputChangeInventoryDownTwo.ToString();
        if (type == 6) text.text = dataManager.inputPlaceBombTwo.ToString();
        if (isBinding == true)
        {
            foreach (KeyCode vKey in System.Enum.GetValues(typeof(KeyCode)))
            {
                if (Input.GetKey(vKey))
                {
                    // Doi cai current text
                    if (type == 1)
                    {
                        dataManager.inputChangeInventoryUp = vKey;
                    }
                    if (type == 2)
                    {
                        dataManager.inputChangeInventoryDown = vKey;
                    }
                    if (type == 3)
                    {
                        dataManager.inputPlaceBomb = vKey;
                    }
                    if (type == 4)
                    {
                        dataManager.inputChangeInventoryUpTwo = vKey;
                    }
                    if (type == 5)
                    {
                        dataManager.inputChangeInventoryDownTwo = vKey;
                    }
                    if (type == 6)
                    {
                        dataManager.inputPlaceBombTwo = vKey;
                    }
                    isBinding = false;
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