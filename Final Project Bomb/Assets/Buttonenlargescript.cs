using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Buttonenlargescript : MonoBehaviour
{
    public Button buttons;
    public void Enlarge()
    {
        buttons.GetComponent<RectTransform>().sizeDelta = new Vector2(600, 183);
        
    }
    public void Mini()
    {
        buttons.GetComponent<RectTransform>().sizeDelta = new Vector2(500,140);
    }
    
}
