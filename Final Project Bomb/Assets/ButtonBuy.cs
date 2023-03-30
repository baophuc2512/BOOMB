using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class ButtonBuy : MonoBehaviour
{
    public GameObject Panel1;
    public ScriptableData BombData;
    public ScriptableMoney Moneyyy;

    public void boom(int type)
    {   
        int gias; 
        if (Panel1.activeSelf==true)
        {
            
            if (type == 0)
            {
                gias = 10;
                if (Moneyyy.currentMoney - gias >= 0)
                {
                    BombData.inventoryPlayerOne[type].numberBomb = BombData.inventoryPlayerOne[type].numberBomb + 1;
                    Moneyyy.currentMoney = Moneyyy.currentMoney - gias;
                }
            }
            if (type == 1)
            {
                gias = 10;
                if (Moneyyy.currentMoney - gias >= 0)
                {
                    BombData.inventoryPlayerOne[type].numberBomb = BombData.inventoryPlayerOne[type].numberBomb + 1;
                    Moneyyy.currentMoney = Moneyyy.currentMoney - gias;
                }
            }
            if (type == 2)
            {
                gias = 10;
                if (Moneyyy.currentMoney - gias >=0)
                {
                    BombData.inventoryPlayerOne[type].numberBomb = BombData.inventoryPlayerOne[type].numberBomb + 1;
                    Moneyyy.currentMoney = Moneyyy.currentMoney - gias;
                }
            }
            if (type == 3)
            {
                gias = 10;
                if (Moneyyy.currentMoney - gias >= 0)
                {
                    BombData.inventoryPlayerOne[type].numberBomb = BombData.inventoryPlayerOne[type].numberBomb + 1;
                    Moneyyy.currentMoney = Moneyyy.currentMoney - gias;
                }
            }
            if (type == 4)
            {
                gias = 10;
                if (Moneyyy.currentMoney - gias >= 0)
                {
                    BombData.inventoryPlayerOne[type].numberBomb = BombData.inventoryPlayerOne[type].numberBomb + 1;
                    Moneyyy.currentMoney = Moneyyy.currentMoney - gias;
                }
            }

        }
        else
        {
            if (type == 0)
            {
                gias = 10;
                if (Moneyyy.currentMoney - gias >= 0)
                {
                    BombData.inventoryPlayerTwo[type].numberBomb = BombData.inventoryPlayerTwo[type].numberBomb + 1;
                    Moneyyy.currentMoney = Moneyyy.currentMoney - gias;
                }
            }
            if (type == 1)
            {
                gias = 10;
                if (Moneyyy.currentMoney - gias >= 0)
                {
                    BombData.inventoryPlayerTwo[type].numberBomb = BombData.inventoryPlayerTwo[type].numberBomb + 1;
                    Moneyyy.currentMoney = Moneyyy.currentMoney - gias;
                }
            }
            if (type == 2)
            {
                gias = 10;
                if (Moneyyy.currentMoney - gias >= 0)
                {
                    BombData.inventoryPlayerTwo[type].numberBomb = BombData.inventoryPlayerTwo[type].numberBomb + 1;
                    Moneyyy.currentMoney = Moneyyy.currentMoney - gias;
                }
            }
            if (type == 3)
            {
                gias = 10;
                if (Moneyyy.currentMoney - gias >= 0)
                {
                    BombData.inventoryPlayerTwo[type].numberBomb = BombData.inventoryPlayerTwo[type].numberBomb + 1;
                    Moneyyy.currentMoney = Moneyyy.currentMoney - gias;
                }
            }
            if (type == 4)
            {
                gias = 10;
                if (Moneyyy.currentMoney - gias >= 0)
                {
                    BombData.inventoryPlayerTwo[type].numberBomb = BombData.inventoryPlayerTwo[type].numberBomb + 1;
                    Moneyyy.currentMoney = Moneyyy.currentMoney - gias;
                }
            }
        }
        

    }
}
