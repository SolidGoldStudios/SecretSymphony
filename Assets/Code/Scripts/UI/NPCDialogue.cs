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
    Quest quest;
    AudioSource audioSource;

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
        if (playerMovement != null)
        {
            playerMovement.immobilized = true;
        }

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

            if (tag.StartsWith("audio"))
            {
                audioSource = GetComponent<AudioSource>();
                audioSource.clip = Resources.Load<AudioClip>("Audio/" + tag.Substring(6));
                audioSource.Play();
            }

            if (tag.StartsWith("quest"))
            {
                // This makes WebGL barf
                //Type type = Type.GetType(tag.Substring(6));
                //dynamic quest = Activator.CreateInstance(type);

                if (tag.Substring(6) == "InstrumentPiano")
                {
                    quest = new InstrumentPiano();
                }

                quest.Setup();

                GameManager.Instance.quests.Add(quest);
                GameManager.Instance.UpdateQuestLog();
            }

            if (tag.StartsWith("item"))
            {
                InventoryItem item = GameManager.Instance.inventoryCatalog.Find(i => i.itemName == tag.Substring(5).Replace("+", " "));

                GameManager.Instance.AddInventoryItem(item.itemName, item.description, item.icon, item.weight, item.value);
            }

            if (tag.StartsWith("play"))
            {
                GameManager.Instance.ShowMusicPlayer();
            }

            if (tag.StartsWith("trivia"))
            {
                Debug.Log("trivia tag!  args: " + tag.Substring(7));
                string[] args = tag.Substring(7).Replace("+", " ").Split(',');

                GameObject uicanvas = GameObject.Find("UICanvas");
                GameObject triviaBox = uicanvas.transform.Find("TriviaBox").gameObject;
                Trivia trivia = triviaBox.GetComponent<Trivia>();

                HideDialog();

                trivia.ShowTrivia(args[0], Resources.Load<Sprite>("Portraits_Characters/" + args[0] + "/" + args[0] + "_neutral"), args[1], args[2], args[3]);
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
        nameplateText.text = "Melody";

        portraitObject.SetActive(true);
        dialogueText.rectTransform.offsetMin = new Vector2(80, 16);

        portraitObject.GetComponent<Image>().sprite = Resources.Load<Sprite>("Portraits_Characters/Melody/Melody_thinking");

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
