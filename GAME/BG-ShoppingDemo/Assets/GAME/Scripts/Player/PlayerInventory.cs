using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    [HideInInspector] public Inventory inventory;
    [SerializeField] UI_Inventory uiInventory;
    
    private void Awake()
    {
        inventory = new Inventory();
        inventory.AddItem(new Item { name = "Coal", itemType = Item.ItemType.SimpleItem, amount = 1, price = 3 });
        //inventory.AddMoney(3);
        uiInventory.SetInventory(inventory);
    }
}
