using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryView : MonoBehaviour
{
	public GameObject uiCanvas;
	public GameObject inventoryView;
	public GameObject inventoryContents;
	
    void OnEnable()
	{
		UpdateInventory();
	}
	
	public void UpdateInventory()
	{
        for (int i = 0; i < 32; i++)
        {
            GameObject inventorySlot = inventoryContents.transform.GetChild(i).gameObject;
            Image icon = inventorySlot.transform.GetChild(0).GetComponent<Image>();
            Text count = inventorySlot.transform.GetChild(0).GetChild(0).GetComponent<Text>();

            if (i < GameManager.Instance.inventory.Count)
            {
                icon.sprite = Resources.Load<Sprite>(GameManager.Instance.inventory[i].icon);
                count.text = GameManager.Instance.inventory[i].count.ToString();

                icon.enabled = true;
                count.enabled = true;

                Button button = inventorySlot.GetComponent<Button>();
                button.onClick.RemoveAllListeners();
                int index = i;
                button.onClick.AddListener(() => InventoryController.ClickedInventoryItem(index));
            }
            else
            {
                icon.enabled = false;
                count.enabled = false;
            }
        }
	}
}
