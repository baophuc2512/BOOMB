using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingBullet : MonoBehaviour
{
    [SerializeField] private GameObject bullet;
    [SerializeField]private Stats stats;
    private Rigidbody2D rigidbody;
    public float moveSpeed;
    public int directionX = 0;
    public int directionY = 0;
    
    private void Awake()
    {
        stats = GetComponent<Stats>();
        rigidbody = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Wall"))
        {
            Destroy(bullet);
        }
    }

    private void FixedUpdate()
    {
        float moveStepX = moveSpeed * directionX * Time.fixedDeltaTime;
        float moveStepY = moveSpeed * directionY * Time.fixedDeltaTime;
        rigidbody.MovePosition(rigidbody.position + new Vector2 (moveStepX, moveStepY));
    }
}
