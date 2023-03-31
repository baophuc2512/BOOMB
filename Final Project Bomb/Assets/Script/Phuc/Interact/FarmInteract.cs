using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FarmInteract : MonoBehaviour, InterfaceInteract
{
    [SerializeField] private string interactText;
    [SerializeField] private ScriptableMoney moneyData;
    [SerializeField] private Sprite noCropSprite;
    [SerializeField] private List<Sprite> kindOfVegetable;
    [SerializeField] private List<int> amountMoneyOfVegetable;
    private Sprite currentSprite;
    private int amountMoney;
    private bool readyToHarvest;

    private void Start()
    {
        currentSprite = GetComponent<SpriteRenderer>().sprite;
        StartCoroutine(restock());
    }

    public void Interact()
    {
        if (readyToHarvest == true)
        {
            moneyData.currentMoney += amountMoney;
            StartCoroutine(restock());
        }
    }

    public IEnumerator restock()
    {
        currentSprite = noCropSprite;
        readyToHarvest = false;
        yield return new WaitForSeconds(3f);
        int random = Random.Range(0, kindOfVegetable.Count);
        currentSprite = kindOfVegetable[random];
        amountMoney = amountMoneyOfVegetable[random];
        readyToHarvest = true;
        Debug.Log(random);
    }

    public string GetInteractText()
    {
        return interactText;
    }

    public Transform GetTransform()
    {
        return transform;
    }
}
