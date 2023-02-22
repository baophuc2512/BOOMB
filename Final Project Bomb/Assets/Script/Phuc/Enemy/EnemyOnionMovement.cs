using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyOnionMovement : MonoBehaviour
{
    [SerializeField] private EnemySkill enemySkill;
    private Health health;
    public LayerMask wallLayer;
    public Transform movePoint;

    private void Awake()
    {
        health = GetComponent<Health>();
    }

    private void Start()
    {
        StartCoroutine(setDirection());
    }

    private void FixedUpdate()
    {
        transform.position = Vector3.MoveTowards(transform.position, movePoint.position, health.currentSpeed * Time.fixedDeltaTime);
    }

    private void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("DamageEnemy") || col.gameObject.CompareTag("DamageAll")) {
            if (col.gameObject.GetComponent<DealDamage>())
            {
                StartCoroutine(health.takeDamage(col.gameObject.GetComponent<DealDamage>().damage));
                StartCoroutine(health.slowDown(col.gameObject.GetComponent<DealDamage>().decreaseMoveSpeed, col.gameObject.GetComponent<DealDamage>().timeDeacreaseMoveSpeed));
                StartCoroutine(health.takeDamagePerSecond(col.gameObject.GetComponent<DealDamage>().damagePerSecond, col.gameObject.GetComponent<DealDamage>().timeTakeDamage));
            }
        }
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
