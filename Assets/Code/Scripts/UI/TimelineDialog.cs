using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* *
 * Use this on a disabled GameObject. When your Timeline's "Activation"
 * track enables the GameObject, it'll trigger dialog.
 * */

public class TimelineDialog : MonoBehaviour
{
    public GameObject dialogBox;
    public string knotName;

    void OnEnable()
    {
        if (!dialogBox.activeInHierarchy)
        {
			dialogBox.SetActive(true);
            NPCDialogue npcDialogue = dialogBox.GetComponent<NPCDialogue>();
            npcDialogue.ShowDialog(knotName);
        }
    }
}
