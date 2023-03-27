using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventoryItem : MonoBehaviour
{
    public void Awake()
    {
        Time.timeScale = 1;
    }
    public List<Image> hightlights;
    public GameObject player;
    private SelectItem selectItem;
    public ScriptableData InvData;

    private void Start()
    {
        selectItem = player.GetComponent<SelectItem>();
    }
    void Update()
    {
        
        hightLightDo(selectItem.currentSelectItem);
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
