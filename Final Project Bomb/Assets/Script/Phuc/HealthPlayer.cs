using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthPlayer : MonoBehaviour
{
    public GameObject player;
    public Image healthBar;
    public Image healthBarFollow;
    private MoveCharacter playerMoveCharacter;

    private void Awake()
    {
        playerMoveCharacter = player.GetComponent<MoveCharacter>();
    }

    private void Update()
    {
        healthBar.fillAmount = playerMoveCharacter.currentHealth / playerMoveCharacter.maxHealth;
    }

    private void FixedUpdate()
    {
        if (healthBar.fillAmount < healthBarFollow.fillAmount)
        {
            healthBarFollow.fillAmount -= 0.01f;
        } else
        {
            healthBarFollow.fillAmount += 0.01f;
        }
    }
}
