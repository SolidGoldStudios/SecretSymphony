using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarwormDialog : MonoBehaviour
{   
    public GameObject dialogBox;
    public GameObject timelineObject;

    void Start()
    {
        dialogBox.SetActive(true);
        NPCDialogue npcDialogue = dialogBox.GetComponent<NPCDialogue>();

        // Check to see if we have already spoken to the Earworm
        if (!GameManager.Instance.hasMetEarworm)
        { 
            npcDialogue.ShowDialog("finalexam_earworm");
            GameManager.Instance.hasMetEarworm = true;
            timelineObject.SetActive(true);
        } else {
            timelineObject.SetActive(false);
            npcDialogue.ShowDialog("finalexam_fairy");
        }
    }
}
