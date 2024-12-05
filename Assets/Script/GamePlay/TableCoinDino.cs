using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TableCoinDino : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI coinText;

    void Start()
    {
        if (!PlayerPrefs.HasKey("FirstTime"))
        {
            ResourceManager.Instance.Coin = ResourceManager.Instance.StartCoin;
            PlayerPrefs.SetInt("CoinAmount", ResourceManager.Instance.Coin);
            PlayerPrefs.SetInt("FirstTime", 1);
            PlayerPrefs.Save();

            coinText.text = ResourceManager.Instance.Coin.ToString();
        }
        else
        {

            ResourceManager.Instance.Coin = PlayerPrefs.GetInt("CoinAmount");
            coinText.text = ResourceManager.Instance.Coin.ToString();
        }
    }

    void Update()
    {

        coinText.text = ResourceManager.Instance.Coin.ToString();

        if (ResourceManager.Instance.Coin != PlayerPrefs.GetInt("CoinAmount"))
        {
            PlayerPrefs.SetInt("CoinAmount", ResourceManager.Instance.Coin);
            PlayerPrefs.Save();
        }
    }


    public void addCoin()
    {
        AudioManager.Instance.BtnClick();

        UImanager.Instance.Popup[3].SetActive(true);

    }

}
