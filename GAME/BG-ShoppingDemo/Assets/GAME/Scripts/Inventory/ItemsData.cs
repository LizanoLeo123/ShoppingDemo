using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemsData", menuName = "ScriptableObjects/ScriptableItemsData")]
public class ItemsData : ScriptableObject
{
    public Item[] itemsInfo = null;

    //Not the smartest way to retrieve items data or store items database but will work for this project.
    public Sprite GetItemSprite(string name)
    {
        foreach (Item item in itemsInfo)
        {
            Debug.Log(item.name);
            if (item.name == name)
            {
                return item.sprite;
            }
                
        }
        return null;
    }
}
