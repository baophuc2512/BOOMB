using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
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
    public AnimationScript moveLeft;
    public AnimationScript moveRight;
    private SpriteRenderer spriteRenderer;
    private int directionX = 0;
    private int directionY = 0;
    
    private void Awake() 
    {
        rigidbody = GetComponent<Rigidbody2D>();
        health = GetComponent<Health>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update() 
    {
        if (Input.GetKey(inputUp)) {
            directionX = 0;
            directionY = 1;
            moveLeft.enabled = true;
            moveRight.enabled = false;
            spriteRenderer.enabled = false;
        }
        else if (Input.GetKey(inputDown)) {
            directionX = 0;
            directionY = -1;
            moveLeft.enabled = false;
            moveRight.enabled = true;
            spriteRenderer.enabled = false;
        }
        else if (Input.GetKey(inputLeft)) {
            directionX = -1;
            directionY = 0;
            moveLeft.enabled = false;
            moveRight.enabled = true;
            spriteRenderer.enabled = false;
        }
        else if (Input.GetKey(inputRight)) {
            directionX = 1;
            directionY = 0;
            moveLeft.enabled = true;
            moveRight.enabled = false;
            spriteRenderer.enabled = false;
        }
        else {
            directionX = 0;
            directionY = 0;
            moveLeft.enabled = false;
            moveRight.enabled = false;
            spriteRenderer.enabled = true;
        }
    }
    private void FixedUpdate() 
    {
        float moveStepX = health.currentSpeed * directionX * Time.fixedDeltaTime;
        float moveStepY = health.currentSpeed * directionY * Time.fixedDeltaTime;
        rigidbody.MovePosition(rigidbody.position + new Vector2 (moveStepX + 0.00000005f, moveStepY));
    }
}
