using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ItemCreator
{
	public static InventoryItem CreateInventoryItem(string itemName, string description, string icon, int weight, int value, bool unique, string clickAction)
    {
        InventoryItem item = new InventoryItem
        {
			itemName = itemName,
			description = description,
			icon = icon,
			weight = weight,
			value = value,
			count = 1,
			unique = unique,
			clickAction = clickAction
        };
		
        return item;
    }
}
