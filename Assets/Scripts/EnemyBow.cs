using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBow : MonoBehaviour
{
    
    public float speed;
    public GameObject arrow;
    public Transform target;
    public float chaseRange;
    public float arrowForce;
    public float attackRange;
    public int damage;
    private float lastAttackTime;
    public float attackDelay;
    private Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }
    
    private void Update()
    {

        float distanceToPlayer = Vector3.Distance (transform.position, target.position);
        if (distanceToPlayer < attackRange)
        
        {
            Vector3 targetDir = target.position - transform.position;
            float angle = Mathf.Atan2 (targetDir.y, targetDir.x) * Mathf.Rad2Deg -90f;
            Quaternion q = Quaternion.AngleAxis (angle, Vector3.forward);
            transform.rotation = Quaternion.RotateTowards (transform.rotation, q, 90 * Time.deltaTime);

            if(Time.time > lastAttackTime + attackDelay)
            {
               

                RaycastHit2D hit = Physics2D.Raycast (transform.position, transform.up,attackRange);
                
                if (hit.transform == target)
                {
                    anim.SetBool("shouldFire", true);
                    GameObject newArrow = Instantiate (arrow,transform.position, transform.rotation);
                    newArrow.GetComponent <Rigidbody2D>().AddRelativeForce (new Vector2(0f,arrowForce));
                    lastAttackTime = Time.time;
                }
                else{
                anim.SetBool("shouldFire", false);
            }
            }
            
        }
        
    }
}
