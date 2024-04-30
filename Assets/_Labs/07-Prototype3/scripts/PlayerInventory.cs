using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public int NumberofSheep{get; private set;}

    public void SheepCollected()
    {
        NumberofSheep++;
    }

}
