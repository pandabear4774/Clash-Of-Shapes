using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    public static float cost = 20;
    public float health = 10;
    public ParticleSystem bomb;
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(bomb, transform.position, transform.rotation);
        bomb.Play();
        Destroy(gameObject);
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

}
