using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class enlargePauseIngame : MonoBehaviour
{
    public Button buttons;
    public void Enlarge()
    {
        buttons.GetComponent<RectTransform>().sizeDelta = new Vector2(400, 120);

    }
    public void Mini()
    {
        buttons.GetComponent<RectTransform>().sizeDelta = new Vector2(300, 90);
    }
}
