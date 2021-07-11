using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LivingRoomExitCheck : MonoBehaviour
{
    public GameObject dialogBox;
    public GameObject exitBarrier;
    public Text dialogueText;

    public GameObject portraitObject;
    public GameObject nameplate;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if ((int)GameManager.Instance.inkStory.variablesState["has_piano_quest"] != 1)
            {
				dialogueText.text = "I should talk to Mother before I head out.";
				dialogueText.rectTransform.offsetMin = new Vector2(16, 16);
				portraitObject.SetActive(false);
				nameplate.SetActive(false);
				dialogBox.SetActive(true);
            }
            else
            {
				exitBarrier.SetActive(false);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        dialogBox.SetActive(false);
    }
}
