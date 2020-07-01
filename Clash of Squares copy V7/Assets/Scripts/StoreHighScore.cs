using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoreHighScore : MonoBehaviour
{
    public Text bestLabel;
    //Called when leaderboard button is clicked
    public void setHighScore()
    {
        bestLabel.text = PlayerPrefs.GetFloat("Best").ToString(); 
    }
}
