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
                PlayerPrefs.SetFloat("Enemy Spawn", 2f);
                PlayerPrefs.SetFloat("Enemy Speed", 0.15f);
                PlayerPrefs.SetFloat("Enemy Size", 5f);
                SceneManager.LoadScene(1);
                break;
            case 2:
                PlayerPrefs.SetFloat("Enemy Spawn", 2f);
                PlayerPrefs.SetFloat("Enemy Speed", 0.175f);
                PlayerPrefs.SetFloat("Enemy Size", 5f);
                SceneManager.LoadScene(1);
                break;
            case 3:
                PlayerPrefs.SetFloat("Enemy Spawn", 1.75f);
                PlayerPrefs.SetFloat("Enemy Speed", 0.175f);
                PlayerPrefs.SetFloat("Enemy Size", 5f);
                SceneManager.LoadScene(1);
                break;
            case 4:
                PlayerPrefs.SetFloat("Enemy Spawn", 1.75f);
                PlayerPrefs.SetFloat("Enemy Speed", 0.2f);
                PlayerPrefs.SetFloat("Enemy Size", 5f);
                SceneManager.LoadScene(1);
                break;
            case 5:
                PlayerPrefs.SetFloat("Enemy Spawn", 2f);
                PlayerPrefs.SetFloat("Enemy Speed", 0.3f);
                PlayerPrefs.SetFloat("Enemy Size", 4f);
                SceneManager.LoadScene(1);
                break;
            case 6:
                PlayerPrefs.SetFloat("Enemy Spawn", 1.5f);
                PlayerPrefs.SetFloat("Enemy Speed", 0.25f);
                PlayerPrefs.SetFloat("Enemy Size", 5f);
                SceneManager.LoadScene(1);
                break;
            case 7:
                PlayerPrefs.SetFloat("Enemy Spawn", 1.75f);
                PlayerPrefs.SetFloat("Enemy Speed", 0.35f);
                PlayerPrefs.SetFloat("Enemy Size", 5f);
                SceneManager.LoadScene(1);
                break;
            case 8:
                PlayerPrefs.SetFloat("Enemy Spawn", 1.5f);
                PlayerPrefs.SetFloat("Enemy Speed", 0.15f);
                PlayerPrefs.SetFloat("Enemy Size", 2f);
                SceneManager.LoadScene(1);
                break;
            case 9:
                PlayerPrefs.SetFloat("Enemy Spawn", 1f);
                PlayerPrefs.SetFloat("Enemy Speed", 0.15f);
                PlayerPrefs.SetFloat("Enemy Size", 10f);
                SceneManager.LoadScene(1);
                break;
            case 10:
                PlayerPrefs.SetFloat("Enemy Spawn", 2f);
                PlayerPrefs.SetFloat("Enemy Speed", 0.50f);
                PlayerPrefs.SetFloat("Enemy Size", 4f);
                SceneManager.LoadScene(1);
                break;
            case 11:
                PlayerPrefs.SetFloat("Enemy Spawn", 1.5f);
                PlayerPrefs.SetFloat("Enemy Speed", 0.4f);
                PlayerPrefs.SetFloat("Enemy Size", 4f);
                SceneManager.LoadScene(1);
                break;
            case 12:
                PlayerPrefs.SetFloat("Enemy Spawn", 1.75f);
                PlayerPrefs.SetFloat("Enemy Speed", 0.5f);
                PlayerPrefs.SetFloat("Enemy Size", 3f);
                SceneManager.LoadScene(1);
                break;
            case 13:
                PlayerPrefs.SetFloat("Enemy Spawn", 1.25f);
                PlayerPrefs.SetFloat("Enemy Speed", 0.25f);
                PlayerPrefs.SetFloat("Enemy Size", 4f);
                SceneManager.LoadScene(1);
                break;
            case 14:
                PlayerPrefs.SetFloat("Enemy Spawn", 0.5f);
                PlayerPrefs.SetFloat("Enemy Speed", 0.1f);
                PlayerPrefs.SetFloat("Enemy Size", 5f);
                SceneManager.LoadScene(1);
                break;
            case 15:
                PlayerPrefs.SetFloat("Enemy Spawn", 0.75f);
                PlayerPrefs.SetFloat("Enemy Speed", 0.5f);
                PlayerPrefs.SetFloat("Enemy Size", 3f);
                SceneManager.LoadScene(1);
                break;
            default:
                Debug.Log("Level Does Not Exist");
                break;
        }
    }
}
