using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventorySlotClick : MonoBehaviour
{
	public int index;
	
	public void Click()
	{
		InventoryController.ClickedInventoryItem(index);
	}
}
