using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UI_ShopItem : MonoBehaviour
{
    public bool isInStore;
    public Item item;
    public TMP_Text priceLabel;

    public void UpdateData(Item item, bool isInStore)
    {
        this.isInStore = isInStore;
        this.item = item;
        priceLabel.text = this.item.price.ToString();
    }
}
