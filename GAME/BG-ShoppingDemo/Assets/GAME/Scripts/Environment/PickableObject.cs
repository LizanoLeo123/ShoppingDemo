using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickableObject : MonoBehaviour
{
    public AudioClip coinSFX;

    [SerializeField] private PickableItemType type;
    [SerializeField] private Item item;
    [SerializeField] private int moneyAmount = 1;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.parent != null)
        {
            if(collision.transform.parent.CompareTag("Player"))
            {
                Inventory inventory = collision.transform.parent.Find("Brain").GetComponent<PlayerInventory>().inventory;
                switch(type)
                {
                    case PickableItemType.Item: 
                        inventory.AddItem(item);
                        break;
                    case PickableItemType.Money:
                        inventory.AddMoney(moneyAmount);
                        AudioSource.PlayClipAtPoint(coinSFX, Camera.main.transform.position);
                        break;
                }
                Destroy(gameObject);
            }
        }
    }
}

public enum PickableItemType
{
    Money,
    Item
}
