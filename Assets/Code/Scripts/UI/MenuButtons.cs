using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuButtons : MonoBehaviour
{
    public void MenuToggleInventory()
    {
        GameManager.Instance.ToggleInventory();
        Debug.Log("Toggling inventory!");
    }
}
