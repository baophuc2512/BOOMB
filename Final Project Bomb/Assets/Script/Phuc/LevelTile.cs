using System;
using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu(fileName = "New Level Tile", menuName = "2D/Tiles/Level Tile")]

public class LevelTile : Tile
{
    public TileType Type;
}

[Serializable]

public enum TileType
{
    // Ground
    grass = 0,
    // Destructable
    wallBreakable = 100,
    // Indestructable
    wallUnbreakable = 200,
    // Spawn Enemy
    enemyCarrot = 300,
    enemyOnion = 301,
}
