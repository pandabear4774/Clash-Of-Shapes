using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SquareMovement : MonoBehaviour
{
    public GameObject square;
    private float timer;
    public float timerResetValue;
    public float distance;
    public string tagObject;
    private Vector2 screenBounds;
    public ParticleSystem impactEffect;
    public GameObject scoreMaster;
    // Start is called before the first frame update
    void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
        timerResetValue = 1 / timerResetValue;
        if (tagObject == "SquareDown")
        {
            distance *= -1;
        }
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if(timer <= 0)
        {
            timer = timerResetValue;
            transform.position += new Vector3(distance, 0, 0);
            ChangeDistance();
            if(Mathf.Abs(transform.position.x) > screenBounds.x)
            {
                Destroy(gameObject);
            }
        }
        
    }
    /*
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(tagObject == "SquareDown")
        {
            if(collision.gameObject.CompareTag("SquareUp") || collision.gameObject.CompareTag("SquareDownEnd"))
            {
                Instantiate(impactEffect, transform.position, transform.rotation);
                impactEffect.Play();
                Destroy(gameObject);
                if(collision.gameObject.CompareTag("SquareDownEnd"))
                {
                    scoreMaster.GetComponent<Score>().IncreaseRightScore(Mathf.Round(transform.localScale.x));
                    return;
                }
                Destroy(collision.gameObject);
            }
            if (collision.gameObject.CompareTag("Wall"))
            {
                Instantiate(impactEffect, transform.position, transform.rotation);
                impactEffect.Play();
                Destroy(gameObject);
                collision.gameObject.GetComponent<Wall>().DecreaseHealth(Mathf.Round(transform.localScale.x));
            }
            if (collision.gameObject.CompareTag("Troop"))
            {
                Instantiate(impactEffect, transform.position, transform.rotation);
                impactEffect.Play();
                Destroy(gameObject);
                collision.gameObject.GetComponent<Troop>().DecreaseHealth(Mathf.Round(transform.localScale.x));
            }
            if (collision.gameObject.CompareTag("Particle"))
            {
                Instantiate(impactEffect, transform.position, transform.rotation);
                impactEffect.Play();
                Destroy(gameObject);
                Destroy(collision.gameObject);
            }
        }
        if(tagObject == "SquareUp")
        {
            if (collision.gameObject.CompareTag("Wall"))
            {
                Physics2D.IgnoreCollision(collision.gameObject.GetComponent<Collider2D>(), GetComponent<Collider2D>());
            }
            if (collision.gameObject.CompareTag("SquareUpEnd"))
            {
                Instantiate(impactEffect, transform.position, transform.rotation);
                impactEffect.Play();
                Destroy(gameObject);
                scoreMaster.GetComponent<Score>().IncreaseLeftScore(Mathf.Round(transform.localScale.x));
            }
        }
    }
    */
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(tagObject == "SquareDown")
        {
            if (collision.gameObject.CompareTag("SquareDown") || collision.gameObject.CompareTag("SquareUpEnd"))
            {
                Physics2D.IgnoreCollision(collision.gameObject.GetComponent<Collider2D>(), GetComponent<Collider2D>());
                return;
            }
            Instantiate(impactEffect, transform.position, transform.rotation);
            impactEffect.Play();
            if (collision.gameObject.CompareTag("SquareDownEnd"))
            {
                scoreMaster.GetComponent<Score>().IncreaseRightScore(Mathf.Round(transform.localScale.x));

            } else
            {
                collision.gameObject.GetComponent<Health>().DecreaseHealth(Mathf.Round(transform.localScale.x));
            }
            Destroy(gameObject);
            Coins.coinAmount += Mathf.Round(transform.localScale.x/4f);
        } else
        {
            if (collision.gameObject.CompareTag("Wall") || collision.gameObject.CompareTag("SquareDownEnd") || collision.gameObject.CompareTag("SquareUp"))
            {
                Physics2D.IgnoreCollision(collision.gameObject.GetComponent<Collider2D>(), GetComponent<Collider2D>());
            }
            if (collision.gameObject.CompareTag("SquareUpEnd"))
            {
                Instantiate(impactEffect, transform.position, transform.rotation);
                impactEffect.Play();
                Destroy(gameObject);
                scoreMaster.GetComponent<Score>().IncreaseLeftScore(Mathf.Round(transform.localScale.x));
                Coins.coinAmount += Mathf.Round(transform.localScale.x);
            }
        }
    }
    void ChangeDistance()
    {
        if (tagObject == "SquareDown")
        {
            distance -= Mathf.Sqrt(Mathf.Abs(distance)) / 35;
            return;
        }
        distance += Mathf.Sqrt(distance) / 35;
    }
}
