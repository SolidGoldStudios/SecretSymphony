﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FarmExitCheck : MonoBehaviour
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
            int finishedPiano = (int)GameManager.Instance.inkStory.variablesState["completed_piano_quest"];

            if (finishedPiano == 0)
            {
                dialogueText.text = "Wait! There are more instruments to save here!";
                dialogueText.rectTransform.offsetMin = new Vector2(80, 16);
                portraitObject.GetComponent<Image>().sprite = Resources.Load<Sprite>("Portraits_Characters/Spirit+of+Music/Spirit+of+Music_left");
                portraitObject.SetActive(true);
                nameplateText.text = "Spirit of Music";
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
