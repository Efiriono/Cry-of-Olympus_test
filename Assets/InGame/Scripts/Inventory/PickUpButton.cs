using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickUpButton : MonoBehaviour
{
    public static PickUpButton instance;
    public Button pickUpButton;
    private PickableItem currentItem;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        pickUpButton.onClick.AddListener(PickUpItem);
        gameObject.SetActive(false);
    }

    public void ShowButton(PickableItem item)
    {
        currentItem = item;
        gameObject.SetActive(true); 
    }

    public void HideButton()
    {
        gameObject.SetActive(false); 
    }

    private void PickUpItem()
    {
        if (currentItem != null)
        {
            currentItem.PickUp();
            HideButton(); 
        }
    }
}