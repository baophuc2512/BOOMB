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
        playerOne.GetComponent<MoveCharacter>().inputDown = dataToLoad.inputMoveDown;
        playerOne.GetComponent<MoveCharacter>().inputUp = dataToLoad.inputMoveUp;
        playerOne.GetComponent<MoveCharacter>().inputLeft = dataToLoad.inputMoveLeft;
        playerOne.GetComponent<MoveCharacter>().inputRight = dataToLoad.inputMoveRight;
        playerOne.GetComponent<MoveCharacter>().maxHealth = dataToLoad.maxHealth;
        playerOne.GetComponent<MoveCharacter>().currentHealth = dataToLoad.maxHealth;
        playerOne.GetComponent<PlaceBomb>().inputPlaceBomb = dataToLoad.inputPlaceBomb;
        playerOne.GetComponent<PlaceBomb>().amountBomb = dataToLoad.amountBombCanPlace;
        playerOne.GetComponent<SelectItem>().inventory = dataToLoad.inventoryPlayerOne;

        if (dataToLoad.havePlayerTwo == true)
        {
            playerTwo.SetActive(true);
            healthBarPlayerTwo.SetActive(true);
            playerTwo.GetComponent<MoveCharacter>().inputDown = dataToLoad.inputMoveDownTwo;
            playerTwo.GetComponent<MoveCharacter>().inputUp = dataToLoad.inputMoveUpTwo;
            playerTwo.GetComponent<MoveCharacter>().inputLeft = dataToLoad.inputMoveLeftTwo;
            playerTwo.GetComponent<MoveCharacter>().inputRight = dataToLoad.inputMoveRightTwo;
            playerTwo.GetComponent<MoveCharacter>().maxHealth = dataToLoad.maxHealthTwo;
            playerTwo.GetComponent<MoveCharacter>().currentHealth = dataToLoad.maxHealthTwo;
            playerTwo.GetComponent<PlaceBomb>().inputPlaceBomb = dataToLoad.inputPlaceBombTwo;
            playerTwo.GetComponent<PlaceBomb>().amountBomb = dataToLoad.amountBombCanPlace;
            playerTwo.GetComponent<SelectItem>().inventory = dataToLoad.inventoryPlayerTwo;
        }
    }
}
