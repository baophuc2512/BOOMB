using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptableLevel : ScriptableObject
{
    public int LevelIndex;
    public List<SavedTile> groundTiles;
    public List<SavedTile> destructableTiles;
    public List<SavedTile> indestructableTiles;
    public List<SavedTile> enemySpawnTiles; 
}

[Serializable]

public class SavedTile
{
    public Vector3Int position;
    public LevelTile tile;
}