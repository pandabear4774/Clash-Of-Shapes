using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public float troopHealth;
    public void DecreaseHealth(float damage)
    {
        troopHealth -= damage;
        if (troopHealth <= 0)
        {
            Destroy(gameObject);
            return;
        }
        
    }
}
