using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonAction : MonoBehaviour
{
    public static GameObject objectSelected;
    public static float objectSelectedCost;
    public Button nextButton, wallSelect, troopSelect, bombSelect;
    public GameObject wall, troop, bomb;
    // Start is called before the first frame update
    void Start()
    {
        nextButton.onClick.AddListener(NextLine);
        wallSelect.onClick.AddListener(SelectWall);
        troopSelect.onClick.AddListener(SelectTroop);
        bombSelect.onClick.AddListener(SelectBomb);
    }
    void NextLine()
    {
        Debug.Log("HELLO");
    }
    void SelectWall()
    {
        objectSelected = wall;
        objectSelectedCost = Wall.cost;
    }
    void SelectTroop()
    {
        objectSelected = troop;
        objectSelectedCost = Troop.cost;
    }
    void SelectBomb()
    {
        objectSelected = bomb;
        objectSelectedCost = Bomb.cost;
    }
}
