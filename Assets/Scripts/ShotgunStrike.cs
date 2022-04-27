using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotgunStrike : MonoBehaviour
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
        if (other.gameObject.tag == "Enemy_S")
        {
            audioSource.Play();
            Enemy_S enemy = other.gameObject.GetComponent<Enemy_S>();
            enemy.takeDamage(attackDamage);
        }
        if (other.gameObject.tag == "Enemy_C")
        {
            audioSource.Play();
            Enemy_S enemy = other.gameObject.GetComponent<Enemy_S>();
            enemy.takeDamage(attackDamage);
        }
        if (other.gameObject.tag == "Enemy_R")
        {
            audioSource.Play();
            Enemy_R enemy = other.gameObject.GetComponent<Enemy_R>();
            enemy.takeDamage(attackDamage);
        }
        if (other.gameObject.tag == "Slime_Boss")
        {
            audioSource.Play();
            Slime_Boss enemy = other.gameObject.GetComponent<Slime_Boss>();
            enemy.takeDamage(attackDamage);
        }
        if (other.gameObject.tag == "PurpleKing")
        {
            audioSource.Play();
            PurpleKing enemy = other.gameObject.GetComponent<PurpleKing>();
            enemy.takeDamage(attackDamage);
        }
        if (other.gameObject.tag == "SummonedEnemy_M")
        {
            audioSource.Play();
            SummonedEnemy enemy = other.gameObject.GetComponent<SummonedEnemy>();
            enemy.takeDamage(attackDamage);
        }
        if (other.gameObject.tag == "SummonedEnemy_R")
        {
            audioSource.Play();
            SummonedEnemy_R enemy = other.gameObject.GetComponent<SummonedEnemy_R>();
            enemy.takeDamage(attackDamage);
        }
        if (other.gameObject.tag == "Enemy_SP")
        {
            audioSource.Play();
            Enemy_SP enemy = other.gameObject.GetComponent<Enemy_SP>();
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
