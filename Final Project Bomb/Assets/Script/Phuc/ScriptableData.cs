using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewData", menuName = "Data/Data")]

public class ScriptableData : ScriptableObject
{
    [Header("Character Player 1")]
    public float moveSpeed;
    public float maxHealth;
    public KeyCode inputMoveUp;
    public KeyCode inputMoveDown;
    public KeyCode inputMoveLeft;
    public KeyCode inputMoveRight;
    public KeyCode inputPlaceBomb;
    public List<Inventory> inventoryPlayerOne;

    [Header("Character Player 2")]
    public bool havePlayerTwo;
    public float moveSpeedTwo;
    public int maxHealthTwo;
    public KeyCode inputMoveUpTwo;
    public KeyCode inputMoveDownTwo;
    public KeyCode inputMoveLeftTwo;
    public KeyCode inputMoveRightTwo;
    public KeyCode inputPlaceBombTwo;
    public List<Inventory> inventoryPlayerTwo; 

    [Header("In Game Setting")]
    public int amountBombCanPlace; 
    public int levelMap;
    
    

    [Header("Generate Enemy")]
    public List<EnemyType> enemys;
}

[Serializable]

public class EnemyType
{
    public int typeEnemy;
    public Vector3Int posRespawn;
}

[Serializable]

public class Inventory
{
    public GameObject prefab;
    public int typeBomb;
    public int numberBomb;
}