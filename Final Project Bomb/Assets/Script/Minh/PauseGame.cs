using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseGame : MonoBehaviour
{
    // Update is called once per frame
    public void PauseAndResumegame()
    {
            if(Time.timeScale ==1)
                Time.timeScale = 0;
            else
                Time.timeScale = 1;  
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
