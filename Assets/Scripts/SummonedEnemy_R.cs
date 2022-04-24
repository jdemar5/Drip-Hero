using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SummonedEnemy_R : MonoBehaviour
{
    [SerializeField] private float attackSpeed = 1f;
    [SerializeField] private float maxHealth = 100f;

    public float speed = 3f;
    public float checkRadius;
    public float attackRadius;
    public Health_Bar healthBar;
    public LayerMask whatIsPlayer;
    public bool shouldRotate;
    public bool shouldAttack;
    public bool isHalf;
    public GameObject Coin;

    private float health = 0f;
    private float canAttack;
    private float attackDamage = 10f;
    private Transform target;
    private Animator anim;
    private Rigidbody2D rb;
    private Vector2 movement;
    private Vector3 dir;
    private SpriteRenderer rend;
    

    private void Start()
    {
        health = maxHealth;
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        target = GameObject.FindWithTag("Player").transform;
        // rend = GameObject.FindWithTag("EnemyBow").GetComponent<SpriteRenderer>();
    }
    
    private void Update()
    {
        anim.SetBool("shouldRotate", shouldRotate);

        dir = target.position - transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        dir.Normalize();
        movement = dir;
        
        // if( dir.y > dir.x){
        //     rend.sortingOrder = 0;
        // }
        // else{
        //     rend.sortingOrder = 2;
        // }
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
            GameObject.FindWithTag("PurpleKing").GetComponent<PurpleKing>().Spawndeath++;
            GameObject.FindWithTag("EnemyLaser").GetComponent<EnemyLaser>().Spawndeath++;
        }
        healthBar.SetHealth(health);
    }


    private void FixedUpdate(){
        
        // canAttack += Time.deltaTime;
        // if (shouldRotate && !isInAttackRange){ 
        //     float step = speed * Time.deltaTime;
        //     transform.position = Vector2.MoveTowards(transform.position, target.position, step);
        // }
        // if(isInAttackRange){
        //     rb.velocity = Vector2.zero;
        // }
    }

    private void OnCollisionStay2D(Collision2D other)
    {
    
        if (other.gameObject.tag == "Player") 
        {
            
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