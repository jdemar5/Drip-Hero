using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PistolStrike : MonoBehaviour
{
    public float speed = 20f;
    [SerializeField] public int damage = 1;
    public Rigidbody2D rb;
    public float lifeTime = 1.0f;
    private float attackDamage = 10f;
    private AudioSource audioSource;

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            audioSource.Play();
            Enemy_M enemy = other.gameObject.GetComponent<Enemy_M>();
            enemy.takeDamage(attackDamage);
        }
        if (other.gameObject.tag == "Boss_1")
        {
            audioSource.Play();
            Boss_1 enemy = other.gameObject.GetComponent<Boss_1>();
            enemy.takeDamage(attackDamage);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        rb.velocity = transform.up * speed;
        audioSource = GameObject.Find("HitAudio").GetComponent<AudioSource>();
        StartCoroutine("LifeTime");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator LifeTime()
    {
        yield return new WaitForSeconds(lifeTime);
        Destroy(gameObject);
    }
}
