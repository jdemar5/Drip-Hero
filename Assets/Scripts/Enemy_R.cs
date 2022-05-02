using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_R : MonoBehaviour
{
    [SerializeField] private float maxHealth = 100f;

    public Health_Bar healthBar;
    public bool shouldRotate;
    public bool shouldAttack;
    public GameObject Coin;

    private float health = 0f;
    private Transform target;
    private Animator anim;
    private Rigidbody2D rb;
    private Vector2 movement;
    private Vector3 dir;

    private void Start()
    {
        health = maxHealth;
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        target = GameObject.FindWithTag("Player").transform;
        
    }
    
    private void Update()
    {
        anim.SetBool("shouldRotate", shouldRotate);

        dir = target.position - transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        dir.Normalize();
        movement = dir;
        
       
        if(shouldRotate)
        {
            anim.SetFloat("X", dir.x);
            anim.SetFloat("Y", dir.y);
        }
    }


    public void takeDamage(float dmg)
    {
        health -= dmg;
        Debug.Log("Enemy Health:" + health);

        if (health <= 0)
        {
            Destroy(gameObject);
            Vector3 position = transform.position;
            Coin = Instantiate(Coin, position, Quaternion.identity);
        }
        healthBar.SetHealth(health);
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        
        anim.SetBool("shouldAttack", false);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player"){
            target = other.transform;
            shouldRotate = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
         if (other.gameObject.tag == "Player"){
            shouldRotate = false;
            target = gameObject.transform;
            rb.velocity = Vector2.zero;
        }
    }
}