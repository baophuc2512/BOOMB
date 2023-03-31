using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplyData : MonoBehaviour
{
    public ScriptableData dataToLoad;
    public ScriptableMoney moneyToLoad;
    private GameObject playerOne;
    private GameObject playerTwo;
    private GameObject healthBarPlayerTwo;
    

    [Header("Character Player 1")]
    [SerializeField] private float moveSpeed;
    [SerializeField] private float maxHealth;
    [SerializeField] private KeyCode inputMoveUp;
    [SerializeField] private KeyCode inputMoveDown;
    [SerializeField] private KeyCode inputMoveLeft;
    [SerializeField] private KeyCode inputMoveRight;
    [SerializeField] private KeyCode inputPlaceBomb;
    [SerializeField] private List<Inventory> inventoryPlayerOne;

    [Header("Character Player 2")]
    [SerializeField] private bool havePlayerTwo;
    [SerializeField] private float moveSpeedTwo;
    [SerializeField] private float maxHealthTwo;
    [SerializeField] private KeyCode inputMoveUpTwo;
    [SerializeField] private KeyCode inputMoveDownTwo;
    [SerializeField] private KeyCode inputMoveLeftTwo;
    [SerializeField] private KeyCode inputMoveRightTwo;
    [SerializeField] private KeyCode inputPlaceBombTwo;
    [SerializeField] private List<Inventory> inventoryPlayerTwo;

    [Header("In Game Setting")]
    public int amountBombCanPlace;
    public int levelMap;
    public bool isPvp;

    [Header("Money")]
    [SerializeField] private int currentMoney;
    
    private void Awake()
    {
        getGameObject();
        saveData();
    }
    /////////////// ---------------------TAKE FIRST DATA------------------------ \\\\\\\\\\\\\\\\\

    public void getGameObject()
    {
        playerOne = GameObject.Find("PlayerOne");
        playerTwo = GameObject.Find("PlayerTwo");
        healthBarPlayerTwo = GameObject.Find("HealthBarTwoPlayer");
    }

    public void loadData()
    {
        Debug.Log("Load Data");
        if (playerOne != null)
        {
            dataToLoad.inputMoveDown = inputMoveDown;
            dataToLoad.inputMoveUp = inputMoveUp;
            dataToLoad.inputMoveLeft = inputMoveLeft;
            dataToLoad.inputMoveRight = inputMoveRight;
            dataToLoad.maxHealth = maxHealth;
            dataToLoad.maxHealth = maxHealth;
            dataToLoad.moveSpeed = moveSpeed;
            dataToLoad.inputPlaceBomb = inputPlaceBomb;
            dataToLoad.amountBombCanPlace = amountBombCanPlace;
            dataToLoad.inventoryPlayerOne = inventoryPlayerOne;
        }
        dataToLoad.havePlayerTwo = havePlayerTwo;
        if (havePlayerTwo == true && playerTwo != null)
        {
            playerTwo.SetActive(true);
            healthBarPlayerTwo.SetActive(true);
            dataToLoad.inputMoveDownTwo = inputMoveDownTwo;
            dataToLoad.inputMoveUpTwo = inputMoveUpTwo;
            dataToLoad.inputMoveLeftTwo = inputMoveLeftTwo;
            dataToLoad.inputMoveRightTwo = inputMoveRightTwo;
            dataToLoad.maxHealthTwo = maxHealthTwo;
            dataToLoad.maxHealthTwo = maxHealthTwo;
            dataToLoad.moveSpeedTwo = moveSpeedTwo;
            dataToLoad.inputPlaceBombTwo = inputPlaceBombTwo;
            dataToLoad.amountBombCanPlace = amountBombCanPlace;
            dataToLoad.inventoryPlayerTwo = inventoryPlayerTwo;
        }
        moneyToLoad.currentMoney = currentMoney;
        /// Ingame Setting
        dataToLoad.levelMap = levelMap;
        dataToLoad.isPvp = isPvp;
    }

    public void saveData()
    {
        Debug.Log("Save Data");
        inputMoveDown =  dataToLoad.inputMoveDown;
        inputMoveUp = dataToLoad.inputMoveUp;
        inputMoveLeft = dataToLoad.inputMoveLeft;
        inputMoveRight = dataToLoad.inputMoveRight;
        maxHealth = dataToLoad.maxHealth;
        maxHealth = dataToLoad.maxHealth;
        moveSpeed = dataToLoad.moveSpeed;
        inputPlaceBomb = dataToLoad.inputPlaceBomb;
        amountBombCanPlace = dataToLoad.amountBombCanPlace;
        inventoryPlayerOne = dataToLoad.inventoryPlayerOne;
        havePlayerTwo = dataToLoad.havePlayerTwo;
        inputMoveDownTwo = dataToLoad.inputMoveDownTwo;
        inputMoveUpTwo = dataToLoad.inputMoveUpTwo;
        inputMoveLeftTwo = dataToLoad.inputMoveLeftTwo;
        inputMoveRightTwo = dataToLoad.inputMoveRightTwo;
        maxHealthTwo = dataToLoad.maxHealthTwo;
        maxHealthTwo = dataToLoad.maxHealthTwo;
        moveSpeedTwo = dataToLoad.moveSpeedTwo;
        inputPlaceBombTwo = dataToLoad.inputPlaceBombTwo;
        amountBombCanPlace = dataToLoad.amountBombCanPlace;
        inventoryPlayerTwo = dataToLoad.inventoryPlayerTwo;
        currentMoney = moneyToLoad.currentMoney;
        /// Ingame Setting
        levelMap = dataToLoad.levelMap;
        isPvp = dataToLoad.isPvp;
    }
}