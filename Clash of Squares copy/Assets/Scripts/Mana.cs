using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mana : MonoBehaviour
{
    public Text manaNumber;
    public static float manaCount;
    public float timerSpeed;
    private float timer;
    // Start is called before the first frame update
    void Start()
    {
        timerSpeed = 1 / timerSpeed;
        timer = timerSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if(timer <= 0)
        {
            manaCount++;
            manaNumber.text = manaCount.ToString();
            timer = timerSpeed;
        }
    }
}
