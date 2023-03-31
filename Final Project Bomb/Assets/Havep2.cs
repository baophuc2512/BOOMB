using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Havep2 : MonoBehaviour
{
    public ScriptableData Data23;
    public GameObject panel;
    public Image image1;
    public Image image2;
    public void Turnonp2()
    {

        Data23.havePlayerTwo = true;
        panel.gameObject.SetActive(false);
        image1.gameObject.SetActive(false);
        image2.gameObject.SetActive(true); 
        
    }
    public void Turnoffp2()
    {
        Data23.havePlayerTwo = false;
        panel.gameObject.SetActive(false);
        image1.gameObject.SetActive(true);
        image2.gameObject.SetActive(false);
    }
    private void Update()
    {
        if (Data23.havePlayerTwo)
        {
            image1.gameObject.SetActive(false);
            image2.gameObject.SetActive(true);
        }
        else
        {
            image1.gameObject.SetActive(true);
            image2.gameObject.SetActive(false);
        }
    }
}
