using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory
{
    public event EventHandler OnItemsListChanged;

    private List<Item> itemList;
    private int money = 0;

    public Inventory() { 
        itemList = new List<Item>();
        AddItem(new Item { name = "Coal", itemType = Item.ItemType.SimpleItem, amount = 1});
        AddItem(new Item { name = "Adventurer Clothing", itemType = Item.ItemType.Clothing, amount = 1 });
        AddItem(new Item { name = "Mage Clothing", itemType = Item.ItemType.Clothing, amount = 1 });
        AddMoney(50);
        Debug.Log(itemList.Count);
    }

    public void AddItem(Item item)
    {
        itemList.Add(item);
        OnItemsListChanged?.Invoke(this, EventArgs.Empty);
    }

    public List<Item> GetItemsList()
    {
        return itemList;
    }

    public int GetMoney()
    {
        return money;
    }

    public void AddMoney(int value) { money += value; }
}
