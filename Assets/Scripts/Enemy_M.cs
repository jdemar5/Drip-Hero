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



    public float checkRadius;
    public float attackRadius;
    public LayerMask whatIsPlayer;
    public bool shouldRotate;

    private Animator anim;
    private Rigidbody2D rb;
    private Vector2 movement;
    private Vector3 dir;

    public bool isInChaseRange = false;
    private bool isInAttackRange;

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

        isInChaseRange = Physics2D.OverlapCircle(transform.position, checkRadius, whatIsPlayer);
        isInAttackRange = Physics2D.OverlapCircle(transform.position, attackRadius, whatIsPlayer);

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
        }
        healthBar.SetHealth(health);
    }


    private void FixedUpdate(){
        if (shouldRotate){
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