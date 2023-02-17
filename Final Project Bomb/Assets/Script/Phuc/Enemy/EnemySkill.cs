using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySkill : MonoBehaviour
{
    public GameObject bulletPrefabs;
    public GameObject poisonAreaPrefabs;

    public void playSkill (int type, Vector3 pos)
    {
        if (type == 1)
        {
            createShoot(1, pos);
            createShoot(2, pos);
            createShoot(3, pos);
            createShoot(4, pos);
        }
        if (type == 2)
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
            movingBullet.transform.rotation = Quaternion.Euler(0, 0, 90);
        }
        if (dir == 4)
        {
            movingBullet.directionX = 0;
            movingBullet.directionY = -1;
            movingBullet.transform.rotation = Quaternion.Euler(0, 0, -90);
        }
    }
}
