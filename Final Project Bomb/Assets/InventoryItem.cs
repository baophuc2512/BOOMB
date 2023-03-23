using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventoryItem : MonoBehaviour
{   
    int i = 2;
    public Image Inv1;
    public Image Inv2;
    public Image Inv3;
    public Image Inv4;
    public Image Inv5;
    public Image hightlight1;
    public Image hightlight2;
    public Image hightlight3;
    public Image hightlight4;
    public Image hightlight5;
    public ScriptableData InvData;
    void Update()
    {
       
       if(Input.GetKeyUp(KeyCode.E))
        {
            
             if (i ==2)
                {
                hightlight1.transform.gameObject.SetActive(false);
                hightlight2.transform.gameObject.SetActive(true);
                ++i;
                }
            else if (i == 3)
            {
                hightlight2.transform.gameObject.SetActive(false);
                hightlight3.transform.gameObject.SetActive(true);
                ++i;
            }
            else if (i == 4)
            {
                hightlight3.transform.gameObject.SetActive(false);
                hightlight4.transform.gameObject.SetActive(true);
                ++i;
            }
            else if (i == 5)
            {
                hightlight4.transform.gameObject.SetActive(false);
                hightlight5.transform.gameObject.SetActive(true);
                i = 1;
            }       
            else if (i==1)
            {
                hightlight5.transform.gameObject.SetActive(false);
                hightlight1.transform.gameObject.SetActive(true);
                ++i;
            }
            
            
        }
        
        

    }
}
