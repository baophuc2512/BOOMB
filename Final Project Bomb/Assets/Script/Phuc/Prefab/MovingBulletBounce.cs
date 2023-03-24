using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingBulletBounce : MonoBehaviour
{
    private Rigidbody2D rb;
    private Vector2 lastVelocity;
    [SerializeField] private float speed;

    private void Awake() 
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        Vector2 force = new Vector2(200 * Time.fixedDeltaTime * speed, 200 * Time.fixedDeltaTime * speed);
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
