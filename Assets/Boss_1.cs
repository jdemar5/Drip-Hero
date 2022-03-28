using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_1 : MonoBehaviour
{
    
    [SerializeField] private float attackSpeed = 1f;
    [SerializeField] private float maxHealth = 400f;

    public float speed = 3f;
    public float checkRadius;
    public float attackRadius;
    public Health_Bar healthBar;
    public LayerMask whatIsPlayer;
    public bool shouldRotate;
    public bool shouldAttack;
    public bool isHalf;

    private float health = 0f;
    private float canAttack;
    private float attackDamage = 10f;
    private Transform target;
    private Animator anim;
    private Rigidbody2D rb;
    private Vector2 movement;
    private Vector3 dir;

    public bool isInChaseRange = false;
    private bool isInAttackRange = false;

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

        if (health <= 200)
        {
            isHalf = true;
        }
        if (health <= 0)
        {
            Destroy(gameObject);
        }
        healthBar.SetHealth(health);
    }


    private void FixedUpdate(){
        
        canAttack += Time.deltaTime;
        if (shouldRotate && !isInAttackRange){ 
            float step = speed * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, target.position, step);
        }
        if(isInAttackRange){
            rb.velocity = Vector2.zero;
        }
        if(isHalf)
        {
            speed = 6f;
            attackDamage = 15f;
            anim.SetBool("belowHalf", true);
        }
    }

    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player") 
        {
            isInAttackRange =true;
            anim.SetBool("shouldAttack", true);

            if (attackSpeed <= canAttack)
            {
                other.gameObject.GetComponent<Player_Health>().UpdateHealth(-attackDamage);
                canAttack = 0f;
            }
        
        }

    }
    private void OnCollisionExit2D(Collision2D other)
    {
        isInAttackRange =false;
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
