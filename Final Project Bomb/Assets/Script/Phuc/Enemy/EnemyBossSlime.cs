using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBossSlime : MonoBehaviour
{
    private EnemySkill enemySkill;
    private Health health;
    private Rigidbody2D rb;
    private Vector2 lastVelocity;
    private int currentPhase;
    public float detectRange;
    [SerializeField] private LayerMask wallLayer;
    [SerializeField] private LayerMask groundLayer;

    private void Awake() 
    {
        health = GetComponent<Health>();
        rb = GetComponent<Rigidbody2D>();
        enemySkill = GameObject.Find("Manager").GetComponent<EnemySkill>();
    }

    private void Start()
    {
        Vector2 force = new Vector2(1000 * Time.fixedDeltaTime * health.currentSpeed, 1000 * Time.fixedDeltaTime * health.currentSpeed);
        Vector2 rotatedForce = Quaternion.AngleAxis(Random.Range(-360, 360), Vector3.forward) * force;
        rb.AddForce(rotatedForce);
        changePhase(1);
        StartCoroutine(checkHealthTurnPhase(50f, 2));
    }

    private void FixedUpdate()
    {
        lastVelocity = rb.velocity;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            var speed = lastVelocity.magnitude;
            var direction = Vector3.Reflect(lastVelocity.normalized, collision.contacts[0].normal);
            rb.velocity = direction * Mathf.Max(speed, 0f);
        }
    }

    public void changePhase(int phaseToChange)
    {
        currentPhase = phaseToChange;
        StartCoroutine(doSkill(phaseToChange));
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

    public IEnumerator doSkill(int type)
    {
        // Phase 1
        while (type == 1 && currentPhase == 1)
        {
            float scaleX = transform.localScale.x;
            float scaleY = transform.localScale.y;
            for (int tmp = 1; tmp <= 100; tmp++)
            {
                transform.localScale -= new Vector3 (scaleX / 100f, scaleY / 100f, 0f);
                yield return new WaitForSeconds(0.02f);
            }
            Transform target = findNearestPlayer();
            yield return new WaitForSeconds(1f);
            if (target != null) transform.position = target.position;

            Vector2 force = new Vector2(1000 * Time.fixedDeltaTime * health.currentSpeed, 1000 * Time.fixedDeltaTime * health.currentSpeed);
            Vector2 rotatedForce = Quaternion.AngleAxis(Random.Range(-360, 360), Vector3.forward) * force;
            rb.AddForce(rotatedForce);

            for (int tmp = 1; tmp <= 100; tmp++)
            {
                transform.localScale += new Vector3 (scaleX / 100f, scaleY / 100f, 0f);
                yield return new WaitForSeconds(0.02f);
            }
            yield return new WaitForSeconds(10f);
        }
        // Phase 2
        while (type == 2 && currentPhase == 2)
        {
            float scaleX = transform.localScale.x;
            float scaleY = transform.localScale.y;
            for (int tmp = 1; tmp <= 100; tmp++)
            {
                transform.localScale -= new Vector3 (scaleX / 100f, scaleY / 100f, 0f);
                yield return new WaitForSeconds(0.02f);
            }
            Transform target = findNearestPlayer();
            yield return new WaitForSeconds(1f);
            if (target != null) transform.position = target.position;
            enemySkill.playSkill(1, transform.position);

            Vector2 force = new Vector2(1000 * Time.fixedDeltaTime * health.currentSpeed, 1000 * Time.fixedDeltaTime * health.currentSpeed);
            Vector2 rotatedForce = Quaternion.AngleAxis(Random.Range(-360, 360), Vector3.forward) * force;
            rb.AddForce(rotatedForce);

            for (int tmp = 1; tmp <= 100; tmp++)
            {
                transform.localScale += new Vector3 (scaleX / 100f, scaleY / 100f, 0f);
                yield return new WaitForSeconds(0.02f);
            }
            yield return new WaitForSeconds(10f);
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
