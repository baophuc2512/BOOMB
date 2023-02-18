using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EscPause : MonoBehaviour
{
    public Button BtnEsc;
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
            {
                BtnEsc.onClick.Invoke();
            }
    }
}
