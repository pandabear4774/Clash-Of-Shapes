using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopMenu : MonoBehaviour
{
    public Text coinLabel, upgradeCostLabel1;
    public float upgradeCost1;
    private float coins;
    public Button upgrade1;

    private void Start()
    {
        upgradeCost1 = PlayerPrefs.GetFloat("Upgrade 1 Cost");
        upgradeCostLabel1.text = upgradeCost1.ToString();
        upgrade1.onClick.AddListener(PurchaseUpgrade1);
    }

    public void SetShopCoinLabel()
    {
        coins = PlayerPrefs.GetFloat("Coins");
        coinLabel.text = "Coins: " + coins.ToString();
    }
    void PurchaseUpgrade1()
    {
        if(coins >= upgradeCost1)
        {
            coins -= upgradeCost1;
            PlayerPrefs.SetFloat("Coins", coins);
            coinLabel.text = "Coins: " + coins.ToString();
            upgradeCost1 *= 2;
            PlayerPrefs.SetFloat("Upgrade 1 Cost", upgradeCost1);
            upgradeCostLabel1.text = upgradeCost1.ToString();
            float newValue = PlayerPrefs.GetFloat("Max Mana") + 100;
            PlayerPrefs.SetFloat("Max Mana", newValue);
            PlayerPrefs.SetFloat("Upgrade 1 Cost", upgradeCost1);
        }
    }
}
