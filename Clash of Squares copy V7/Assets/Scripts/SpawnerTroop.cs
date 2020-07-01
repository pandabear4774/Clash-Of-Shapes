using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerTroop : MonoBehaviour
{
    public float health;
    private float timer;
    public float timerReset;
    public static float cost = 50f;
    public GameObject troopPrefab;
    public GameObject spawnerObject;
    private Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        timer = timerReset;
        offset = new Vector3(transform.localScale.x,0,0);
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if(timer <= 0)
        {
            timer = timerReset;
            Instantiate(troopPrefab, transform.position + offset, transform.rotation);
            health -= 1;
            if (health <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("SquareUp"))
        {
            Physics2D.IgnoreCollision(collision.gameObject.GetComponent<Collider2D>(), GetComponent<Collider2D>());
            return;
        }
        Destroy(gameObject);
        Destroy(collision.gameObject);
    }
}
