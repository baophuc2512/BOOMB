using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class EnlargeHomescene : MonoBehaviour
{
    public Button buttons;
    public void Enlarge()
    {
        buttons.GetComponent<RectTransform>().sizeDelta = new Vector2(600, 225);

    }
    public void Mini()
    {
        buttons.GetComponent<RectTransform>().sizeDelta = new Vector2(500, 188);
    }
}
