#if UNITY_EDITOR

using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TilemapManager : MonoBehaviour
{
    [SerializeField] private Tilemap groundMap, destructableMap, indestructableMap, enemySpawnMap;
    [SerializeField] private int levelIndex;
    [SerializeField] private ScriptableData dataLoad;

    private void Start()
    {
        levelIndex = dataLoad.levelMap;
        loadMap();
    }

    public void saveMap()
    {
        var newLevel = ScriptableObject.CreateInstance<ScriptableLevel>();

        newLevel.LevelIndex = levelIndex;
        newLevel.name = $"Level {levelIndex}";

        newLevel.groundTiles = GetTilesFromMap(groundMap).ToList();
        newLevel.destructableTiles = GetTilesFromMap(destructableMap).ToList();
        newLevel.indestructableTiles = GetTilesFromMap(indestructableMap).ToList();
        newLevel.enemySpawnTiles = GetTilesFromMap(enemySpawnMap).ToList();

        ScriptableObjectUtility.SaveLevelFile(newLevel);

        IEnumerable<SavedTile> GetTilesFromMap(Tilemap map)
        {
            foreach (var pos in map.cellBounds.allPositionsWithin)
            {
                if (map.HasTile(pos))
                {
                    var levelTile = map.GetTile<LevelTile>(pos) ;
                    yield return new SavedTile()
                    {
                        position = pos,
                        tile = levelTile,
                    };
                }
            }
        }
    }

    public void clearMap()
    {
        var maps = FindObjectsOfType<Tilemap>();

        foreach (var tilemap in maps)
        {
            tilemap.ClearAllTiles();
        }
    }

    public void loadMap()
    {
        var level = Resources.Load<ScriptableLevel>($"Levels/Level {levelIndex}");
        if (level == null)
        {
            Debug.LogError($"Không tồn tại để load: Level {levelIndex}");
            return;
        }

        clearMap();

        foreach (var savedTile in level.groundTiles)
        {
            if (savedTile.tile.Type == TileType.grass)
                groundMap.SetTile(savedTile.position, savedTile.tile);
        }
        foreach (var savedTile in level.destructableTiles)
        {
            if (savedTile.tile.Type == TileType.wallBreakable)
                destructableMap.SetTile(savedTile.position, savedTile.tile);
        }
        foreach (var savedTile in level.indestructableTiles)
        {
            if (savedTile.tile.Type == TileType.wallUnbreakable)
                indestructableMap.SetTile(savedTile.position, savedTile.tile);
        }
        foreach (var savedTile in level.enemySpawnTiles)
        {
            if (savedTile.tile.Type == TileType.enemyCarrot
            || savedTile.tile.Type == TileType.enemyOnion)
                enemySpawnMap.SetTile(savedTile.position, savedTile.tile);
        }
    }
}



public static class ScriptableObjectUtility
{
    public static void SaveLevelFile(ScriptableLevel level) 
    {
        AssetDatabase.CreateAsset(level, $"Assets/Resources/Levels/{level.name}.asset");
        AssetDatabase.SaveAssets();
        AssetDatabase.Refresh();
    }
}

#endif