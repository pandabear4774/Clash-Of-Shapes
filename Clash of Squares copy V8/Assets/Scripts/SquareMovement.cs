using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SquareMovement : MonoBehaviour
{
    public GameObject square;
    private float timer;
    public float timerResetValue;
    public float distanceLeft;
    public float distanceRight;
    public string tagObject;
    private Vector2 screenBounds;
    public ParticleSystem impactEffect;
    public GameObject scoreMaster;
    // Start is called before the first frame update
    void Start()
    {
        distanceLeft = PlayerPrefs.GetFloat("Enemy Speed");
        distanceRight = PlayerPrefs.GetFloat("Troop Speed");
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
        timerResetValue = 1 / timerResetValue;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if(timer <= 0)
        {
            timer = timerResetValue;
            if (tagObject == "SquareDown")
            {
                transform.position += new Vector3(-distanceLeft, 0, 0);
                distanceLeft += Mathf.Sqrt(distanceLeft) / 30;
            }
            if(tagObject == "SquareUp")
            {
                transform.position += new Vector3(distanceRight, 0, 0);
                distanceRight += Mathf.Sqrt(distanceRight) / 30;
            }
            if(Mathf.Abs(transform.position.x) > screenBounds.x)
            {
                Destroy(gameObject);
            }
        }
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        /*
        if (collision.gameObject.CompareTag("Wall"))
        {
            Instantiate(impactEffect, transform.position, transform.rotation);
            impactEffect.Play();
            collision.gameObject.GetComponent<Health>().DecreaseHealth(Mathf.Round(transform.localScale.x));
            Destroy(gameObject);
            return;
        }
        if (collision.gameObject.CompareTag("WallTower"))
        {
            Instantiate(impactEffect, transform.position, transform.rotation);
            impactEffect.Play();
            Destroy(gameObject);
            return;
        }*/
        if (tagObject == "SquareDown")
        {
            if (collision.gameObject.CompareTag("SquareDown") || collision.gameObject.CompareTag("SquareUpEnd") || collision.gameObject.CompareTag("WallBomb"))
            {
                Physics2D.IgnoreCollision(collision.gameObject.GetComponent<Collider2D>(), GetComponent<Collider2D>());
                return;
            }
            Instantiate(impactEffect, transform.position, transform.rotation);
            impactEffect.Play();
            if (collision.gameObject.CompareTag("SquareDownEnd"))
            {
                scoreMaster.GetComponent<Score>().IncreaseRightScore(Mathf.Round(transform.localScale.x));
                return;
            } else
            {
                collision.gameObject.GetComponent<Health>().DecreaseHealth(Mathf.Round(transform.localScale.x));
            }
            Destroy(gameObject);
            Coins.coinAmount += Mathf.Round(transform.localScale.x/4f);
            return;
        } else
        {
            if (collision.gameObject.CompareTag("SquareDownEnd") || collision.gameObject.CompareTag("SquareUp"))
            {
                Physics2D.IgnoreCollision(collision.gameObject.GetComponent<Collider2D>(), GetComponent<Collider2D>());
                return;
            }
            if (collision.gameObject.CompareTag("SquareUpEnd"))
            {
                Instantiate(impactEffect, transform.position, transform.rotation);
                impactEffect.Play();
                Destroy(gameObject);
                scoreMaster.GetComponent<Score>().IncreaseLeftScore(Mathf.Round(transform.localScale.x));
                Coins.coinAmount += Mathf.Round(transform.localScale.x);
                return;
            }
            if (collision.gameObject.CompareTag("WallTower"))
            {
                Instantiate(impactEffect, transform.position, transform.rotation);
                impactEffect.Play();
                Destroy(gameObject);
                Destroy(collision.gameObject);
                return;
            }
            if (collision.gameObject.CompareTag("WallBomb"))
            {
                Instantiate(impactEffect, transform.position, transform.rotation);
                impactEffect.Play();
                Destroy(gameObject);
                Destroy(collision.gameObject);
                return;
            }
        }
    }
}
