using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonAction : MonoBehaviour
{
    public static GameObject objectSelected;
    public static float objectSelectedCost;
    public Button nextButton, wallSelect, troopSelect, bombSelect, spawnerSelect, shooterSelect;
    public GameObject wall, troop, bomb, spawner, shooter;
    // Start is called before the first frame update
    void Start()
    {
        nextButton.onClick.AddListener(NextLine);
        wallSelect.onClick.AddListener(SelectWall);
        troopSelect.onClick.AddListener(SelectTroop);
        bombSelect.onClick.AddListener(SelectBomb);
        spawnerSelect.onClick.AddListener(SelectSpawner);
        shooterSelect.onClick.AddListener(SelectShooter);
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
    void SelectSpawner()
    {
        objectSelected = spawner;
        objectSelectedCost = SpawnerTroop.cost;
    }
    void SelectShooter()
    {
        objectSelected = shooter;
        objectSelectedCost = ShooterTroop.cost;
    }
}
