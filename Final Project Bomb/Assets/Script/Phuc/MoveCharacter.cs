using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCharacter : MonoBehaviour
{
    [Header("Stats")]
    private Health health;
    private Rigidbody2D rigidbody;
    [Header("Input Keyboard")]
    public KeyCode inputUp = KeyCode.W;
    public KeyCode inputDown = KeyCode.S;
    public KeyCode inputLeft = KeyCode.A;
    public KeyCode inputRight = KeyCode.D;
    [Header("Animation")]
    public GameObject player;
    private int directionX = 0;
    private int directionY = 0;
    
    private void Awake() 
    {
        rigidbody = GetComponent<Rigidbody2D>();
        health = GetComponent<Health>();
    }

    private void Update() 
    {
        if (Input.GetKey(inputUp)) {
            directionX = 0;
            directionY = 1;
        }
        else if (Input.GetKey(inputDown)) {
            directionX = 0;
            directionY = -1;
        }
        else if (Input.GetKey(inputLeft)) {
            directionX = -1;
            directionY = 0;
        }
        else if (Input.GetKey(inputRight)) {
            directionX = 1;
            directionY = 0;
        }
        else {
            directionX = 0;
            directionY = 0;
        }
    }
    private void FixedUpdate() 
    {
        float moveStepX = health.currentSpeed * directionX * Time.fixedDeltaTime;
        float moveStepY = health.currentSpeed * directionY * Time.fixedDeltaTime;
        rigidbody.MovePosition(rigidbody.position + new Vector2 (moveStepX + 0.00000005f, moveStepY));
    }
    
    private void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("DamagePlayer") || col.gameObject.CompareTag("DamageAll")) {
            if (col.gameObject.GetComponent<DealDamage>())
            {
                StartCoroutine(health.takeDamage(col.gameObject.GetComponent<DealDamage>().damage));
                StartCoroutine(health.slowDown(col.gameObject.GetComponent<DealDamage>().decreaseMoveSpeed, col.gameObject.GetComponent<DealDamage>().timeDeacreaseMoveSpeed));
                StartCoroutine(health.takeDamagePerSecond(col.gameObject.GetComponent<DealDamage>().damagePerSecond, col.gameObject.GetComponent<DealDamage>().timeTakeDamage));
            }
        }
    }
}
