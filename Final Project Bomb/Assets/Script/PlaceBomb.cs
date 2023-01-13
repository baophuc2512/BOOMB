using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlaceBomb : MonoBehaviour
{
    [Header("Bomb")]
    public GameObject bombPrefabs;
    public KeyCode inputPlaceBomb = KeyCode.Space;
    public int amountBomb = 2;
    public float timeExplose = 2f;

    [Header("Explose")]
    public GameObject explosionPrefabs;
    public LayerMask wallLayer;
    public int explosionRadius = 2;
    public float explosionDuration = 1f;

    [Header("Destructible")]
    public GameObject destructiblesPrefabs;
    public Tilemap destructiblesTiles;
    public float destructiblesDuration = 1f;
    
    private void Update() 
    {
        // Dat bomb khi duoc Input
        if (amountBomb > 0 && Input.GetKeyDown(inputPlaceBomb)) 
        {
            Vector2 positionSprite = transform.position;
            positionSprite.x = Mathf.Round(positionSprite.x);
            positionSprite.y = Mathf.Round(positionSprite.y - 0.125f);
            if (Physics2D.OverlapBox(positionSprite, Vector2.one / 2f, 0f, wallLayer) == false)
            {
                StartCoroutine(placeBomb(positionSprite));
            }
            
        }
    }

    public IEnumerator placeBomb(Vector2 position) 
    {
        // Xu ly Bomb
        GameObject bombClone = Instantiate(bombPrefabs, new Vector2(position.x, position.y), Quaternion.identity);
        amountBomb--;

        yield return new WaitForSeconds(timeExplose);

        // Xu ly Explose
        Vector2 positionBomb = new Vector2(position.x, position.y);
        explose(positionBomb);

        // Delete sau khi Explose
        amountBomb++;
        Destroy(bombClone);
        
    } 

    public void explose(Vector2 positionExplose)
    {
        Vector2 position;
        // No chinh giua
        createExplose(positionExplose);
        // No sang trai
        for (int tmp = 1; tmp <= explosionRadius; tmp++) 
        {
            position.x = positionExplose.x - tmp;
            position.y = positionExplose.y;
            if (Physics2D.OverlapBox(position, Vector2.one / 2f, 0f, wallLayer))
            {
                createWallBreak(position);
                break;
            }
            createExplose(position);
        }
        // No sang phai
        for (int tmp = 1; tmp <= explosionRadius; tmp++) 
        {
            position.x = positionExplose.x + tmp;
            position.y = positionExplose.y;
            if (Physics2D.OverlapBox(position, Vector2.one / 2f, 0f, wallLayer))
            {
                createWallBreak(position);
                break;
            }
            createExplose(position);
        }
        // No len tren
        for (int tmp = 1; tmp <= explosionRadius; tmp++) 
        {
            position.x = positionExplose.x;
            position.y = positionExplose.y + tmp;
            if (Physics2D.OverlapBox(position, Vector2.one / 2f, 0f, wallLayer))
            {
                createWallBreak(position);
                break;
            }
            createExplose(position);
        }
        // No xuong duoi
        for (int tmp = 1; tmp <= explosionRadius; tmp++) 
        {
            position.x = positionExplose.x;
            position.y = positionExplose.y - tmp;
            if (Physics2D.OverlapBox(position, Vector2.one / 2f, 0f, wallLayer))
            {
                createWallBreak(position);
                break;
            }
            createExplose(position);
        }
    }

    public void createExplose(Vector2 positionExplose) 
    {
        GameObject explosionClone = Instantiate(explosionPrefabs, positionExplose, Quaternion.identity);
        AnimationScript animationExplosion = explosionClone.GetComponent<AnimationScript>();
        animationExplosion.animationTime = explosionDuration / animationExplosion.animationSprites.Length;
        animationExplosion.idle = false;
        Destroy(explosionClone, explosionDuration);
    }

    public void createWallBreak(Vector2 positionBreak)
    {
        Vector3Int cell = destructiblesTiles.WorldToCell(positionBreak);
        TileBase tile = destructiblesTiles.GetTile(cell);

        if (tile != null)
        {
            destructiblesTiles.SetTile(cell, null);
            GameObject destructiblesClone = Instantiate(destructiblesPrefabs, positionBreak, Quaternion.identity);
            AnimationScript destructiblesAnimation = destructiblesClone.GetComponent<AnimationScript>();
            destructiblesAnimation.animationTime = destructiblesDuration / destructiblesAnimation.animationSprites.Length;
            destructiblesAnimation.idle = false;
            Destroy(destructiblesClone, destructiblesDuration);
        }
    }
}
