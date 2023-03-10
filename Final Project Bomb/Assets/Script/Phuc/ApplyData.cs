using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplyData : MonoBehaviour
{
    public ScriptableData dataToLoad;
    public GameObject playerOne;
    public GameObject playerTwo;
    public GameObject healthBarPlayerTwo;
    
    private void Awake()
    {
        if (GetComponent<MoveCharacter>()) 
        {
            playerOne.GetComponent<MoveCharacter>().inputDown = dataToLoad.inputMoveDown;
            playerOne.GetComponent<MoveCharacter>().inputUp = dataToLoad.inputMoveUp;
            playerOne.GetComponent<MoveCharacter>().inputLeft = dataToLoad.inputMoveLeft;
            playerOne.GetComponent<MoveCharacter>().inputRight = dataToLoad.inputMoveRight;
        }
        if (GetComponent<Health>()) 
        {
            playerOne.GetComponent<Health>().maxHealth = dataToLoad.maxHealth;
            playerOne.GetComponent<Health>().currentHealth = dataToLoad.maxHealth;
            playerOne.GetComponent<Health>().currentSpeed = dataToLoad.moveSpeed;
        }
        if (GetComponent<PlaceBomb>()) 
        {
            playerOne.GetComponent<PlaceBomb>().inputPlaceBomb = dataToLoad.inputPlaceBomb;
            playerOne.GetComponent<PlaceBomb>().amountBomb = dataToLoad.amountBombCanPlace;
        }
        if (GetComponent<SelectItem>()) 
        {
            playerOne.GetComponent<SelectItem>().inventory = dataToLoad.inventoryPlayerOne;
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
            playerTwo.GetComponent<Health>().currentSpeed = dataToLoad.moveSpeed;
            playerTwo.GetComponent<PlaceBomb>().inputPlaceBomb = dataToLoad.inputPlaceBombTwo;
            playerTwo.GetComponent<PlaceBomb>().amountBomb = dataToLoad.amountBombCanPlace;
            playerTwo.GetComponent<SelectItem>().inventory = dataToLoad.inventoryPlayerTwo;
        }
    }
}