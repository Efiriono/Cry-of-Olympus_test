using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventorySlotUI : MonoBehaviour
{
    public Image iconImage;
    public TextMeshProUGUI quantityText;
    public Sprite emptySlotSprite;
    private InventoryUI inventoryUI;
    private InventoryItem item;

    public InventoryItem Item 
    {
        get { return item; }
        private set { item = value; }
    }

    public void SetItem(InventoryItem newItem)
    {
        Item = newItem;
        if (Item != null)
        {
            iconImage.sprite = Item.itemIcon;
            quantityText.text = Item.itemQuantity.ToString();
        }
        else
        {
            ClearSlot();
        }
    }

    public void ClearSlot()
    {
        Item = null;
        iconImage.sprite = emptySlotSprite;
        quantityText.text = "";
    }

    public void SetInventoryUI(InventoryUI ui)
    {
        inventoryUI = ui;
    }

    public void OnClick()
    {
        if (Item != null)
        {
            inventoryUI.SelectItem(Item);
            inventoryUI.UpdateItemInfo(Item.itemName);
        }
    }
}
