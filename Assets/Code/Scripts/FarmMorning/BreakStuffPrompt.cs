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
        Debug.Log("Starting scythe check");

        // Check to see if we have the scythe
        // and whether the fairy has told us to destroy stuff
        if (((int)GameManager.Instance.inkStory.variablesState["has_scythe"] == 1) && ((int)GameManager.Instance.inkStory.variablesState["has_piano_key"] == 1) && !GameManager.Instance.hasPromptedDestruction)
        { 
            dialogBox.SetActive(true);
            NPCDialogue npcDialogue = dialogBox.GetComponent<NPCDialogue>();
            npcDialogue.ShowDialog("scythe_destroy_prompt");
            GameManager.Instance.hasPromptedDestruction = true;
        }
    }
}
