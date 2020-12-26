using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;
using System.Reflection;
using Ink.Runtime;

public class NPCDialogue : MonoBehaviour
{
    PlayerMovement playerMovement;
    GameObject portraitObject;
    GameObject nameplate;
    Text nameplateText;
    Text dialogueText;
    GameObject choiceOne;
    GameObject choiceTwo;
    GameObject choiceThree;
    Text choiceOneText;
    Text choiceTwoText;
    Text choiceThreeText;
    Button choiceOneButton;
    Button choiceTwoButton;
    Button choiceThreeButton;
    GameObject dialogOk;
    Button dialogOkButton;

    bool showingChoices;
    int currentChoice;
    string currentName;

    private void Awake()
    {
        playerMovement = GameObject.Find("Player").gameObject.GetComponent<PlayerMovement>();

        HideDialog();

        portraitObject = transform.Find("Portrait").gameObject;

        nameplate = transform.Find("Nameplate").gameObject;
        nameplateText = nameplate.transform.Find("NameLabel").gameObject.GetComponent<Text>();

        dialogueText = transform.Find("Dialogue").gameObject.GetComponent<Text>();

        choiceOne = transform.Find("ChoiceOne").gameObject;
        choiceTwo = transform.Find("ChoiceTwo").gameObject;
        choiceThree = transform.Find("ChoiceThree").gameObject;

        choiceOneText = choiceOne.transform.Find("Text").gameObject.GetComponent<Text>();
        choiceTwoText = choiceTwo.transform.Find("Text").gameObject.GetComponent<Text>();
        choiceThreeText = choiceThree.transform.Find("Text").gameObject.GetComponent<Text>();

        choiceOneButton = choiceOne.GetComponent<Button>();
        choiceOneButton.onClick.AddListener(ClickedChoiceOne);

        choiceTwoButton = choiceTwo.GetComponent<Button>();
        choiceTwoButton.onClick.AddListener(ClickedChoiceTwo);

        choiceThreeButton = choiceThree.GetComponent<Button>();
        choiceThreeButton.onClick.AddListener(ClickedChoiceThree);

        dialogOk = transform.Find("DialogOk").gameObject;
        dialogOkButton = dialogOk.GetComponent<Button>();
        dialogOkButton.onClick.AddListener(ClickedOk);
    }

    void ClickedOk()
    {
        Debug.Log("ok clicked, currentChoices.Count " + GameManager.Instance.inkStory.currentChoices.Count + " canContinue " + GameManager.Instance.inkStory.canContinue);

        if (GameManager.Instance.inkStory.currentChoices.Count > 0)
        {
            ShowChoices();
        }
        else if (GameManager.Instance.inkStory.canContinue)
        {
            StoryContinue();
        }
        else
        {
            HideDialog();
        }
    }

    void ClickedChoiceOne()
    {
        ClickedChoice(0);
    }

    void ClickedChoiceTwo()
    {
        ClickedChoice(1);
    }

    void ClickedChoiceThree()
    {
        ClickedChoice(2);
    }

    void ClickedChoice(int i)
    {
        if (i >= GameManager.Instance.inkStory.currentChoices.Count) return;

        Debug.Log("picked choice " + i);
        GameManager.Instance.inkStory.ChooseChoiceIndex(i);

        HideChoices();

        if (GameManager.Instance.inkStory.canContinue)
        {
            StoryContinue();
        }
        else
        {
            HideDialog();
        }
    }

    public void ShowDialog(string knotName)
    {
        playerMovement.immobilized = true;

        HideChoices();

        //GameManager.Instance.inkStory.ResetState();
        GameManager.Instance.inkStory.ChoosePathString(knotName);

        transform.gameObject.SetActive(true);

        StoryContinue();
    }

    private void StoryContinue()
    {
        dialogueText.text = GameManager.Instance.inkStory.Continue();
        dialogOk.SetActive(true);

        portraitObject.SetActive(false);
        dialogueText.rectTransform.offsetMin = new Vector2(16, 16);
        nameplate.SetActive(false);

        foreach (string tag in GameManager.Instance.inkStory.currentTags)
        {
            if (tag.StartsWith("name"))
            {
                currentName = tag.Substring(5);

                nameplate.SetActive(true);
                nameplateText.text = currentName.Replace("+", " ");

                portraitObject.SetActive(true);
                dialogueText.rectTransform.offsetMin = new Vector2(80, 16);

                portraitObject.GetComponent<Image>().sprite = Resources.Load<Sprite>("Portraits_Characters/" + currentName + "/" + currentName + "_neutral");
            }

            if (tag.StartsWith("mood"))
            {
                portraitObject.GetComponent<Image>().sprite = Resources.Load<Sprite>("Portraits_Characters/" + currentName + "/" + currentName + "_" + tag.Substring(5));
            }

            if (tag.StartsWith("sound"))
            {
                GetComponent<AudioSource>().clip = Resources.Load<AudioClip>("Audio/" + tag.Substring(6));
            }

            if (tag.StartsWith("quest"))
            {
                Type type = Type.GetType(tag.Substring(6));

                dynamic quest = Activator.CreateInstance(type);

                quest.Setup();

                GameManager.Instance.quests.Add(quest);
                GameManager.Instance.UpdateQuestLog();
            }

            if (tag.StartsWith("item"))
            {
                //string[] itemAttributes = tag.Substring(5).Split(',');

                //string itemName = itemAttributes[0];
                //string description = itemAttributes[1];
                //string iconName = itemAttributes[2];
                //string 

                //GameManager.Instance.AddInventoryItem()
            }
        }
    }

    private void HideDialog()
    {
        playerMovement.immobilized = false;
        transform.gameObject.SetActive(false);
    }

    private void ShowChoices()
    {
        dialogOk.SetActive(false);

        // Update portrait and nameplate
        nameplate.SetActive(true);
        nameplateText.text = "Kay";

        portraitObject.SetActive(true);
        dialogueText.rectTransform.offsetMin = new Vector2(80, 16);

        portraitObject.GetComponent<Image>().sprite = Resources.Load<Sprite>("Portraits_Characters/Kay/Kay_thinking");

        // Display the choices
        showingChoices = true;
        currentChoice = 0;

        dialogueText.text = "";

        for (int i = 0; i < GameManager.Instance.inkStory.currentChoices.Count; i++)
        {
            Choice choice = GameManager.Instance.inkStory.currentChoices[i];
            switch (i)
            {
                case 0:
                    choiceOne.SetActive(true);
                    choiceOneText.text = choice.text;
                    break;
                case 1:
                    choiceTwo.SetActive(true);
                    choiceTwoText.text = choice.text;
                    break;
                case 2:
                    choiceThree.SetActive(true);
                    choiceThreeText.text = choice.text;
                    break;
            }
        }
    }

    private void HideChoices()
    {
        showingChoices = false;

        choiceOne.SetActive(false);
        choiceTwo.SetActive(false);
        choiceThree.SetActive(false);
    }
}
