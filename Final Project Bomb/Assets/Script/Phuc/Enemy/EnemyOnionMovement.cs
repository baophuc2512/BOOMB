using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyOnionMovement : MonoBehaviour
{
    [SerializeField] private EnemySkill enemySkill;
    public float moveSpeed;
    public LayerMask wallLayer;
    public Transform movePoint;

    private void Start()
    {
        StartCoroutine(setDirection());
    }

    private void FixedUpdate()
    {
        transform.position = Vector3.MoveTowards(transform.position, movePoint.position, moveSpeed * Time.fixedDeltaTime);
    }

    public IEnumerator setDirection()
    {
        while (true)
        {
            int kind = Random.Range(1, 5);
            Vector3 oldPos = movePoint.position;
            if (kind == 1) // Sang phai
            {
                movePoint.position += new Vector3(1f, 0f, 0f);
            }
            if (kind == 2) // Sang trai
            {
                movePoint.position += new Vector3(-1f, 0f, 0f);
            }
            if (kind == 3) // Len tren
            {
                movePoint.position += new Vector3(0f, 1f, 0f);
            }
            if (kind == 4) // Xuong duoi
            {
                movePoint.position += new Vector3(0f, -1f, 0f);
            }
            if (Physics2D.OverlapBox(movePoint.position, Vector2.one / 5f, 0f, wallLayer))
            {
                movePoint.position = oldPos;
            }

            yield return new WaitForSeconds(2f);
            
            enemySkill.playSkill(2, transform.position);
        }
    }

}
