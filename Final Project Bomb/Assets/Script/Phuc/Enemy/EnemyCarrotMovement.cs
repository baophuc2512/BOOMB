using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCarrotMovement : MonoBehaviour
{
    [SerializeField] private EnemySkill enemySkill;
    public int moveRange;
    public LayerMask wallLayer;
    public LayerMask groundLayer;
    public Transform movePoint;
    public GameObject testPrefab;

    private void Start()
    {
        StartCoroutine(setDirection());
    }

    public IEnumerator setDirection()
    {
        while (true)
        {
            int randomX = Random.Range(-moveRange - 1, moveRange);
            int randomY = Random.Range(-moveRange - 1, moveRange);
            Vector3 oldPos = movePoint.position;
            if (Physics2D.OverlapBox(movePoint.position + new Vector3(randomX, randomY, 0f), Vector2.one / 5f, 0f, groundLayer)
            && !Physics2D.OverlapBox(movePoint.position + new Vector3(randomX, randomY, 0f), Vector2.one / 5f, 0f, wallLayer))
            {
                movePoint.position += new Vector3(randomX, randomY, 0f);
            }

            transform.position = movePoint.position;
            
            yield return new WaitForSeconds(2f);

            enemySkill.playSkill(1, transform.position);

            yield return new WaitForSeconds(2f);
        }
        
    }
}
