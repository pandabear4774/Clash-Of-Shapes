using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TroopMovement : MonoBehaviour
{
    public static float cost = 50;
    private float frames;
    public float distance;
    private float timer;
    public GameObject scoreMaster;
    public ParticleSystem impactEffect;
    // Start is called before the first frame update
    void Start()
    {
        frames = 1f / 30f; 
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            timer = frames;
            transform.position += new Vector3(distance, 0, 0);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("SquareUpEnd"))
        {
            Instantiate(impactEffect, transform.position, transform.rotation);
            impactEffect.Play();
            Destroy(gameObject);
            scoreMaster.GetComponent<Score>().IncreaseLeftScore(Mathf.Round(transform.localScale.x));
            Coins.coinAmount += Mathf.Round(transform.localScale.x);
            return;
        }
    }
}
