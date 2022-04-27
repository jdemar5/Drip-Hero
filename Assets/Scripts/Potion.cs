using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Potion : MonoBehaviour
{
    private AudioSource audioSource;
    CoinCounter coinCounter;
    public float Heal;

    void Start()
    {
        audioSource = GameObject.Find("CoinPickupAudio").GetComponent<AudioSource>();
        coinCounter = GameObject.Find("CoinCounter").GetComponent<CoinCounter>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
             other.gameObject.GetComponent<Player_Health>().UpdateHealth(Heal);
             Destroy(gameObject);
        }
    }
}
