using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCharacter : MonoBehaviour
{
    [Header("Stats")]
    public float moveSpeed = 10f;
    public float deadDuration = 1f;
    public float maxHealth = 100;
    public float currentHealth = 100;
    public bool modeBatTu = false;
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
        if ((col.CompareTag("Enemy") || col.CompareTag("Explosion") || col.gameObject.CompareTag("ExplosionBoss")) && modeBatTu == false) {
            StartCoroutine(takeDamage(10));
            if (currentHealth <= 0) dead();
        }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Enemy") || col.gameObject.CompareTag("Explosion") || col.gameObject.CompareTag("ExplosionBoss") && modeBatTu == false) {
            StartCoroutine(takeDamage(10));
            if (currentHealth <= 0) dead();
        }
    }

    public IEnumerator takeDamage(int damage)
    {
        currentHealth -= damage;
        modeBatTu = true;
        Color oldColor = GetComponent<SpriteRenderer>().color;
        for (int tmp = 0; tmp <= 5; tmp++)
        {
            GetComponent<SpriteRenderer>().color = Color.white;
            yield return new WaitForSeconds(0.15f);
            GetComponent<SpriteRenderer>().color = oldColor;
            yield return new WaitForSeconds(0.15f);
        }
        modeBatTu = false;
    }

    public void dead() 
    {
        enabled = false;
        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<PlaceBomb>().enabled = false;
        AnimationScript animationScriptDead = deadAnimation.GetComponent<AnimationScript>();
        animationScriptDead.enabled = true;
        animationScriptDead.animationTime = deadDuration / animationScriptDead.animationSprites.Length;
        animationScriptDead.idle = false;
        
        Destroy(player, deadDuration);
    }
}