using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetDataFromSO : MonoBehaviour
{
    public ScriptableData dataToLoad;
    private GameObject playerOne;
    private GameObject playerTwo;
    private GameObject healthBarPlayerTwo;

    private void Awake()
    {
        playerOne = GameObject.Find("PlayerOne");
        playerTwo = GameObject.Find("PlayerTwo");
        healthBarPlayerTwo = GameObject.Find("HealthBarTwoPlayer");
        GameObject.Find("SaveDataBetweenScene").GetComponent<ApplyData>().loadData();
        if (playerOne != null)
        {
            playerOne.GetComponent<MoveCharacter>().inputDown = dataToLoad.inputMoveDown;
            playerOne.GetComponent<MoveCharacter>().inputUp = dataToLoad.inputMoveUp;
            playerOne.GetComponent<MoveCharacter>().inputLeft = dataToLoad.inputMoveLeft;
            playerOne.GetComponent<MoveCharacter>().inputRight = dataToLoad.inputMoveRight;
            playerOne.GetComponent<Health>().maxHealth = dataToLoad.maxHealth;
            playerOne.GetComponent<Health>().currentHealth = dataToLoad.maxHealth;
            playerOne.GetComponent<Health>().currentSpeed = dataToLoad.moveSpeed;
            playerOne.GetComponent<PlaceBomb>().inputPlaceBomb = dataToLoad.inputPlaceBomb;
            playerOne.GetComponent<PlaceBomb>().amountBomb = dataToLoad.amountBombCanPlace;
            playerOne.GetComponent<SelectItem>().inventory = dataToLoad.inventoryPlayerOne;
            playerOne.GetComponent<SelectItem>().selectDown = dataToLoad.inputChangeInventoryDown;
            playerOne.GetComponent<SelectItem>().selectUp = dataToLoad.inputChangeInventoryUp;
        }

        if (dataToLoad.havePlayerTwo == true && playerTwo != null)
        {
            playerTwo.SetActive(true);
            healthBarPlayerTwo.SetActive(true);
            playerTwo.GetComponent<MoveCharacter>().inputDown = dataToLoad.inputMoveDownTwo;
            playerTwo.GetComponent<MoveCharacter>().inputUp = dataToLoad.inputMoveUpTwo;
            playerTwo.GetComponent<MoveCharacter>().inputLeft = dataToLoad.inputMoveLeftTwo;
            playerTwo.GetComponent<MoveCharacter>().inputRight = dataToLoad.inputMoveRightTwo;
            playerTwo.GetComponent<Health>().maxHealth = dataToLoad.maxHealthTwo;
            playerTwo.GetComponent<Health>().currentHealth = dataToLoad.maxHealthTwo;
            playerTwo.GetComponent<Health>().currentSpeed = dataToLoad.moveSpeedTwo;
            playerTwo.GetComponent<PlaceBomb>().inputPlaceBomb = dataToLoad.inputPlaceBombTwo;
            playerTwo.GetComponent<PlaceBomb>().amountBomb = dataToLoad.amountBombCanPlace;
            playerTwo.GetComponent<SelectItem>().inventory = dataToLoad.inventoryPlayerTwo;
            playerTwo.GetComponent<SelectItem>().selectDown = dataToLoad.inputChangeInventoryDownTwo;
            playerTwo.GetComponent<SelectItem>().selectUp = dataToLoad.inputChangeInventoryUpTwo;
        }
    }
    private void Update()
    {
        if (playerOne != null)
        {
            playerOne.GetComponent<PlaceBomb>().inputPlaceBomb = dataToLoad.inputPlaceBomb;
            playerOne.GetComponent<SelectItem>().selectDown = dataToLoad.inputChangeInventoryDown;
            playerOne.GetComponent<SelectItem>().selectUp = dataToLoad.inputChangeInventoryUp;
        }
        if (dataToLoad.havePlayerTwo == true && playerTwo != null)
        {
            playerTwo.GetComponent<PlaceBomb>().inputPlaceBomb = dataToLoad.inputPlaceBombTwo;
            playerTwo.GetComponent<SelectItem>().selectDown = dataToLoad.inputChangeInventoryDownTwo;
            playerTwo.GetComponent<SelectItem>().selectUp = dataToLoad.inputChangeInventoryUpTwo;
        }
    }
}