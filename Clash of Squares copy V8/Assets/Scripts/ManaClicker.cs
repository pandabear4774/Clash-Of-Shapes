using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManaClicker : MonoBehaviour
{
    public float manaPerClick = 5;

    public void AddMana()
    {
        if(Mana.manaCount + manaPerClick <= Mana.manaMax + 1)
        {
            Mana.manaCount += manaPerClick;
        }
    }
}
