using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fullsceen : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKey(KeyCode.F11))
        {
            if (Screen.fullScreen == true)
            {
                Screen.fullScreen = false;
            }

            else
            {
                Screen.fullScreen = true;
            }
        }
    }
}
