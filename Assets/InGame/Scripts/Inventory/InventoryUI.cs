using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventoryUI : MonoBehaviour
{
    public Inventory playerInventory;
    public GameObject inventorySlotPrefab;
    public Transform slotPanel;
    public TextMeshProUGUI itemInfoText;
    public Button useItemButton;

    private List<GameObject> slots = new List<GameObject>();
    private InventoryItem selectedItem;
    public Thirst playerThirst;
    public Hunger playerHunger;
    private const int numRows = 5;
    private const int numCols = 7;

    void Start()
    {
        CreateEmptySlots();
        UpdateInventoryUI();
        useItemButton.onClick.AddListener(UseSelectedItem);

        if (playerThirst == null)
        {
            Debug.LogError("Thirst component not found!");
        }
        if (playerHunger == null)
        {
            Debug.LogError("Hunger component not found!");
        }

        useItemButton.interactable = false;
    }

    private void CreateEmptySlots()
    {
        for (int i = 0; i < numRows * numCols; i++)
        {
            GameObject newSlot = Instantiate(inventorySlotPrefab, slotPanel);
            slots.Add(newSlot);

            InventorySlotUI slotUI = newSlot.GetComponent<InventorySlotUI>();
            slotUI.SetInventoryUI(this);
        }
    }

    public void UpdateInventoryUI()
    {
        foreach (var slot in slots)
        {
            InventorySlotUI slotUI = slot.GetComponent<InventorySlotUI>();
            slotUI.ClearSlot();
        }

        for (int i = 0; i < playerInventory.items.Count && i < slots.Count; i++)
        {
            InventorySlotUI slotUI = slots[i].GetComponent<InventorySlotUI>();
            slotUI.SetItem(playerInventory.items[i]);
        }
    }

    public void SelectItem(InventoryItem item)
    {
        selectedItem = item;
        //itemInfoText.text = item.itemName;
        useItemButton.interactable = true;
        HighlightSelectedSlot();
    }

    private void HighlightSelectedSlot()
    {
        foreach (var slot in slots)
        {
            InventorySlotUI slotUI = slot.GetComponent<InventorySlotUI>();
            if (slotUI.Item == selectedItem) 
            {
                slot.GetComponent<Image>().color = Color.yellow;
            }
            else
            {
                slot.GetComponent<Image>().color = Color.white;
            }
        }
    }

    public void UpdateItemInfo(string info)
    {
        //itemInfoText.text = info;
    }

    public void UseSelectedItem()
    {
        if (selectedItem != null)
        {
            selectedItem.itemQuantity -= 1;
            playerThirst.Drink(selectedItem.thirstRestore);
            playerHunger.Eat(selectedItem.hungerRestore);
            if (selectedItem.itemQuantity <= 0)
            {
                playerInventory.RemoveItem(selectedItem.itemID);
                selectedItem = null;
                //itemInfoText.text = "";
                useItemButton.interactable = false;
            }

            UpdateInventoryUI();
        }
    }
}
