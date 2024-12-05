using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceManager : Singleton<ResourceManager>
{
    public int StartCoin;
    public int Coin;
    public void AddCoins(int amount)
    {
        Coin += amount;
        PlayerPrefs.SetInt("CoinAmount", Coin);
        PlayerPrefs.Save();
    }

    public void DeductCoins(int amount)
    {
        Coin -= amount;
        PlayerPrefs.SetInt("CoinAmount", Coin);
        PlayerPrefs.Save();
    }
}
