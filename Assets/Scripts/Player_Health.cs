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
        Debug.Log("player hit Health:" + health);
        if (health > maxHealth)
        {
            health = maxHealth;
        } else if (health <= 0f)
        {
            health = 0f;
            
        }
        healthBar.SetHealth(health);
    }

   
}
