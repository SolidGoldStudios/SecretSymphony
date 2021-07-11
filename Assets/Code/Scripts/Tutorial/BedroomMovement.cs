using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BedroomMovement : MonoBehaviour
{
    public GameObject dialogBox;
    public string knotName;
    public GameObject player;
    public PlayerMovement playerMovement;

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !dialogBox.activeInHierarchy && !GameManager.Instance.hasFinishedTutorialMovement)
        {
            StartCoroutine(waitAndShowDialog());
            
        }
    }

    IEnumerator waitAndShowDialog()
    {
        player = GameObject.Find("Player").gameObject;
        playerMovement = player.GetComponent<PlayerMovement>();
        yield return new WaitForSeconds(1.5f);
        playerMovement.immobilized = true;
        GameManager.Instance.hasFinishedTutorialMovement = true;
        NPCDialogue npcDialogue = dialogBox.GetComponent<NPCDialogue>();
        npcDialogue.ShowDialog(knotName);
        this.enabled = false;
    }
}
