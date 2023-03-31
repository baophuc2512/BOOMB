using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelOpener : MonoBehaviour
{
    public GameObject Panel;
    bool opened = false;
    public void OpenPanel()
    {
        if (Panel !=null && opened ==false)
        {
            bool isActive = Panel.activeSelf;

            Panel.SetActive(true);
            opened = true;
        }
        else if (opened==true
            
            )
        {
            Panel.SetActive(false);
            opened = false;
        }
    }
    public void ClosePanel()
    {
       
        Panel.transform.gameObject.SetActive(false);
        Time.timeScale = 1.0f;
        opened = false;
    }
    private void Update()
    {
         if (Input.GetKey(KeyCode.Escape))
        {
            Panel.transform.gameObject.SetActive(false);
            opened = false;
            Time.timeScale = 1.0f;
        }
    }
    public void JustopenPanel()
    {
        Panel.transform.gameObject.SetActive(true);
    }
    
}
