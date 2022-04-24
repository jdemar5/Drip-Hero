using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLaser : MonoBehaviour
{
    
    public float speed;
    int currnentPatrolIndex;
    public GameObject arrow;
    public Transform target;
    public float chaseRange;
    public float arrowForce;
    public float attackRange;
    public int damage;
    private float lastAttackTime;
    public float attackDelay;
    public float Spawndeath = 0f;
    private Animator anim;
    private bool Phase2;
    private bool Phase3;
    private bool cutscene1Ended;
    private bool cutscene2Ended;
    public bool isFiring;
    

    private void Start()
    {
        anim = GetComponent<Animator>();
        
    }
    
    private void Update()
    {
        Phase2 = GameObject.FindWithTag("PurpleKing").GetComponent<PurpleKing>().Phase2;
        Phase3 = GameObject.FindWithTag("PurpleKing").GetComponent<PurpleKing>().Phase3;
        cutscene1Ended = GameObject.FindWithTag("PurpleKing").GetComponent<PurpleKing>().cutscene1Ended;
        cutscene2Ended = GameObject.FindWithTag("PurpleKing").GetComponent<PurpleKing>().cutscene2Ended;
        if(Phase2 && cutscene1Ended){

        float distanceToPlayer = Vector3.Distance (transform.position, target.position);
        if (distanceToPlayer < attackRange)
        
        {
            Vector3 targetDir = target.position - transform.position;
            float angle = Mathf.Atan2 (targetDir.y, targetDir.x) * Mathf.Rad2Deg -90f;
            Quaternion q = Quaternion.AngleAxis (angle, Vector3.forward);
            transform.rotation = Quaternion.RotateTowards (transform.rotation, q, 180 * Time.deltaTime);

            if(Time.time > lastAttackTime + attackDelay)
            {
               isFiring =true;

                RaycastHit2D hit = Physics2D.Raycast (transform.position, transform.up,attackRange);
                
                if (hit.transform == target)
                {
                   
                    GameObject newArrow = Instantiate (arrow,transform.position, transform.rotation);
                    newArrow.GetComponent <Rigidbody2D>().AddRelativeForce (new Vector2(0f,arrowForce));
                    lastAttackTime = Time.time;
                }
               
            }
            else{
                isFiring = false;
            }
            }
            
        }
        else if(Phase3 && cutscene2Ended){
            attackDelay=0.1f;
            float distanceToPlayer = Vector3.Distance (transform.position, target.position);
        if (distanceToPlayer < attackRange)
        
        {
            Vector3 targetDir = target.position - transform.position;
            float angle = Mathf.Atan2 (targetDir.y, targetDir.x) * Mathf.Rad2Deg -90f;
            Quaternion q = Quaternion.AngleAxis (angle, Vector3.forward);
            transform.rotation = Random.rotation;
            if(Time.time > lastAttackTime + attackDelay)
            {
                RaycastHit2D hit = Physics2D.Raycast (transform.position, transform.up,attackRange);
                    GameObject newArrow = Instantiate (arrow,transform.position, transform.rotation);
                    newArrow.GetComponent <Rigidbody2D>().AddRelativeForce (new Vector2(0f,arrowForce));
                    lastAttackTime = Time.time;
               
            }
            }
            
        }
        
    }
}
