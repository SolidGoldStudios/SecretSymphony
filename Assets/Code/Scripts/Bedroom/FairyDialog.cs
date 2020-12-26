using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FairyDialog : MonoBehaviour
{
    public GameObject dialogBox;
    public string knotName;

    void OnEnable()
    {
        Debug.Log("FairyDialog is enabled!");
        if (!dialogBox.activeInHierarchy)
        {
            NPCDialogue npcDialogue = dialogBox.GetComponent<NPCDialogue>();

            npcDialogue.ShowDialog(knotName);
        }
    }
}
