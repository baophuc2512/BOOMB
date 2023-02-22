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
    private bool modeBatTu = false;

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
