using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private AudioSource audioSource;
    CoinCounter coinCounter;

    void Start()
    {
        audioSource = GameObject.Find("CoinPickupAudio").GetComponent<AudioSource>();
        coinCounter = GameObject.Find("CoinCounter").GetComponent<CoinCounter>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            audioSource.Play();
            coinCounter.CoinCollected();
            Destroy(gameObject);
        }
    }
}
