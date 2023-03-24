using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySlime : MonoBehaviour
{
    private Health health;
    private Rigidbody2D rb;
    private Vector2 lastVelocity;
    private int currentPhase;
    [SerializeField] private LayerMask wallLayer;
    [SerializeField] private LayerMask groundLayer;

    private void Awake() 
    {
        health = GetComponent<Health>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        Vector2 force = new Vector2(1000 * Time.fixedDeltaTime * health.currentSpeed, 1000 * Time.fixedDeltaTime * health.currentSpeed);
        Vector2 rotatedForce = Quaternion.AngleAxis(Random.Range(-360, 360), Vector3.forward) * force;
        rb.AddForce(rotatedForce);
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
}
