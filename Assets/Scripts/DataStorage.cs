using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataStorage : MonoBehaviour
{
    static protected int health = 4; //should be changed to whatever value we use for starting health
    static protected int maxHealth = 4; //same here
    static protected int coins;

    static DataStorage data;

    public static DataStorage GetData()
    {
        return data;
    }

    void Start()
    {
        if (data != null)
        {
            Destroy(this.gameObject);
            return;
        }
        data = this;
        GameObject.DontDestroyOnLoad(this.gameObject);
    }

    public static int GetHealth()
    {
        return health;
    }
    public static int GetMaxHealth()
    {
        return maxHealth;
    }
    public static int GetCoins()
    {
        return coins;
    }
    public static void SetHealth(int h)
    {
        health = h;
        Debug.Log(health);
    }
    public static void SetMaxHealth(int mh)
    {
        maxHealth = mh;
    }
    public static void SetCoins(int c)
    {
        coins = c;
    }
}
