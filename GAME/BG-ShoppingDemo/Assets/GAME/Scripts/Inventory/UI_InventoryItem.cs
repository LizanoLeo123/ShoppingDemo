using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_InventoryItem : MonoBehaviour
{
    public Item currentItem;
    public Transform itemOptions;
    //Could add a custom list of buttons depending on the items but for now I'll just show the items list.

    [SerializeField] private bool showingOptions = false;

    public void ShowHideOptions()
    {
        //Hide previously open inventory items menus
        foreach (UI_InventoryItem button in GameObject.FindObjectsOfType<UI_InventoryItem>())
        {
            if (button != this)
                button.HideOptions();
        }

        showingOptions = !showingOptions;
        itemOptions.gameObject.SetActive(showingOptions);
    }

    public void HideOptions()
    {
        showingOptions = false;
        itemOptions.gameObject.SetActive(false);
    }
}
