using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinCounter : MonoBehaviour
{
    int coinAmount;
    Text coinCountText;

    void Start()
    {
        coinAmount = DataStorage.GetCoins();
        coinCountText = transform.GetChild(2).gameObject.GetComponent<Text>();
        Refresh();
    }
    void Refresh()
    {
        coinCountText.text = coinAmount.ToString();
    }

    public void CoinCollected()
    {
        coinAmount++;
        DataStorage.SetCoins(coinAmount);
        Refresh();
    }
}
