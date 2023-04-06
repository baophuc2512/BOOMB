using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turnongameobject : MonoBehaviour
{
    public GameObject panel1;
    public GameObject panel2;
    public void openandclose()
    {
        if (panel1.activeSelf==true)
        {
            panel1.SetActive(false);
            panel2.SetActive(true);
        }
        else
        {
            panel1.SetActive(true);
            panel2.SetActive(false);
        } 
            
    }    
}
