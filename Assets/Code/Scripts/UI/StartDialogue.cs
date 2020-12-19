using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartDialogue : Interaction
{
    public GameObject dialogBox;
    public string knotName;

    public override void Interact()
    {
        if (!dialogBox.activeInHierarchy)
        {
            NPCDialogue npcDialogue = dialogBox.GetComponent<NPCDialogue>();

            npcDialogue.ShowDialog(knotName);
        }
    }
}
