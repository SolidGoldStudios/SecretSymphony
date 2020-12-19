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

    public void MenuToggleQuestLog()
    {
        GameManager.Instance.ToggleQuestLog();
        Debug.Log("Toggling quest log!");
    }
    
    public void MenuHideEverything()
    {
        GameManager.Instance.HideInventory();
        GameManager.Instance.HideQuestLog();
    }
}
