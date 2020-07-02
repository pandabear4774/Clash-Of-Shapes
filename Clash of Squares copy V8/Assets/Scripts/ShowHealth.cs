using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowHealth : MonoBehaviour
{
    public Text healthBar;

    private void OnMouseDown()
    {
        healthBar.text = gameObject.GetComponent<Health>().troopHealth.ToString();
        Invoke("RemoveText", 1f);
    }

    void RemoveText()
    {
        healthBar.text = "";
    }
    
}
