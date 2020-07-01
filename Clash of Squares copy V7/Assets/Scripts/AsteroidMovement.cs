using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidMovement : MonoBehaviour
{
    public float timerReset;
    public float distanceXLower;
    public float distanceXUpper;
    public float distanceYLower;
    public float distanceYUpper;
    private float timer;
    public string objectTag;

    private Vector2 screenBounds;
    private float distanceX;
    private float distanceY;

    void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
        timerReset = 1 / timerReset;
        timer = timerReset;
        distanceX = Random.Range(distanceXLower, distanceXUpper);
        distanceY = Random.Range(distanceYLower, distanceYUpper);
        if (objectTag == "AsteroidLeft")
        {
            distanceX *= -1;
        }
        
    }

    void Update()
    {
        timer -= Time.deltaTime;
        if(timer <= 0)
        {
            transform.position += new Vector3(distanceX, distanceY, 0);
            timer = timerReset;
            if(Mathf.Abs(transform.position.y) > screenBounds.y || Mathf.Abs(transform.position.x) > screenBounds.x){
                Destroy(gameObject);
            }
        }
    }
}
