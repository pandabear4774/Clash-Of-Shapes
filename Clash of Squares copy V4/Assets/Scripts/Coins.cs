using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Coins : MonoBehaviour
{
    public static float coinAmount;
    public Text coinLabel;
    // Start is called before the first frame update
    void Start()
    {
        coinAmount = PlayerPrefs.GetFloat("Coins");
    }
    private void Update()
    {
        coinLabel.text = coinAmount.ToString();
    }
}
