using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotgun : MonoBehaviour
{
    // Start is called before the first frame update

    private GameObject player;
    private Rigidbody2D rb;
    Vector3 mousePos;
    float angle;
    private bool isSwordLeft, onCooldown;
    private AudioSource audioSource;
    private WeaponShotgun weapon;
    private float cooldownTime;
    void Start()
    {
        player = GameObject.Find("Player");
        rb = this.transform.GetChild(0).GetComponent<Rigidbody2D>();
        isSwordLeft = true;
        audioSource = this.GetComponent<AudioSource>();
        weapon = this.GetComponent<WeaponShotgun>();
        cooldownTime = weapon.GetCooldownTime();

    }

    // Update is called once per frame
    void Update()
    {


        if (Input.GetMouseButtonDown(0) && !onCooldown)
        {
            audioSource.Play();
            StartCoroutine("Cooldown");
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
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
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