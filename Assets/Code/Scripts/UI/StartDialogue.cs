using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartDialogue : Interaction
{
    public GameObject dialogBox;
    public string knotName;

    public void Start()
    {
        interactionIcon = Resources.Load<Sprite>("UI/cursor_speak");
        interactionIconActive = Resources.Load<Sprite>("UI/cursor_speak_active");
    }

    public override void Interact()
    {
        if (!dialogBox.activeInHierarchy)
        {
            NPCDialogue npcDialogue = dialogBox.GetComponent<NPCDialogue>();

            npcDialogue.ShowDialog(knotName);
        }
    }
}
