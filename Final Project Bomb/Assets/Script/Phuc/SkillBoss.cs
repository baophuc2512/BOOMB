using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillBoss : MonoBehaviour
{
    public GameObject explosionPrefabs;
    public int explosionRadius;
    public float explosionDuration;
    public LayerMask wallLayer;


    public void activeSkill (int typeSkill)
    {
        Vector2 positionBoss = new Vector2(transform.position.x, transform.position.y);
        positionBoss.x = Mathf.Round(positionBoss.x);
        positionBoss.y = Mathf.Round(positionBoss.y);
        switch (typeSkill)
        {
            case 1:
                StartCoroutine(skillFirst(positionBoss));
                break;
            case 2:
                break;
            case 3:
                break;
            case 4:
                break;
            case 5:
                break;
            case 6:
                break;
        }
    }

    public IEnumerator skillFirst(Vector2 positionExplose)
    {
        // No Chinh Giua
        createExplose(positionExplose);
        // No Cac Huong Con Lai
        bool tmpKey1, tmpKey2, tmpKey3, tmpKey4;
        tmpKey1 = tmpKey2 = tmpKey3 = tmpKey4 = true;
        Vector2 position;
        for (int tmp = 1; tmp <= explosionRadius; tmp++) 
        {
            position.x = positionExplose.x - tmp;
            position.y = positionExplose.y;
            if (Physics2D.OverlapBox(position, Vector2.one / 2f, 0f, wallLayer))
            {
                tmpKey1 = false;
            }
            if (tmpKey1 == true)
            createExplose(position);
            //-----------------------------------------------------
            position.x = positionExplose.x + tmp;
            position.y = positionExplose.y;
            if (Physics2D.OverlapBox(position, Vector2.one / 2f, 0f, wallLayer))
            {
                tmpKey2 = false;
            }
            if (tmpKey2 == true)
            createExplose(position);
            //-----------------------------------------------------
            position.x = positionExplose.x;
            position.y = positionExplose.y + tmp;
            if (Physics2D.OverlapBox(position, Vector2.one / 2f, 0f, wallLayer))
            {
                tmpKey3 = false;
            }
            if (tmpKey3 == true)
            createExplose(position);
            //-----------------------------------------------------
            position.x = positionExplose.x;
            position.y = positionExplose.y - tmp;
            if (Physics2D.OverlapBox(position, Vector2.one / 2f, 0f, wallLayer))
            {
                tmpKey4 = false;
            }
            if (tmpKey4 == true)
            createExplose(position);
            //-----------------------------------------------------
            yield return new WaitForSeconds(0.5f);
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
}
