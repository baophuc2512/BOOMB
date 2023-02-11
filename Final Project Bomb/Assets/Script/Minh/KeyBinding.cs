using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyBinding : MonoBehaviour
{
    public ScriptableData dataManager;
    public Text currentText;
    private bool isBinding = false;

    private void Update()
    {
        if (isBinding == true)
        {
            foreach (KeyCode vKey in System.Enum.GetValues(typeof(KeyCode)))
            {
                if (Input.GetKey(vKey))
                {
                    // Doi cai current text
                    currentText.text = "current text: "+ vKey;
                    Debug.Log("Key may vua moi bam la: " + vKey);
                    dataManager.inputMoveDown = vKey;
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
