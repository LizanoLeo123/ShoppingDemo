using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Item
{
    public enum ItemType
    {
        SimpleItem,
        Weapon,
        Clothing,
    }

    public string name;
    public ItemType itemType;
    //public bool isStackable; Not going to use it now but it is used to separate stackable from non stackable items.
    public int amount;
    public Sprite sprite;
    public int price;
}
