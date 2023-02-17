using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBombMovement : MonoBehaviour
{
    public float moveSpeed;
    public LayerMask wallLayer;
    public Transform movePoint;

    private void Start()
    {
        InvokeRepeating("setDirection", 0.5f, 0.5f);
    }

    private void FixedUpdate()
    {
        transform.position = Vector3.MoveTowards(transform.position, movePoint.position, moveSpeed * Time.fixedDeltaTime);
    }

    public void setDirection()
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
    }
}
