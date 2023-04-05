using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySkill : MonoBehaviour
{
    //
    public GameObject bulletPrefabs;
    //
    public GameObject poisonAreaPrefabs;
    //
    public GameObject slashPrefabs;
    public float slashDuration;
    //
    public GameObject bronzeCoinsPrefabs;
    public GameObject silverCoinsPrefabs;
    public GameObject goldCoinsPrefabs;
    //
    public GameObject skillRangeSquarePrefabs;
    public GameObject skillRangeCirclePrefabs;
    //
    public GameObject explosionPrefabs;

    public void playSkill (int type, Vector3 pos)
    {
        if (type == 1) // Ban ra 4 tia ra 4 huong
        {
            createShoot(1, pos);
            createShoot(2, pos);
            createShoot(3, pos);
            createShoot(4, pos);
        }
        if (type == 2) // Tao ra noi doc
        {
            createPoisonArea(pos);
        }
    }

    public void createPoisonArea (Vector3 pos)
    {
        GameObject poisonAreaClone = Instantiate(poisonAreaPrefabs, pos, Quaternion.identity);
    }

    public void createShoot (int dir, Vector3 pos)
    {
        GameObject bulletClone = Instantiate(bulletPrefabs, pos, Quaternion.identity);
        MovingBullet movingBullet = bulletClone.GetComponent<MovingBullet>();
        // dir == 1: left; dir == 2: right; dir == 3: up; dir == 4: down \\
        if (dir == 1)
        {
            movingBullet.directionX = 1;
            movingBullet.directionY = 0;
            movingBullet.transform.rotation = Quaternion.Euler(0, 0, -180);
        }
        if (dir == 2)
        {
            movingBullet.directionX = -1;
            movingBullet.directionY = 0;
        }
        if (dir == 3)
        {
            movingBullet.directionX = 0;
            movingBullet.directionY = 1;
            movingBullet.transform.rotation = Quaternion.Euler(0, 0, -90);
        }
        if (dir == 4)
        {
            movingBullet.directionX = 0;
            movingBullet.directionY = -1;
            movingBullet.transform.rotation = Quaternion.Euler(0, 0, 90);
        }
    }

    public void slash (int dir, Vector3 pos)
    {
        GameObject slashClone = Instantiate(slashPrefabs, pos, Quaternion.identity);
        if (dir == 1) {
            slashClone.transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        if (dir == 2) {
            slashClone.transform.rotation = Quaternion.Euler(0, 0, 90);
        }
        if (dir == 3) {
            slashClone.transform.rotation = Quaternion.Euler(0, 0, 180);
        }
        if (dir == 4) {
            slashClone.transform.rotation = Quaternion.Euler(0, 0, 270);
        }
        AnimationScript animationSlash = slashClone.GetComponent<AnimationScript>();
        animationSlash.animationTime = slashDuration / animationSlash.animationSprites.Length;
        animationSlash.idle = false;
        Destroy(slashClone, slashDuration);
    }

    public void callCreateCoin (Vector3 pos)
    {
        StartCoroutine(createCoin(pos));
    }

    public IEnumerator createCoin(Vector3 pos)
    {
        int randomCoin = Random.Range(1, 4);
        GameObject coinPrefab = null;
        if (randomCoin == 1) {
            coinPrefab = Instantiate(bronzeCoinsPrefabs, pos, Quaternion.identity);
        } else if (randomCoin == 2) {
            coinPrefab = Instantiate(silverCoinsPrefabs, pos, Quaternion.identity);
        } else {
            coinPrefab = Instantiate(goldCoinsPrefabs, pos, Quaternion.identity);
        }
        Vector2 force = new Vector2(1000 * Time.fixedDeltaTime * 5, 1000 * Time.fixedDeltaTime * 5);
        Vector2 rotatedForce = Quaternion.AngleAxis(Random.Range(-360, 360), Vector3.forward) * force;
        coinPrefab.GetComponent<Rigidbody2D>().AddForce(rotatedForce);
        yield return new WaitForSeconds(0.2f);
        coinPrefab.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
    }

    public void spawnEnemy(Vector3 pos, GameObject enemyPrefab)
    {
        Instantiate(enemyPrefab, pos, Quaternion.identity);
    }
    
    public void createRectangleArea(Vector2 posFrom, Vector2 posTo, float width, float time)
    {
    }
    
    public void createCircleArea(Vector2 pos, float radius, float time)
    {
        GameObject damageArea = Instantiate(skillRangeSquarePrefabs, pos, Quaternion.identity);
        damageArea.transform.localScale = new Vector3(radius, radius, 0);
        Destroy(damageArea, time);
    }
    
    public void buffaloHitWall(Vector2 pos, float explosionDuration)
    {
        GameObject explosionClone = Instantiate(explosionPrefabs, pos, Quaternion.identity);
        AnimationScript animationExplosion = explosionClone.GetComponent<AnimationScript>();
        animationExplosion.animationTime = explosionDuration / animationExplosion.animationSprites.Length;
        animationExplosion.idle = false;
        Destroy(explosionClone, explosionDuration);
    }

}
