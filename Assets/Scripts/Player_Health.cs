using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player_Health : MonoBehaviour
{
    public Health_Bar healthBar;
    [SerializeField] private Transform player;
    [SerializeField] private Transform RespawnPoint;
    private float health = 0f;
    [SerializeField] private float maxHealth = 100f;
    public float Spawndeath = 0f;
    private AudioSource playerhitaudio;

    private void Start()
    {
        health = maxHealth;
        playerhitaudio = GameObject.Find("PlayerDamageAudio").GetComponent<AudioSource>();
    }


    public void UpdateHealth(float mod)
    {
        health += mod;
        Debug.Log("Health:" + health);
        if (health > maxHealth)
        {
            health = maxHealth;
        } else if (health <= 0f)
        {
            health = 0f;
            Respawn();
        }
        healthBar.SetHealth(health);
        if(mod < 0)
        {
            playerhitaudio.Play();
        }
    }

    public void Respawn()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
   
}
