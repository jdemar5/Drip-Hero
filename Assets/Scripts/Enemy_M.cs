using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_M : MonoBehaviour
{
    public float speed = 3f;
    private float attackDamage = 10f;
    [SerializeField] private float attackSpeed = 1f;
    private float canAttack;

 
    private Transform target;

    public Health_Bar healthBar;
 
    private float health = 0f;
    [SerializeField] private float maxHealth = 100f;

    private void Start() 
    {
        health = maxHealth;
    }

    public void takeDamage(float dmg)
    {
        health -= dmg;
        Debug.Log("Enemy Health:" + health);

        if (health <= 0)
        {
            Destroy(gameObject);
        }
        healthBar.SetHealth(health);
    }


    private void FixedUpdate(){
        if (target != null){
            float step = speed * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, target.position, step);
        }
    }

    private void OnCollisionStay2D(Collision2D other)
    {
       

        if (other.gameObject.tag == "Player") 
        {
            if (attackSpeed <= canAttack)
            {
                other.gameObject.GetComponent<Player_Health>().UpdateHealth(-attackDamage);
                canAttack = 0f;
            } else 
            {
                canAttack += Time.deltaTime;
            }
           
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player"){
            target = other.transform;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
         if (other.gameObject.tag == "Player"){
            target = null;
        }
    }
}
