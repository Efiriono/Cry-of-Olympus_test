using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class InventoryItem
{
    public string itemName;
    public int itemID; 
    public Sprite itemIcon;
    public int itemQuantity; 
    public float thirstRestore;
    public float hungerRestore;
}
