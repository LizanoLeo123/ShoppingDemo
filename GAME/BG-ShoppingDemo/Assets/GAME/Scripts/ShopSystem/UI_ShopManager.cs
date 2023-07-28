using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class UI_ShopManager : MonoBehaviour
{
    public Transform inventoryPanel;
    public Transform shopPanel;
    public GameObject playerInventoryPanel;
    public Inventory playerInventory;
    public int neededTaps = 1;
    //public float yValue = 1000f;

    [SerializeField] private ItemsData _itemsData;
    [SerializeField] private Transform inventoryItemSlotContainer;
    [SerializeField] private GameObject inventoryItemSlotTemplate;
    [SerializeField] private Transform shopItemSlotContainer;
    [SerializeField] private GameObject shopItemSlotTemplate;
    [SerializeField] private TMP_Text currencyLabel;


    private Inventory shopInventory;
    private Vector3 inventoryOriginalPosition;
    private Vector3 shopOriginalPosition;

    private int currentTaps = 0;
    private bool listeningTaps = false;

    private void Start()
    {
        inventoryOriginalPosition = inventoryPanel.transform.position;
        shopOriginalPosition = shopPanel.transform.position;
        playerInventory = FindObjectOfType<PlayerInventory>()?.inventory;
        shopInventory = new Inventory();
        shopInventory.AddItem(new Item { name = "Adventurer Clothing", itemType = Item.ItemType.Clothing, amount = 1, price = 5 });
        shopInventory.AddItem(new Item { name = "Mage Clothing", itemType = Item.ItemType.Clothing, amount = 1, price = 5 });
        shopInventory.OnItemsListChanged += Inventory_OnItemsListChanged;
        playerInventory.OnItemsListChanged += Inventory_OnItemsListChanged;
        RefreshInventoryItems();
    }

    private void Update()
    {
        if(Input.GetKeyUp(KeyCode.Return) && listeningTaps)
        {
            //Count the amount of dialogues to hear before opening the store
            currentTaps += 1;
            if (currentTaps == neededTaps)
            {
                ShowStore();
            }
            //Close the store
            if (currentTaps > neededTaps)
            {
                HideStore();
                currentTaps = 0;
                listeningTaps = false;
            }
        }
    }

    private void Inventory_OnItemsListChanged(object sender, System.EventArgs e)
    {
        RefreshInventoryItems();
    }

    private void RefreshInventoryItems()
    {
        //Player Inventory
        //Clean old inventory
        foreach (Transform child in inventoryItemSlotContainer)
        {
            Destroy(child.gameObject);
        }
        //Fill inventory
        foreach (Item item in playerInventory.GetItemsList())
        {
            // Here I would check if itemas are stackable and make a label to update the amount of items I have or just instantiate another slot if the item is not stackable.
            GameObject newItem = Instantiate(inventoryItemSlotTemplate, inventoryItemSlotContainer);
            newItem.SetActive(true);
            UI_ShopItem shopItem = newItem.GetComponent<UI_ShopItem>();
            shopItem.UpdateData(item, false); //Player inventory
            newItem.transform.GetChild(0).Find("ItemIcon").GetComponent<Image>().sprite = _itemsData.GetItemSprite(item.name);
        }
        currencyLabel.text = playerInventory.GetMoney().ToString();

        //Shop Inventory
        //Clean old inventory
        foreach (Transform child in shopItemSlotContainer)
        {
            Destroy(child.gameObject);
        }
        //Fill inventory
        foreach (Item item in shopInventory.GetItemsList())
        {
            // Here I would check if itemas are stackable and make a label to update the amount of items I have or just instantiate another slot if the item is not stackable.
            GameObject newItem = Instantiate(shopItemSlotTemplate, shopItemSlotContainer);
            newItem.SetActive(true);
            UI_ShopItem shopItem = newItem.GetComponent<UI_ShopItem>();
            shopItem.UpdateData(item, true); //Store inventory
            newItem.transform.GetChild(0).Find("ItemIcon").GetComponent<Image>().sprite = _itemsData.GetItemSprite(item.name);
        }
    }


    // Subscribe all UI_ShopItem buttons to this method and it will handle itself.
    public void ItemExchange(UI_ShopItem exchangeItem)
    {
        if (exchangeItem.isInStore) //Puchasing something
        {
            //Debug.Log("TRY TO BUY SOMETHING");
            foreach (Item item in shopInventory.GetItemsList())
            {
                if (item.name == exchangeItem.item.name)
                {
                    if(playerInventory.GetMoney() >= item.price)
                    {
                        //Debug.Log("Si encontro el objeto a comprar");
                        playerInventory.AddItem(item);
                        playerInventory.AddMoney(-item.price); //Negative money to the player, store doesn't handle money as in Skyrim so player can sell and buy as much as it wants
                        shopInventory.QuitItem(item);
                        return;
                    }
                    else
                    {
                        //Play WRONG SFX
                        break;
                    }
                }
                
            }
        }
        else //Selling something
        {
            //Debug.Log("TRY TO SELL SOMETHING");
            foreach (Item item in playerInventory.GetItemsList())
            {
                if (item.name == exchangeItem.item.name)
                {
                    //Debug.Log("Si encontro el objeto a vender");
                    shopInventory.AddItem(item);
                    playerInventory.AddMoney(item.price);
                    playerInventory.QuitItem(item);
                    return;
                }
            }
        }
    }

    //Called from the shop keeper interaction and listen X amount of dialogues before opening/closing
    public void StartListeningEnterTaps()
    {
        listeningTaps = true;
    }

    private void ShowStore()
    {
        playerInventoryPanel.SetActive(false); //Don't want messy players to try to open the inventory with the store open
        shopPanel.DOMove(new Vector3(shopPanel.position.x, shopPanel.position.y - 400, 0), 1f);
        inventoryPanel.DOMove(new Vector3(inventoryPanel.position.x, inventoryPanel.position.y -400, 0), 1f);
    }

    private void HideStore()
    {
        playerInventoryPanel.SetActive(true);
        //shopPanel.DOMove(new Vector3(shopPanel.position.x, shopPanel.position.y + 400, 0), 1f);
        //inventoryPanel.DOMove(new Vector3(inventoryPanel.position.x, inventoryPanel.position.y + 400, 0), 1f);
        shopPanel.DOMove(shopOriginalPosition, 1f);
        inventoryPanel.DOMove(inventoryOriginalPosition, 1f);
    }
}
