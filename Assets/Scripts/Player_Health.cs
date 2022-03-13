using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Health : MonoBehaviour
{
    public Health_Bar healthBar;
 
    private float health = 0f;
    [SerializeField] private float maxHealth = 100f;

    private void Start()
    {
        health = maxHealth;
    }

    public void UpdateHealth(float mod)
    {
        health += mod;

        if (health > maxHealth)
        {
            health = maxHealth;
        } else if (health <= 0f)
        {
            health = 0f;
            
        }
        healthBar.SetHealth(health);
    }

    // public float maxHealth = 100;
    // public float currentHealth;
    // void Start()
    // {
    //     currentHealth = maxHealth;
    //     healthBar.SetmaxHealth(maxHealth);
    // }

    // void Update()
    // {
    //     if (Input.GetKeyDown(KeyCode.Space))
    //     {
    //         TakeDamage(20);
    //     }
    // }

    // void TakeDamage(float damage)
    // {
    //     currentHealth -= damage;

    //     healthBar.SetHealth(currentHealth);
    // }
}
