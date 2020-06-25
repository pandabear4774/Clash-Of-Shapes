using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    public float health;
    public static float cost = 10;

    public void DecreaseHealth(float damage)
    {
        if(health-damage <= 0)
        {
            Destroy(gameObject);
            return;
        }
        health -= damage;
    }
}
