using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class sInventoryItem : MonoBehaviour
{
    public void Awake()
    {
        Time.timeScale = 1;
    }
    public List<Image> hightlights2;
    public GameObject players;
    private SelectItem selectItems;
    public ScriptableData InvDatas;
    public List<Text> hightlightsTexts;

    private void Start()
    {
        selectItems = players.GetComponent<SelectItem>();
    }
    void Update()
    {
        if (hightlightsTexts[0].text != InvDatas.inventoryPlayerTwo[0].numberBomb.ToString())
        {
            hightlightsTexts[0].text = InvDatas.inventoryPlayerTwo[0].numberBomb.ToString();
        }
        if (hightlightsTexts[1].text != InvDatas.inventoryPlayerTwo[1].numberBomb.ToString())
        {
            hightlightsTexts[1].text = InvDatas.inventoryPlayerTwo[1].numberBomb.ToString();
        }
        if (hightlightsTexts[2].text != InvDatas.inventoryPlayerTwo[2].numberBomb.ToString())
        {
            hightlightsTexts[2].text = InvDatas.inventoryPlayerTwo[2].numberBomb.ToString();
        }
        if (hightlightsTexts[3].text != InvDatas.inventoryPlayerTwo[3].numberBomb.ToString())
        {
            hightlightsTexts[3].text = InvDatas.inventoryPlayerTwo[3].numberBomb.ToString();
        }
        if (hightlightsTexts[4].text != InvDatas.inventoryPlayerTwo[4].numberBomb.ToString())
        {
            hightlightsTexts[4].text = InvDatas.inventoryPlayerTwo[4].numberBomb.ToString();
        }
        hightLightDo2(selectItems.currentSelectItem);
    }

    public void hightLightDo2(int currentHightLight)
    {
        for (int tmp = 0; tmp < hightlights2.Count; ++tmp)
        {
            hightlights2[tmp].transform.gameObject.SetActive(false);
        }

        hightlights2[currentHightLight].transform.gameObject.SetActive(true);
    }
}
