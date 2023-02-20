using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public GameObject player;
    public float currentHealth;
    public float maxHealth;
    public GameObject deadAnimation;
    public float deadDuration = 1f;

    private void Awake()
    {
        if (deadAnimation.GetComponent<AnimationScript>())
        {
            AnimationScript animationScriptDead = deadAnimation.GetComponent<AnimationScript>();
            animationScriptDead.enabled = false;
        }
    }

    public IEnumerator takeDamage(float damage)
    {
        currentHealth -= damage;
        GetComponent<MoveCharacter>().modeBatTu = true;
        if (currentHealth <= 0) dead();
        Color oldColor = GetComponent<SpriteRenderer>().color;
        for (int tmp = 0; tmp <= 5; tmp++)
        {
            GetComponent<SpriteRenderer>().color = Color.white;
            yield return new WaitForSeconds(0.15f);
            GetComponent<SpriteRenderer>().color = oldColor;
            yield return new WaitForSeconds(0.15f);
        }
        GetComponent<MoveCharacter>().modeBatTu = false;

        
    }

    public void dead() 
    {
        if (GetComponent<MoveCharacter>()) GetComponent<MoveCharacter>().enabled = false;
        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<PlaceBomb>().enabled = false;
        AnimationScript animationScriptDead = deadAnimation.GetComponent<AnimationScript>();
        animationScriptDead.enabled = true;
        animationScriptDead.animationTime = deadDuration / animationScriptDead.animationSprites.Length;
        animationScriptDead.idle = false;
        
        Destroy(player, deadDuration);
    }
}