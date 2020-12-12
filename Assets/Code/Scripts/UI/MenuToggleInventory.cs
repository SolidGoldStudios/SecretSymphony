using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuToggleInventory : MonoBehaviour
{
    public void doMenuToggleInventory()
    {
        GameManager.Instance.ToggleInventory();
        Debug.Log("Toggling inventory!");
    }
}
