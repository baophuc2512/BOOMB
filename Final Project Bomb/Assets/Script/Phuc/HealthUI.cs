using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour
{
    public GameObject gameObject;
    public Image healthBar;
    public Image healthBarFollow;
    private Health health;

    private void Awake()
    {
        health = gameObject.GetComponent<Health>();
    }

    private void Update()
    {
        healthBar.fillAmount = health.currentHealth / health.maxHealth;
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
