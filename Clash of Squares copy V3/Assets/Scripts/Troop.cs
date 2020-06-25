using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Troop : MonoBehaviour
{
    public float health;
    public static float cost = 10;
    private float timer;
    public float timerReset;
    public float distance;

    private void Start()
    {
        timerReset = 1 / timerReset;
        timer = timerReset;
    }
    public void DecreaseHealth(float damage)
    {
        if (health - damage <= 0)
        {
            Destroy(gameObject);
            return;
        }
        health -= damage;
    }
    private void Update()
    {
        timer -= Time.deltaTime;
        if(timer <= 0)
        {
            timer = timerReset;
            transform.position += new Vector3(distance, 0, 0);
            distance += Mathf.Sqrt(distance) / 35f;
            if(Mathf.Abs(transform.position.x) >= 90) {
                Destroy(gameObject);
            }
        }
    }
}
