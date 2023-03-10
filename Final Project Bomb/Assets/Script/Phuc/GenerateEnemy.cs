using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class GenerateEnemy : MonoBehaviour
{
    [SerializeField] private Tilemap enemySpawnMap;
    [SerializeField] private GameObject enemyCarrotPrefab;
    [SerializeField] private GameObject enemyOnionPrefab;

    private void SpawnEnemyFromMap(Tilemap map)
    {
        foreach (var pos in map.cellBounds.allPositionsWithin)
        {
            if (map.HasTile(pos))
            {
                var levelTile = map.GetTile<LevelTile>(pos) ;
                if (levelTile.Type == TileType.enemyCarrot)
                {
                    Instantiate(enemyCarrotPrefab, pos, Quaternion.identity);
                }
                if (levelTile.Type == TileType.enemyOnion)
                {
                    Instantiate(enemyOnionPrefab, pos, Quaternion.identity);
                }
            }
        }
    }

    private void Start()
    {
        SpawnEnemyFromMap(enemySpawnMap);
    }
}
