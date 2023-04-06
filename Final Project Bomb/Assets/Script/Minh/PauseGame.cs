using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseGame : MonoBehaviour
{
    public GameObject panel;
    public GameObject buttons;
    
    // Update is called once per frame
    IEnumerator Reset()
    {
        // your process
        yield return new WaitForSeconds(3);
        // continue process
    }
    public void PauseAndResumegame()
    {
            if(Time.timeScale ==1)
                Time.timeScale = 0;
            else
                Time.timeScale = 1;  
    }
    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            panel.SetActive(!panel.gameObject.activeSelf);
            buttons.SetActive(!panel.gameObject.activeSelf);
            if (panel.gameObject.activeSelf)
            {
                Time.timeScale = 0;
            }
            else Time.timeScale = 1;
        }
        

    }
    public void ResumeGame()
    {
        Time.timeScale = 1;
    }
    public void Pausegame()
    {
        Time.timeScale = 0;
    }
   
}
