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
    private Vector2 lastVelocity;
    public LayerMask wallLayer;
    public Transform movePoint;
    public float detectRange;
    public GameObject spawnStonePrefab;

    public Sprite spriteIdle;
    public Sprite spriteCharge;

    private void Awake()
    {
        health = GetComponent<Health>();
        rb = GetComponent<Rigidbody2D>();
        enemySkill = GameObject.Find("Manager").GetComponent<EnemySkill>();
    }

    private void Start()
    {
        changePhase(1);
        StartCoroutine(checkHealthTurnPhase(50f, 2));
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Wall")
        {
            rb.velocity = new Vector2(0f, 0f);
            GetComponent<SpriteRenderer>().sprite = spriteIdle;
            StartCoroutine(takeStunTime());
            enemySkill.buffaloHitWall(transform.position, 2f);

            var speed = lastVelocity.magnitude;
            var direction = Vector3.Reflect(lastVelocity.normalized, col.contacts[0].normal);
            rb.velocity = direction * Mathf.Max(speed / 100, 0f);
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

    public IEnumerator setDirection(int type)
    {
        // ---------------- PHASE 1
        while (type == 1 && currentPhase == 1)
        {
            attackTarget = findNearestPlayer();
            if (attackTarget != null)
            {
                attackState = true;
                GetComponent<SpriteRenderer>().sprite = spriteCharge;
                Vector2 moveDirection = (attackTarget.position - transform.position).normalized * health.currentSpeed;
                rb.velocity = new Vector2 (moveDirection.x, moveDirection.y);
                if (rb.velocity.x > 0) GetComponent<SpriteRenderer>().flipX = true;
                else GetComponent<SpriteRenderer>().flipX = false;
            }
            yield return new WaitForSeconds(2f);
            while (attackState == true)
            {
                yield return new WaitForSeconds(0.1f);
            }
        }
        // ---------------- PHASE 2
        while (type == 2 && currentPhase == 2)
        {
            if (Random.Range(1, 3) == 1)
            {
                attackTarget = findNearestPlayer();
                if (attackTarget != null)
                {
                    attackState = true;
                    GetComponent<SpriteRenderer>().sprite = spriteCharge;
                    Vector2 moveDirection = (attackTarget.position - transform.position).normalized * health.currentSpeed;
                    rb.velocity = new Vector2 (moveDirection.x, moveDirection.y);
                    if (rb.velocity.x > 0) GetComponent<SpriteRenderer>().flipX = true;
                    else GetComponent<SpriteRenderer>().flipX = false;
                }
                yield return new WaitForSeconds(2f);
            } else {
                attackTarget = findNearestPlayer();
                if (attackTarget != null)
                {
                    Vector3 tmpPosition = attackTarget.position;
                    attackState = true;
                    enemySkill.createCircleArea(tmpPosition, 2f, 1.5f);
                    yield return new WaitForSeconds(1.5f);
                    if (spawnStonePrefab != null) Instantiate(spawnStonePrefab, tmpPosition, Quaternion.identity);
                    attackState = false;
                }
            }
            while (attackState == true)
            {
                yield return new WaitForSeconds(0.1f);
            }
        }
    }

    public void changePhase(int phaseToChange)
    {
        currentPhase = phaseToChange;
        StartCoroutine(setDirection(phaseToChange));
    }

    public IEnumerator checkHealthTurnPhase(float percentHealth, int phaseToChange)
    {
        while (true)
        {
            if (health.currentHealth / health.maxHealth <= percentHealth / 100f)
            {
                changePhase(phaseToChange);
                break;
            }
            yield return new WaitForSeconds(0.2f);
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
