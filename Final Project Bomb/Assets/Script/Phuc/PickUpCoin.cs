using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpCoin : MonoBehaviour
{
    [SerializeField] private ScriptableMoney scriptableMoney;
    [SerializeField] private int amountOfMoney;

    private void OnTriggerEnter2D (Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            scriptableMoney.currentMoney += amountOfMoney;
            Destroy(gameObject);
        }
    }

}
