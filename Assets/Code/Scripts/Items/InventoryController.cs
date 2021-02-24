using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class InventoryController
{
	public static void AddInventoryItem(InventoryItem item)
    {
        if (GameManager.Instance.inventory.Contains(item))
        {
            GameManager.Instance.inventory.Find(i => i.itemName.Equals(item.itemName)).count++;
        }
        else
        {
            GameManager.Instance.inventory.Add(item);
        }
        GameManager.Instance.playerMovement.RunRaiseArms(Resources.Load<Sprite>(item.icon));
    }
	
	public static bool CheckForInventoryItem(string itemName)
	{
		InventoryItem item = GameManager.Instance.inventory.Find(i => i.itemName.Equals(itemName));
		if (item != null)
        {
			return true;
		}
		return false;
	}

    public static void RemoveInventoryItem(string itemName, int count = 1)
    {
        InventoryItem item = GameManager.Instance.inventory.Find(i => i.itemName.Equals(itemName));

        if (item == null) return;

        if (item.count == count)
        {
            GameManager.Instance.inventory.Remove(item);
        }
        else if (item.count > count)
        {
            GameManager.Instance.inventory.Find(i => i.itemName.Equals(itemName)).count -= count;
        }
        else
        {
            Debug.Log("RemoveInventoryItem called on " + itemName + ", count=" + count + ", but only have " + item.count);
        }
    }

    public static void ClickedInventoryItem(int index)
    {
        Debug.Log("inventory item clickAction: " + GameManager.Instance.inventory[index].clickAction);
        string clickAction = GameManager.Instance.inventory[index].clickAction;

        if (clickAction.StartsWith("book"))
        {
            string book = clickAction.Substring(5);

            // Enable the backdrop
            GameObject uiCanvas = GameObject.Find("UICanvas").gameObject;
            GameObject backdrop = uiCanvas.transform.Find("Backdrop").gameObject;
            backdrop.SetActive(true);

            // Show the selected book
            GameObject books = uiCanvas.transform.Find("Books").gameObject;
            if (book == "piano")
            {
                Debug.Log("clicked piano book");
                GameObject pianoBook = books.transform.Find("KeyboardBook").gameObject;
                pianoBook.SetActive(true);
            }

        }
    }
}
