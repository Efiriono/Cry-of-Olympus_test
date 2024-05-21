using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickableItem : MonoBehaviour
{
    public InventoryItem item;

    public void PickUp()
    {
        GameObject inventoryObject = GameObject.Find("/UI/InGameUI/Canvas/PlayerProfile/Inventory/PlayerInventory");
        Inventory playerInventory = inventoryObject.GetComponent<Inventory>();
        playerInventory.AddItem(item);
        Destroy(gameObject);
    }
}
