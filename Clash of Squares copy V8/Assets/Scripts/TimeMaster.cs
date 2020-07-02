using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TimeMaster : MonoBehaviour
{
    public static float finalScore;
    public Text timeValue;
    [SerializeField]
    public float startingTime;
    private float timer;
    // Start is called before the first frame update
    void Start()
    {
        timeValue.text = startingTime.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            startingTime--;
            timeValue.text = startingTime.ToString();
            timer = 1;
            if(startingTime <= 0)
            {
                finalScore = Score.leftScore - Score.rightScore;
                if(finalScore < 0)
                {
                    finalScore = 0;
                }
                if(finalScore > PlayerPrefs.GetFloat("Best"))
                {
                    PlayerPrefs.SetFloat("Best", finalScore);
                }
                PlayerPrefs.SetFloat("PlayerScore", Score.leftScore);
                PlayerPrefs.SetFloat("EnemyScore", Score.rightScore);
                PlayerPrefs.SetFloat("FinalScore", finalScore);
                PlayerPrefs.SetFloat("Coins", Coins.coinAmount);
                SceneManager.LoadScene(2);
            }
        }
    }
}
