using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Currenthealthchange : MonoBehaviour
{
    [SerializeField] Health mau;
    public Text thistext;
    float somau;
    KeyCode vkey;
    private void Awake()
    {
        thistext.text=thistext.text+ mau.currentHealth.ToString();
    }
    public void Changmau()
    {
        
    }
}
