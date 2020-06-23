using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetDeathScoreLabel : MonoBehaviour
{
    public Text yourLabel;
    public Text enemyLabel;
    public Text finalLabel;

    private void Start()
    {
        yourLabel.text = "Your Score: " + PlayerPrefs.GetFloat("PlayerScore").ToString();
        enemyLabel.text = "Enemy Score: " + PlayerPrefs.GetFloat("EnemyScore").ToString();
        finalLabel.text = "Final Score: " + PlayerPrefs.GetFloat("FinalScore").ToString();
    }
}
