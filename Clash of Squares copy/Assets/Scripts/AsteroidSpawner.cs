using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    //square variables
    public float upperSize;
    public float lowerSize;
    //class variables
    public Vector2 screenBounds;
    public float timerReset;
    private float timer1;
    private float timer2;
    public GameObject squareUpPrefab;
    public GameObject squareDownPrefab;
    public Transform zero;
    private float xPos;
    private float yPos;
    private float squareSize;

    void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
        timer2 = timerReset / 2f;
    }

    // Update is called once per frame
    void Update()
    {
        timer1 -= Time.deltaTime;
        timer2 -= Time.deltaTime;

        if (timer1 <= 0)
        {
            timer1 = timerReset;
            SpawnSquareRight();
        }
        if(timer2 <= 0)
        {
            timer2 = timerReset;
            SpawnSquareLeft();
        }
    }
    void SpawnSquareRight()
    {
        xPos = -screenBounds.x + squareSize * 0.5f;
        GenerateSquareUp();
    }
    void SpawnSquareLeft()
    {
        xPos = screenBounds.x - squareSize * 0.5f;
        GenerateSquareDown();
    }

    void GenerateLocation()
    {
        yPos = Random.Range(-screenBounds.y + squareSize / 2f, screenBounds.y - squareSize / 2f);
        zero.position = new Vector3(xPos, yPos, 0);
    }
    void GenerateSquareUp()
    {
        GenerateLocation();
        Instantiate(squareUpPrefab, zero.position, zero.rotation);
        squareUpPrefab.transform.localScale = new Vector3(squareSize, squareSize, 1);
    }
    void GenerateSquareDown()
    {
        GenerateLocation();
        Instantiate(squareDownPrefab, zero.position, zero.rotation);
        squareDownPrefab.transform.localScale = new Vector3(squareSize, squareSize, 1);
    }
}
