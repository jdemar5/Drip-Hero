using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Potion : MonoBehaviour
{
    private AudioSource audioSource;
    public float Heal;

    void Start()
    {
        audioSource = GameObject.Find("PotionPickupAudio").GetComponent<AudioSource>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
             other.gameObject.GetComponent<Player_Health>().UpdateHealth(Heal);
             audioSource.Play();
             Destroy(gameObject);
        }
    }
}
