using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

public class Levels : MonoBehaviour
{
    public Button[] buttons = new Button[15];
    // Start is called before the first frame update
    void Start()
    {
        buttons[0].onClick.AddListener(delegate { PlayGame(1); });
        buttons[1].onClick.AddListener(delegate { PlayGame(2); });
        buttons[2].onClick.AddListener(delegate { PlayGame(3); });
        buttons[3].onClick.AddListener(delegate { PlayGame(4); });
        buttons[4].onClick.AddListener(delegate { PlayGame(5); });
        buttons[5].onClick.AddListener(delegate { PlayGame(6); });
        buttons[6].onClick.AddListener(delegate { PlayGame(7); });
        buttons[7].onClick.AddListener(delegate { PlayGame(8); });
        buttons[8].onClick.AddListener(delegate { PlayGame(9); });
        buttons[9].onClick.AddListener(delegate { PlayGame(10); });
        buttons[10].onClick.AddListener(delegate { PlayGame(11); });
        buttons[11].onClick.AddListener(delegate { PlayGame(12); });
        buttons[12].onClick.AddListener(delegate { PlayGame(13); });
        buttons[13].onClick.AddListener(delegate { PlayGame(14); });
        buttons[14].onClick.AddListener(delegate { PlayGame(15); });
    }
    void PlayGame(int level)
    {
        switch (level)
        {
            case 1:
                SceneManager.LoadScene(1);
                break;
            case 2:
                SceneManager.LoadScene(1);
                break;
            case 3:
                SceneManager.LoadScene(1);
                break;
            case 4:
                SceneManager.LoadScene(1);
                break;
            case 5:
                SceneManager.LoadScene(1);
                break;
            case 6:
                SceneManager.LoadScene(1);
                break;
            case 7:
                SceneManager.LoadScene(1);
                break;
            case 8:
                SceneManager.LoadScene(1);
                break;
            case 9:
                SceneManager.LoadScene(1);
                break;
            case 10:
                SceneManager.LoadScene(1);
                break;
            case 11:
                SceneManager.LoadScene(1);
                break;
            case 12:
                SceneManager.LoadScene(1);
                break;
            case 13:
                SceneManager.LoadScene(1);
                break;
            case 14:
                SceneManager.LoadScene(1);
                break;
            case 15:
                SceneManager.LoadScene(1);
                break;
            default:
                Debug.Log("Level Does Not Exist");
                break;
        }
    }
}
