using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestartFix : MonoBehaviour
{
    public GameObject Panel;
    public void res()
    {
        
            Time.timeScale = 1;
       

    }
    public void Awake()
    {
        Time.timeScale = 1;
       
    }
}
