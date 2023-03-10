using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public GameObject player;
    public float currentHealth;
    public float currentSpeed;
    public float maxHealth;
    public GameObject deadAnimation;
    public float deadDuration = 1f;
    private bool modeBatTu = false;
    private bool modeNoSlowDown = false;
    private bool modeNoTakeDamagePerSecond = false;
    private bool modeNoTakeStun = false;

    private void Awake()
    {
        if (deadAnimation.GetComponent<AnimationScript>())
        {
            AnimationScript animationScriptDead = deadAnimation.GetComponent<AnimationScript>();
            animationScriptDead.enabled = false;
        }
    }

    private void OnTriggerStay2D(Collider2D col)
    {
        if ((col.gameObject.CompareTag("DamageEnemy") && player.CompareTag("Enemy"))
        || (col.gameObject.CompareTag("DamagePlayer") && player.CompareTag("Player"))
        || col.gameObject.CompareTag("DamageAll")) {
            if (col.gameObject.GetComponent<DealDamage>())
            {
                StartCoroutine(takeDamage(col.gameObject.GetComponent<DealDamage>().damage));
                StartCoroutine(slowDown(col.gameObject.GetComponent<DealDamage>().decreaseMoveSpeed, col.gameObject.GetComponent<DealDamage>().timeDeacreaseMoveSpeed));
                StartCoroutine(takeDamagePerSecond(col.gameObject.GetComponent<DealDamage>().damagePerSecond, col.gameObject.GetComponent<DealDamage>().timeTakeDamage));
                StartCoroutine(takeStun(col.gameObject.GetComponent<DealDamage>().stun, col.gameObject.GetComponent<DealDamage>().timeStun));
            }
        }
    }

    public IEnumerator takeDamage(float damage)
    {
        if (damage != 0)
        {
            if (modeBatTu == false)
            {
                currentHealth -= damage;
                modeBatTu = true;
                if (currentHealth <= 0) dead();
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
        }
        
    }

    public IEnumerator slowDown(float speed, float time)
    {
        if (speed != 0 && time != 0)
        {
            if (modeNoSlowDown == false)
            {
                currentSpeed -= speed;
                modeNoSlowDown = true;
                yield return new WaitForSeconds(time);
                currentSpeed += speed;
                modeNoSlowDown = false;
            }
        }
    }

    public IEnumerator takeDamagePerSecond(float damage, float time)
    {
        if (damage != 0 && time != 0)
        {
            if (modeNoTakeDamagePerSecond == false)
            {
                modeNoTakeDamagePerSecond = true;
                while (time > 0)
                {
                    currentHealth -= damage;
                    yield return new WaitForSeconds(1f);
                    time -= 1f;
                }
                modeNoTakeDamagePerSecond = false;
            } 
            
        }
    }

    public IEnumerator takeStun(bool stun, float time)
    {
        if (stun != false && time != 0)
        {
            if (modeNoTakeStun == false)
            {
                modeNoTakeStun = true;
                if (GetComponent<MoveCharacter>()) GetComponent<MoveCharacter>().enabled = false;
                if (GetComponent<PlaceBomb>()) GetComponent<PlaceBomb>().enabled = false;
                if (GetComponent<EnemyCarrotMovement>()) GetComponent<EnemyCarrotMovement>().enabled = false;
                if (GetComponent<EnemyOnionMovement>()) GetComponent<EnemyOnionMovement>().enabled = false;
                Color oldColor = GetComponent<SpriteRenderer>().color;
                for (int tmp = 0; tmp <= time/0.15f; tmp++)
                {
                    GetComponent<SpriteRenderer>().color = Color.yellow;
                    yield return new WaitForSeconds(0.15f);
                    GetComponent<SpriteRenderer>().color = oldColor;
                    yield return new WaitForSeconds(0.15f);
                }
                if (GetComponent<MoveCharacter>()) GetComponent<MoveCharacter>().enabled = true;
                if (GetComponent<PlaceBomb>()) GetComponent<PlaceBomb>().enabled = true;
                if (GetComponent<EnemyCarrotMovement>()) GetComponent<EnemyCarrotMovement>().enabled = true;
                if (GetComponent<EnemyOnionMovement>()) GetComponent<EnemyOnionMovement>().enabled = true;
                yield return new WaitForSeconds(1f);
                modeNoTakeStun = false;
            }
        }
    }

    public void dead() 
    {
        Destroy(player, deadDuration);
        if (GetComponent<MoveCharacter>()) GetComponent<MoveCharacter>().enabled = false;
        if (GetComponent<SpriteRenderer>()) GetComponent<SpriteRenderer>().enabled = false;
        if (GetComponent<PlaceBomb>()) GetComponent<PlaceBomb>().enabled = false;
        if (deadAnimation.GetComponent<AnimationScript>())
        {
            AnimationScript animationScriptDead = deadAnimation.GetComponent<AnimationScript>();
            animationScriptDead.enabled = true;
            animationScriptDead.animationTime = deadDuration / animationScriptDead.animationSprites.Length;
            animationScriptDead.idle = false;
        }
    }
}
