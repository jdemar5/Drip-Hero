using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    //This class is the class to be used to manage each type of weapon and what attacks they will generate
    //This class will contain all of the player projectile prefabs and will be responsible for keeping track
    //of what weapon(s) the player currently has.
    
    private GameObject player;
    private Rigidbody2D rb;
    Vector3 mousePos;
    float angle;
    public GameObject SwordStrikePrefab;
    private Transform firePoint;

    void Start()
    {
        player = GameObject.Find("Player");
        rb = gameObject.GetComponent<Rigidbody2D>();
        firePoint = this.transform.GetChild(0);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Instantiate(SwordStrikePrefab, firePoint.position, firePoint.rotation);
        }
        Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        rb.MoveRotation(rotation);
    }
}
