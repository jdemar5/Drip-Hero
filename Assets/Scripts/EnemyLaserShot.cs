using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLaserShot : MonoBehaviour
{
    public float attackDamage= 10f;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player") 
        {
            other.gameObject.GetComponent<Player_Health>().UpdateHealth(-attackDamage);
            
        }
        if (other.gameObject.tag != "Enemy_R" && other.gameObject.tag != "Coin" && other.gameObject.tag != "Player Strike"&& other.gameObject.tag != "Enemy" && other.gameObject.tag != "PurpleKing" && other.gameObject.tag != "Arrow"&& other.gameObject.tag != "Laser") 
        {
            
            Destroy(gameObject);
        }
    }
}
