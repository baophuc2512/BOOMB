using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCarrotMovement : MonoBehaviour
{
    [SerializeField] private EnemySkill enemySkill;
    [SerializeField] private int moveRange;
    private Health health;
    public LayerMask wallLayer;
    public LayerMask groundLayer;
    public Transform movePoint;

    private void Awake() 
    {
        health = GetComponent<Health>();
    }

    private void Start()
    {
        StartCoroutine(setDirection());
    }

    private void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("DamageEnemy") || col.gameObject.CompareTag("DamageAll")) {
            if (col.gameObject.GetComponent<DealDamage>())
            {
                StartCoroutine(health.takeDamage(col.gameObject.GetComponent<DealDamage>().damage));
            }
        }
    }

    public IEnumerator setDirection()
    {
        while (true)
        {
            int randomX = Random.Range(-moveRange - 1, moveRange);
            int randomY = Random.Range(-moveRange - 1, moveRange);

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
