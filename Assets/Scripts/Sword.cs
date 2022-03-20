using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword: MonoBehaviour
{
    //Class for the Sword weapon, displays the weapon but Weapon is the class that generates
    //the SwordStrikePrefab object
    
    private GameObject player;
    private Rigidbody2D rb;
    Vector3 mousePos;
    float angle;
    bool isSwordLeft;
    private AudioSource audioSource;


    void OnTriggerEnter(Collider other)
    {
        
    }

    void Start()
    {
        player = GameObject.Find("Player");
        rb = gameObject.GetComponent<Rigidbody2D>();
        isSwordLeft = true;
        audioSource = this.GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            audioSource.Play();
            if (isSwordLeft)
            {
                isSwordLeft = false;
            }
            else
            {
                isSwordLeft = true;
            }
        }

        if (isSwordLeft)
        {
            Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            rb.MoveRotation(rotation);
        }
        else
        {
            Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 180;
            Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            rb.MoveRotation(rotation);
        }
    }
}
