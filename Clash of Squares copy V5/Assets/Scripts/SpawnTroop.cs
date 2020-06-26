using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTroop : MonoBehaviour
{
    //square variables
    public float squareUpLowerSize;
    public float squareUpUpperSize;
    public float squareDownLowerSize;
    public float squareDownUpperSize;

    //class variables
    public Vector2 screenBounds;
    public float timerReset;
    private float timer;
    public GameObject squareUpPrefab;
    public GameObject squareDownPrefab;
    public Transform zero;
    private float xPos;
    private float yPos;
    private float squareSize;
    public GameObject lowerLine;
    public GameObject upperLine;
    public GameObject leftLine;
    public GameObject rightLine;
    private float timeChange;

    void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
        timeChange = (timerReset - 1) / 60;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if(timer <= 0)
        {
            timer = timerReset;
            timerReset -= timeChange;
            for(int i = 0; i <=1; i++)
            {
                SpawnSquare(i);
            }
        }
    }
    void SpawnSquare(int i)
    {
        if (i == 0)
        {
            GenerateSize(squareUpLowerSize, squareUpUpperSize);
            xPos = leftLine.transform.position.x + squareSize * 0.5f;
            //yPos = lowerLine.transform.position.y + squareSize * 0.5f;
            GenerateSquareUp();
        } else
        {
            GenerateSize(squareDownLowerSize, squareDownUpperSize);
            xPos = rightLine.transform.position.x - squareSize * 0.5f;
            //yPos = upperLine.transform.position.y - squareSize * 0.5f;
            GenerateSquareDown();
        }
    }
    void GenerateLocation()
    {
        yPos = Random.Range(lowerLine.transform.position.y + squareSize/2f, upperLine.transform.position.y - squareSize/2f);
        zero.position = new Vector3(xPos,yPos,0);
    }
    void GenerateSize(float lower, float upper)
    {
        squareSize = Random.Range(lower, upper);
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
