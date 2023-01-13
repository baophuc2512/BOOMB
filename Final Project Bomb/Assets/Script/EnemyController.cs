using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float moveSpeed = 10f;
    private Rigidbody2D rigidbody;
    private int enemyDirectionX = 0;
    private int enemyDirectionY = 0;
    private Vector2 oldPosition;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        setDirection();
    }
    
    private void FixedUpdate()
    {
        float moveStepX = moveSpeed * enemyDirectionX * Time.fixedDeltaTime;
        float moveStepY = moveSpeed * enemyDirectionY * Time.fixedDeltaTime;
        rigidbody.MovePosition(rigidbody.position + new Vector2 (moveStepX, moveStepY));
        if (oldPosition == rigidbody.position) setDirection();
        else oldPosition = rigidbody.position;
    }

    public void setDirection() 
    {
        int kind = Random.Range(1, 5);
        if (kind == 1) // Sang phai
        {
            enemyDirectionX = -1;
            enemyDirectionY = 0;
        }
        if (kind == 2) // Sang trai
        {
            enemyDirectionX = 1;
            enemyDirectionY = 0;
        }
        if (kind == 3) // Len tren
        {
            enemyDirectionX = 0;
            enemyDirectionY = 1;
        }
        if (kind == 4) // Xuong duoi
        {
            enemyDirectionX = 0;
            enemyDirectionY = -1;
        }
    }
}
