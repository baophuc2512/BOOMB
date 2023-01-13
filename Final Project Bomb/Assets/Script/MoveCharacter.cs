using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCharacter : MonoBehaviour
{
    [Header("Stats")]
    public float moveSpeed = 10f;
    public float deadDuration = 1f;
    private Rigidbody2D rigidbody;
    [Header("Input Keyboard")]
    public KeyCode inputUp = KeyCode.W;
    public KeyCode inputDown = KeyCode.S;
    public KeyCode inputLeft = KeyCode.A;
    public KeyCode inputRight = KeyCode.D;
    [Header("Animation")]
    public GameObject player;
    public GameObject deadAnimation;
    private int directionX = 0;
    private int directionY = 0;
    
    private void Awake() 
    {
        AnimationScript animationScriptDead = deadAnimation.GetComponent<AnimationScript>();
        animationScriptDead.enabled = false;
        rigidbody = GetComponent<Rigidbody2D>();
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
        float moveStepX = moveSpeed * directionX * Time.fixedDeltaTime;
        float moveStepY = moveSpeed * directionY * Time.fixedDeltaTime;
        rigidbody.MovePosition(rigidbody.position + new Vector2 (moveStepX, moveStepY));
    }
    
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Enemy") || col.CompareTag("Explosion")) {
            enabled = false;
            SpriteRenderer playerSpriteRenderer = GetComponent<SpriteRenderer>();
            playerSpriteRenderer.enabled = false;
            AnimationScript animationScriptDead = deadAnimation.GetComponent<AnimationScript>();
            animationScriptDead.enabled = true;
            animationScriptDead.animationTime = deadDuration / animationScriptDead.animationSprites.Length;
            animationScriptDead.idle = false;
            Destroy(player, deadDuration);
        }
    }
}
