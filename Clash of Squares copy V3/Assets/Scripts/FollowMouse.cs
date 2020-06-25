using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowMouse : MonoBehaviour
{
    private Vector2 screenBounds;
    //public GameObject wall;

    private void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            worldPosition.z = 0;
            if (worldPosition.y > -screenBounds.y + 16 && worldPosition.y < screenBounds.y - 16 && worldPosition.x >= -screenBounds.x + 23.26f && worldPosition.x <= 0)
            {
                transform.position = worldPosition;
            }
            if(ButtonAction.objectSelected != null)
            {
                if (Mana.manaCount >= ButtonAction.objectSelectedCost && worldPosition.y > -screenBounds.y + 16 && worldPosition.y < screenBounds.y - 16 && worldPosition.x >= -screenBounds.x + 23.26f && worldPosition.x <= 0)
                {
                    Instantiate(ButtonAction.objectSelected, transform.position, transform.rotation);
                    Mana.manaCount -= ButtonAction.objectSelectedCost;
                }
            }
            
            
        }
        
    }
}
