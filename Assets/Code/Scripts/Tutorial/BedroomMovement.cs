using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BedroomMovement : MonoBehaviour
{
    public GameObject dialogBox;
    public string knotName;


    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !dialogBox.activeInHierarchy && !GameManager.Instance.hasFinishedTutorialMovement)
        {
            Debug.Log("********** First movement");
            StartCoroutine(waitAndShowDialog());
            
        }
    }

    IEnumerator waitAndShowDialog()
    {
        Debug.Log("********** Showing dialog in just a moment");
        yield return new WaitForSeconds(1.5f);
        GameManager.Instance.hasFinishedTutorialMovement = true;
        NPCDialogue npcDialogue = dialogBox.GetComponent<NPCDialogue>();
        npcDialogue.ShowDialog(knotName);
    }
}
