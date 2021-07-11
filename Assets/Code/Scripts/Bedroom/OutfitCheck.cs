using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OutfitCheck : MonoBehaviour
{
    public GameObject dialogBox;
    public GameObject nightgownBarrier;
    public Text dialogueText;
	
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (GameManager.Instance.wearingNightgown)
            {
                dialogueText.text = "This isn’t a job for pajamas!";
                dialogBox.SetActive(true);
            }
            else
            {
                nightgownBarrier.SetActive(false);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        dialogBox.SetActive(false);
    }
}
