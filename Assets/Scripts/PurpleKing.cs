using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PurpleKing : MonoBehaviour
{
    
    [SerializeField] private float maxHealth = 400f;
    

    public float speed = 3f;
    public float checkRadius;
    public float attackRadius;
    public float SpawnNum= 0f;
    public float Spawndeath= 0f;
    public Health_Bar healthBar;
    public LayerMask whatIsPlayer;
    public bool shouldRotate;
    public bool shouldAttack;
    public bool isHalf;
    public bool isFiring;
    public GameObject Coin;
    public GameObject Enemy_Child1;
    public GameObject Enemy_Child2;
    public Transform SpawnPoint1;
    public Transform SpawnPoint2;
    public float divNum= 3f;
    public bool Phase1;
    public bool Phase2;
    public bool Phase3;
    private float health = 0f;
    private float canAttack;
    public float attackDelay;
    public Transform target;
    private Animator anim;
    private Rigidbody2D rb;
    private Vector2 movement;
    private Vector3 dir;
    


    public bool isInChaseRange = false;
    private bool isInAttackRange = false;

    private AudioSource audioSource;

    private void Start()
    {
        health = maxHealth;
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        target = GameObject.FindWithTag("Player").transform;
        audioSource = GameObject.Find("DeathAudio").GetComponent<AudioSource>();
        Phase1 = true;
        Phase2 = false;
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



    private void FixedUpdate(){
        
        if(Spawndeath>5)
        {
            Phase1= false;
            Phase2 = true;
        }
        if(health<200)
        {
            Phase2= false;
            Phase3 = true;
        }
        if(Phase1)
        {
            health = maxHealth;
        }
        else if(Phase2){
            canAttack += Time.deltaTime;
            if (shouldRotate && !isInAttackRange){ 
                float step = speed * Time.deltaTime;
                transform.position = Vector2.MoveTowards(transform.position, target.position, step);
            }
            if(isInAttackRange){
                rb.velocity = Vector2.zero;
            }
            
        }
        else if(Phase3)
        {
            anim.SetBool("fallingDown", true);
            anim.SetBool("laserStart", true);
        }
    }

    public void SpawnEnemy()
    {
            Vector3 position1 = SpawnPoint1.position;
            Vector3 position2 = SpawnPoint2.position;
            Vector3 position = transform.position;
            Enemy_Child1 = Instantiate(Enemy_Child1, position + new Vector3(4.0f, 0.0f, 0.0f), Quaternion.identity);
            Enemy_Child1 = Instantiate(Enemy_Child1, position + new Vector3(-4.0f, 0.0f, 0.0f), Quaternion.identity);
            Enemy_Child1 = Instantiate(Enemy_Child1, position + new Vector3(6.0f, 2.0f, 0.0f), Quaternion.identity);
            Enemy_Child1 = Instantiate(Enemy_Child1, position + new Vector3(-6.0f, 2.0f, 0.0f), Quaternion.identity);
            Enemy_Child2 = Instantiate(Enemy_Child2, position1 + new Vector3(0.0f, 0.0f, 0.0f), Quaternion.identity);
            Enemy_Child2 = Instantiate(Enemy_Child2, position2 + new Vector3(1.0f, 0.0f, 0.0f), Quaternion.identity);
    }

    
    private void OnCollisionExit2D(Collision2D other)
    {
        isInAttackRange =false;
        anim.SetBool("shouldAttack", false);
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player"){
            target = other.transform;
            if(Phase2){
            shouldRotate = true;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player"){
            target = other.transform;
            if(Phase2){
            shouldRotate = true;
            }
            if(SpawnNum <1 )
            {
             SpawnEnemy();
            SpawnNum++;
            }
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