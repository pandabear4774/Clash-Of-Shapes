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
    public GameObject upperLine;
    public GameObject lowerLine;
    public GameObject scoreMaster;
    public Text leftScoreLabel;
    public Text rightScoreLabel;
    //private Score scoreStuff

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
            changeDistance();
            if(Mathf.Abs(transform.position.x) > screenBounds.x)
            {
                Destroy(gameObject);
            }
        }
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(tagObject == "SquareDown")
        {
            if(collision.transform.tag == "SquareUp" || collision.transform.tag == "SquareDownEnd")
            {
                Instantiate(impactEffect, transform.position, transform.rotation);
                impactEffect.Play();
                Destroy(gameObject);
                if(collision.transform.tag == "SquareDownEnd")
                {
                    scoreMaster.GetComponent<Score>().IncreaseRightScore(Mathf.Round(transform.localScale.x));
                    return;
                }
                Destroy(collision.gameObject);
            }
            if (collision.transform.tag == "Wall")
            {
                Instantiate(impactEffect, transform.position, transform.rotation);
                impactEffect.Play();
                Destroy(gameObject);
                collision.gameObject.GetComponent<Wall>().DecreaseHealth(Mathf.Round(transform.localScale.x));
            }
            if (collision.transform.tag == "Troop")
            {
                Instantiate(impactEffect, transform.position, transform.rotation);
                impactEffect.Play();
                Destroy(gameObject);
                collision.gameObject.GetComponent<Troop>().DecreaseHealth(Mathf.Round(transform.localScale.x));
            }
            if (collision.transform.tag == "Particle")
            {
                Instantiate(impactEffect, transform.position, transform.rotation);
                impactEffect.Play();
                Destroy(gameObject);
                Destroy(collision.gameObject);
            }
        }
        if(tagObject == "SquareUp")
        {
            if (collision.gameObject.tag == "Wall")
            {
                Physics2D.IgnoreCollision(collision.gameObject.GetComponent<Collider2D>(), GetComponent<Collider2D>());
            }
            if (collision.transform.tag == "SquareUpEnd")
            {
                Instantiate(impactEffect, transform.position, transform.rotation);
                impactEffect.Play();
                Destroy(gameObject);
                scoreMaster.GetComponent<Score>().IncreaseLeftScore(Mathf.Round(transform.localScale.x));
                //changeLeftScore();
            }
            
        }
    }
    void changeDistance()
    {
        if (tagObject == "SquareDown")
        {
            distance -= Mathf.Sqrt(Mathf.Abs(distance)) / 35;
            return;
        }
        distance += Mathf.Sqrt(distance) / 35;
    }
    void changeLeftScore()
    {
        Score.leftScore++;
        leftScoreLabel.text = Score.leftScore.ToString();
    }
    
}
