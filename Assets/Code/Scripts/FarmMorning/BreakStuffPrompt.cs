using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BreakStuffPrompt : MonoBehaviour
{
    public GameObject dialogBox;

    // Start is called before the first frame update
    void Start()
    {

        // Check to see if we have the scythe
        // and whether the fairy has told us to destroy stuff
        if (((int)GameManager.Instance.inkStory.variablesState["has_scythe"] == 1) && ((int)GameManager.Instance.inkStory.variablesState["has_piano_key"] == 1) && !GameManager.Instance.hasPromptedDestruction)
        { 
            dialogBox.SetActive(true);
            NPCDialogue npcDialogue = dialogBox.GetComponent<NPCDialogue>();
            npcDialogue.ShowDialog("scythe_destroy_prompt");
            GameManager.Instance.hasPromptedDestruction = true;
        }
        else if (((int)GameManager.Instance.inkStory.variablesState["has_scythe"] == 1) && ((int)GameManager.Instance.inkStory.variablesState["has_piano_key"] == 0) && !GameManager.Instance.hasPromptedWheat)
        { 
            dialogBox.SetActive(true);
            NPCDialogue npcDialogue = dialogBox.GetComponent<NPCDialogue>();
            npcDialogue.ShowDialog("scythe_wheat_prompt");
            GameManager.Instance.hasPromptedWheat = true;
        }
        else if (((int)GameManager.Instance.inkStory.variablesState["has_scythe"] == 0) && !GameManager.Instance.hasPromptedScythe) 
        {
            dialogBox.SetActive(true);
            NPCDialogue npcDialogue = dialogBox.GetComponent<NPCDialogue>();
            npcDialogue.ShowDialog("scythe_pickup_prompt");
            GameManager.Instance.hasPromptedScythe = true;
        }
    }
}
