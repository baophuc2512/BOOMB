using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBossBuffalo : MonoBehaviour
{
    private EnemySkill enemySkill;
    private Health health;
    private Rigidbody2D rb;
    private bool attackState = false;
    private Transform attackTarget;
    private int currentPhase;
    public LayerMask wallLayer;
    public Transform movePoint;
    public float detectRange;
    public float stunTime;

    private void Awake()
    {
        health = GetComponent<Health>();
        rb = GetComponent<Rigidbody2D>();
        enemySkill = GameObject.Find("Manager").GetComponent<EnemySkill>();
    }

    private void Start()
    {
        StartCoroutine(setDirection());
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Wall")
        {
            rb.velocity = new Vector2(0f, 0f);
            StartCoroutine(takeStunTime());
        }
    }

    public IEnumerator takeStunTime()
    {
        // Trong khi bi stun
        SpriteRenderer tmpSpriteRenderer = GetComponent<SpriteRenderer>();
        Color oldColor = tmpSpriteRenderer.color;
        for (int tmp = 0; tmp < 6; tmp++)
        {
            tmpSpriteRenderer.color = Color.white;
            yield return new WaitForSeconds(0.25f);
            tmpSpriteRenderer.color = oldColor;
            yield return new WaitForSeconds(0.25f);
        }
        // Tra lai ban dau
        attackState = false;
    }

    public IEnumerator setDirection()
    {
        while (true)
        {
            attackTarget = findNearestPlayer();
            if (attackTarget != null)
            {
                attackState = true;
                Vector2 moveDirection = (attackTarget.position - transform.position).normalized * health.currentSpeed;
                rb.velocity = new Vector2 (moveDirection.x, moveDirection.y);
            }
            yield return new WaitForSeconds(2f);
            while (attackState == true)
            {
                yield return new WaitForSeconds(0.1f);
            }
        }
    }

    public Transform findNearestPlayer()
    {
        List<Transform> transformList = new List<Transform>();
        Collider2D[] colliderArray = Physics2D.OverlapCircleAll(transform.position, detectRange);
        // Bo vao List de quet
        foreach (Collider2D collider in colliderArray)
        {
            if (collider.TryGetComponent(out Transform colliderTransform) && collider.tag == "Player")
            {
                transformList.Add(colliderTransform);
            }
        }
        // Tim thang gan nhat
        Transform closestTransform = null;
        foreach (Transform colliderTransform in transformList)
        {
            if (closestTransform == null)
            {
                closestTransform = colliderTransform;
            } else {
                if (Vector3.Distance(transform.position, colliderTransform.position) <
                    Vector3.Distance(transform.position, closestTransform.position))
                {
                    closestTransform = colliderTransform;
                }
            }
        }
        return closestTransform;
    }
}
