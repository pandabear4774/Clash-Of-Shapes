using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mana : MonoBehaviour
{
    public static float manaMax;
    public Text manaNumber;
    public static float manaCount;
    public float timerSpeed;
    private float timer;
    // Start is called before the first frame update
    void Start()
    {
        //PlayerPrefs.SetFloat("Max Mana", 250f);
        manaMax = PlayerPrefs.GetFloat("Max Mana");
        timerSpeed = 1 / timerSpeed;
        timer = timerSpeed;
        manaCount = 100;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if(timer <= 0)
        {
            if(manaCount < manaMax)
            {
                manaCount++;
                manaNumber.text = manaCount.ToString() + "/" + manaMax.ToString();
            }
            timer = timerSpeed;
        }
    }
}
