using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public static float leftScore;
    public static float rightScore;
    public Text leftScoreLabel;
    public Text rightScoreLabel;
    // Start is called before the first frame update
    void Start()
    {
        leftScore = 0;
        rightScore = 0;
    }
    public void IncreaseLeftScore(float change)
    {
        leftScore += change;
    }
    public void IncreaseRightScore(float change)
    {
        rightScore += change;
    }
    private void Update()
    {
        leftScoreLabel.text = leftScore.ToString();
        rightScoreLabel.text = rightScore.ToString();
    }
}
