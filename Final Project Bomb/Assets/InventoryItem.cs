using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;
using static Unity.Burst.Intrinsics.X86.Avx;

public class InventoryItem : MonoBehaviour
{
    public void Awake()
    {
        Time.timeScale = 1;
        selectItem = player.GetComponent<SelectItem>();
    }
    public List<Image> hightlights;
    public GameObject player;
    private SelectItem selectItem;
    public ScriptableData InvData;
    public Text text1;  
    public Text text2;
    public Text text3;
    public Text text4;
    public Text text5;

    private void Start()
    {
        selectItem = player.GetComponent<SelectItem>();
    }
    void Update()   
    {
        hightLightDo(selectItem.currentSelectItem);
        text1.text = InvData.inventoryPlayerOne[0].numberBomb.ToString();
        text2.text = InvData.inventoryPlayerOne[1].numberBomb.ToString();
        text3.text = InvData.inventoryPlayerOne[2].numberBomb.ToString();
        text4.text = InvData.inventoryPlayerOne[3].numberBomb.ToString();
        text5.text = InvData.inventoryPlayerOne[4].numberBomb.ToString();


    }

    public void hightLightDo(int currentHightLight)
    {
        for (int tmp = 0; tmp < hightlights.Count;++tmp)
        {
            
            hightlights[tmp].transform.gameObject.SetActive(false);
            

        }
        hightlights[currentHightLight].transform.gameObject.SetActive(true);
        
    }
}
