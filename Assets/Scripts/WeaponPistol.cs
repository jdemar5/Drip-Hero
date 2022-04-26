using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPistol : MonoBehaviour
{
    [SerializeField] private float cooldownTime = 2f;
    private GameObject player;
    private Rigidbody2D rb;
    Vector3 mousePos;
    private float angle;
    public GameObject prefab;
    private Transform firePoint;
    private bool onCooldown;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        rb = this.transform.GetChild(1).GetComponent<Rigidbody2D>();
        firePoint = this.transform.GetChild(1).transform.GetChild(0);
        onCooldown = false;
    }

    // Update is called once per frame
    void Update()
    {

        
        if (Input.GetMouseButtonDown(0) && !onCooldown)
        {
            Instantiate(prefab, firePoint.position, firePoint.rotation);
            StartCoroutine("Cooldown");
        }
        Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        rb.MoveRotation(rotation);
        
    }
    public float GetCooldownTime()
    {
        return cooldownTime;
    }

    IEnumerator Cooldown()
    {
        onCooldown = true;
        yield return new WaitForSeconds(cooldownTime);
        onCooldown = false;
    }
}
