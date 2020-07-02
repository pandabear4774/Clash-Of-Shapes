using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopMenu : MonoBehaviour
{
    public Text coinLabel;
    public Text[] upgradeCostLabel = new Text[5];
    public float[] upgradeCost = new float[5];
    private float coins;
    public Button[] upgradeButtons = new Button[5];

    private void Start()
    {
        //Resets All Upgrades and Coins
        
        PlayerPrefs.SetFloat("Max Mana", 250f);
        PlayerPrefs.SetFloat("Mana Rate", 30f);
        PlayerPrefs.SetFloat("Troop Spawn", 2f);
        PlayerPrefs.SetFloat("Troop Speed", 0.25f);
        PlayerPrefs.SetFloat("Troop Size", 1f);
        PlayerPrefs.SetFloat("Upgrade 1 Cost", 100);
        PlayerPrefs.SetFloat("Upgrade 2 Cost", 100);
        PlayerPrefs.SetFloat("Upgrade 3 Cost", 100);
        PlayerPrefs.SetFloat("Upgrade 4 Cost", 100);
        PlayerPrefs.SetFloat("Upgrade 5 Cost", 100);
        PlayerPrefs.SetFloat("Coins", 99999);
        

        upgradeCost[0] = PlayerPrefs.GetFloat("Upgrade 1 Cost");
        upgradeCost[1] = PlayerPrefs.GetFloat("Upgrade 2 Cost");
        upgradeCost[2] = PlayerPrefs.GetFloat("Upgrade 3 Cost");
        upgradeCost[3] = PlayerPrefs.GetFloat("Upgrade 4 Cost");
        upgradeCost[4] = PlayerPrefs.GetFloat("Upgrade 5 Cost");
        for(int i = 0; i < upgradeCostLabel.Length; i++)
        {
            upgradeCostLabel[i].text = upgradeCost[i].ToString();
        }
        upgradeButtons[0].onClick.AddListener(delegate{PurchaseUpgrade(0);});
        upgradeButtons[1].onClick.AddListener(delegate { PurchaseUpgrade(1); });
        upgradeButtons[2].onClick.AddListener(delegate { PurchaseUpgrade(2); });
        upgradeButtons[3].onClick.AddListener(delegate { PurchaseUpgrade(3); });
        upgradeButtons[4].onClick.AddListener(delegate { PurchaseUpgrade(4); });
    }

    public void SetShopCoinLabel()
    {
        coins = PlayerPrefs.GetFloat("Coins");
        coinLabel.text = "Coins: " + coins.ToString();
    }
    void PurchaseUpgrade(int upgrade)
    {
        float newUpgradeCost;
        float newUpgradeValue;
        switch (upgrade)
        {
            case 0:
                if(coins > upgradeCost[0])
                {
                    newUpgradeCost = CheckCanUpgrade(0);
                    PlayerPrefs.SetFloat("Upgrade 1 Cost", newUpgradeCost);
                    newUpgradeValue = PlayerPrefs.GetFloat("Max Mana") + 100;
                    PlayerPrefs.SetFloat("Max Mana", newUpgradeValue);
                    Debug.Log(PlayerPrefs.GetFloat("Max Mana"));
                }
                break;
            case 1:
                if (coins > upgradeCost[1])
                {
                    newUpgradeCost = CheckCanUpgrade(1);
                    PlayerPrefs.SetFloat("Upgrade 2 Cost", newUpgradeCost);
                    newUpgradeValue = PlayerPrefs.GetFloat("Mana Rate") + 25;
                    PlayerPrefs.SetFloat("Mana Rate", newUpgradeValue);
                    Debug.Log(PlayerPrefs.GetFloat("Mana Rate"));
                }
                break;
            case 2:
                if (coins > upgradeCost[2])
                {
                    newUpgradeCost = CheckCanUpgrade(2);
                    PlayerPrefs.SetFloat("Upgrade 3 Cost", newUpgradeCost);
                    newUpgradeValue = PlayerPrefs.GetFloat("Troop Spawn") - 0.1f;
                    PlayerPrefs.SetFloat("Troop Spawn", newUpgradeValue);
                    Debug.Log(PlayerPrefs.GetFloat("Troop Spawn"));
                }
                break;
            case 3:
                if (coins > upgradeCost[3])
                {
                    newUpgradeCost = CheckCanUpgrade(3);
                    PlayerPrefs.SetFloat("Upgrade 4 Cost", newUpgradeCost);
                    newUpgradeValue = PlayerPrefs.GetFloat("Troop Speed") + 0.1f;
                    PlayerPrefs.SetFloat("Troop Speed", newUpgradeValue);
                    Debug.Log(PlayerPrefs.GetFloat("Troop Speed"));
                }
                break;
            case 4:
                if (coins > upgradeCost[4])
                {
                    newUpgradeCost = CheckCanUpgrade(4);
                    PlayerPrefs.SetFloat("Upgrade 5 Cost", newUpgradeCost);
                    newUpgradeValue = PlayerPrefs.GetFloat("Troop Size") + 1;
                    PlayerPrefs.SetFloat("Troop Size", newUpgradeValue);
                    Debug.Log(PlayerPrefs.GetFloat("Troop Size"));
                }
                break;
            default:
                Debug.Log("Upgrade Does Not Exist");
                break;
        }
    }
    private float CheckCanUpgrade(int x)
    {
        coins -= upgradeCost[x];
        PlayerPrefs.SetFloat("Coins", coins);
        coinLabel.text = "Coins: " + coins.ToString();
        upgradeCost[x] *= 2;
        upgradeCostLabel[x].text = upgradeCost[x].ToString();
        return upgradeCost[x];
    }
}
