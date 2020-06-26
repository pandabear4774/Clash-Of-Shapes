using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Environment : MonoBehaviour
{
    public GameObject topLine;
    public GameObject bottomLine;
    private Vector3 screenBounds;
    // Start is called before the first frame update
    void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
        transform.position = new Vector3(0, screenBounds.y-12, 0);
        Instantiate(topLine, transform.position, transform.rotation);
        transform.position = new Vector3(0, -screenBounds.y +25, 0);
        Instantiate(bottomLine, transform.position, transform.rotation);
        //line.transform.localScale = new Vector3(screenBounds.x*2, 1, 1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
