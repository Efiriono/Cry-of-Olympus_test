using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<InventoryItem> items = new List<InventoryItem>();
    public InventoryUI inventoryUI; 

    public void AddItem(InventoryItem newItem)
    {
        foreach (InventoryItem item in items)
        {
            if (item.itemID == newItem.itemID)
            {
                item.itemQuantity += newItem.itemQuantity;
                
                inventoryUI.UpdateInventoryUI();
                return;
            }
        }
        items.Add(newItem);
        
        inventoryUI.UpdateInventoryUI();
    }

    public void RemoveItem(int itemID)
    {
        items.RemoveAll(item => item.itemID == itemID);
    }

    public bool HasItem(int itemID)
    {
        return items.Exists(item => item.itemID == itemID);
    }
}
