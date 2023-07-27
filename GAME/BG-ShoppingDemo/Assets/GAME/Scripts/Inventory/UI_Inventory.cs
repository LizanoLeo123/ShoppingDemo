using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using DG.Tweening;

public class UI_Inventory : MonoBehaviour
{
    public Transform inventoryPanel;
    public float yValue = 1000f;

    [SerializeField] private ItemsData _itemsData;
    [SerializeField] private Transform itemSlotContainer;
    [SerializeField] private GameObject itemSlotTemplate;
    [SerializeField] private TMP_Text currencyLabel;
    private Inventory inventory;
    private bool isHidden = true;
    public void SetInventory(Inventory inventory)
    {
        this.inventory = inventory;
        inventory.OnItemsListChanged += Inventory_OnItemsListChanged;
        RefreshInventoryItems();
        currencyLabel.text = inventory.GetMoney().ToString();
    }

    private void Inventory_OnItemsListChanged(object sender, System.EventArgs e)
    {
        RefreshInventoryItems();
    }

    private void RefreshInventoryItems()
    {
        //Clean old inventory
        foreach(Transform child in itemSlotContainer)
        {
            Destroy(child.gameObject);
        }
        //Fill inventory
        foreach(Item item in inventory.GetItemsList())
        {
            // Here I would check if itemas are stackable and make a label to update the amount of items I have or just instantiate another slot if the item is not stackable.
            GameObject newItem = Instantiate(itemSlotTemplate, itemSlotContainer);
            newItem.SetActive(true);
            newItem.transform.GetChild(0).Find("ItemIcon").GetComponent<Image>().sprite = _itemsData.GetItemSprite(item.name);
        }
    }

    public void ShowHideInventory()
    {
        //Animate the inventory using DOTween
        Sequence mySequence = DOTween.Sequence();
        if (isHidden)
        {
            mySequence.Append(inventoryPanel.DOMove(new Vector3(360, yValue, 0), .5f));
            mySequence.Append(inventoryPanel.DOMove(new Vector3(344, yValue, 0), .7f));
        }
        else
        {
            mySequence.Append(inventoryPanel.DOMove(new Vector3(360, yValue, 0), .5f));
            mySequence.Append(inventoryPanel.DOMove(new Vector3(-323, yValue, 0), .7f));
        }
        mySequence.Play();
        isHidden = !isHidden;
    }
}
