using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewData", menuName = "Data/Data")]

public class ScriptableData : ScriptableObject
{
    [Header("Character")]
    public float moveSpeed;
    public int maxHealth;
    public KeyCode inputMoveUp;
    public KeyCode inputMoveDown;
    public KeyCode inputMoveLeft;
    public KeyCode inputMoveRight;

    [Header("Bomb")]
    public int amountBomb;
    public int explosionDuration;
    

    [Header("Generate Enemy")]
    public List<EnemyType> enemys;
}

[Serializable]

public class EnemyType
{
    public int typeEnemy;
    public Vector3Int posRespawn;
}
