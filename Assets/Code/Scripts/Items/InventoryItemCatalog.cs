using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryItemCatalog : MonoBehaviour
{
    public static List<InventoryItem> GetInventoryItemCatalog()
    {
        List<InventoryItem> inventoryItems = new List<InventoryItem>();

        inventoryItems.Add(new InventoryItem
        {
            itemName = "Piano Key",
            description = "A piano key.",
            icon = Resources.Load<Sprite>("Items/key"),
            weight = 1,
            value = 5,
            count = 1
        }
        );

        return inventoryItems;
    }
}
