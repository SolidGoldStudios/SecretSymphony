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
    public Text nameplateText;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if ((int)GameManager.Instance.inkStory.variablesState["has_piano_quest"] != 1)
            {
				dialogueText.text = "I should talk to Mother before I head out.";
				dialogueText.rectTransform.offsetMin = new Vector2(80, 16);
				portraitObject.GetComponent<Image>().sprite = Resources.Load<Sprite>("Portraits_Characters/Melody/Melody_thinking");
                portraitObject.SetActive(true);
                nameplateText.text = "Melody";
                nameplate.SetActive(true);
				dialogBox.SetActive(true);
            } if (
                (int)GameManager.Instance.inkStory.variablesState["has_scythe"] == 1 && 
                (int)GameManager.Instance.inkStory.variablesState["has_hit_piano"] != 1
                )
            {
                dialogueText.text = "I should use my scythe to break up that strange wood pile.";
				dialogueText.rectTransform.offsetMin = new Vector2(80, 16);
				portraitObject.GetComponent<Image>().sprite = Resources.Load<Sprite>("Portraits_Characters/Melody/Melody_thinking");
                portraitObject.SetActive(true);
                nameplateText.text = "Melody";
                nameplate.SetActive(true);
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
