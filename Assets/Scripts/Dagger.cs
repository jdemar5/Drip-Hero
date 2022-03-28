using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dagger : MonoBehaviour
{
    private GameObject player;
    private Rigidbody2D rb;
    Vector3 mousPos;
    float angle;
    private bool isDaggerLeft, onCooldown;
    private AudioSource audioSource;
    private Weapon weapon;
    private float cooldownTime;

    void OnTriggerEnter(Collider other)
    {
       
    }
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        rb = gameObject.GetComponent<Rigidbody2D>();
        isDaggerLeft = true;
        audioSource = this.GetComponent<AudioSource>();
        weapon = GameObject.Find("Weapon").GetComponent<Weapon>();
        cooldownTime = weapon.GetCooldownTime();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !onCooldown)
        {
            audioSource.Play();
            StartCoroutine("Cooldown");
            if (isDaggerLeft)
            {
                isDaggerLeft = false;
            }
            else
            {
                isDaggerLeft = true;
            }
        }

        if (isDaggerLeft)
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

    IEnumerator Cooldown()
    {
        onCooldown = true;
        yield return new WaitForSeconds(cooldownTime);
        onCooldown = false;
    }
}
        

