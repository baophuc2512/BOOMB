using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonBuy : MonoBehaviour
{
    public ScriptableData BombData;
    public ScriptableMoney Moneyyy;

    public void boom(int type)
    {
        int gias;
        if (type == 0)
        {   
            gias = 10;
            if (Moneyyy.currentMoney - gias >0)
            {
                BombData.inventoryPlayerOne[type].numberBomb = BombData.inventoryPlayerOne[type].numberBomb + 1;
                Moneyyy.currentMoney =Moneyyy.currentMoney- gias;
            } 
        }
        if (type == 1)
        {
            gias = 10;
            if (Moneyyy.currentMoney - gias > 0)
            {
                BombData.inventoryPlayerOne[type].numberBomb = BombData.inventoryPlayerOne[type].numberBomb + 1;
                Moneyyy.currentMoney = Moneyyy.currentMoney - gias;
            }
        }
        if (type == 2)
        {
            gias = 10;
            if (Moneyyy.currentMoney - gias > 0)
            {
                BombData.inventoryPlayerOne[type].numberBomb = BombData.inventoryPlayerOne[type].numberBomb + 1;
                Moneyyy.currentMoney = Moneyyy.currentMoney - gias;
            }
        }
        if (type == 3)
        {
            gias = 10;
            if (Moneyyy.currentMoney - gias > 0)
            {
                BombData.inventoryPlayerOne[type].numberBomb = BombData.inventoryPlayerOne[type].numberBomb + 1;
                Moneyyy.currentMoney = Moneyyy.currentMoney - gias;
            }
        }
        if (type == 4)
        {
            gias = 10;
            if (Moneyyy.currentMoney - gias > 0)
            {
                BombData.inventoryPlayerOne[type].numberBomb = BombData.inventoryPlayerOne[type].numberBomb + 1;
                Moneyyy.currentMoney = Moneyyy.currentMoney - gias;
            }
        }

    }
}
