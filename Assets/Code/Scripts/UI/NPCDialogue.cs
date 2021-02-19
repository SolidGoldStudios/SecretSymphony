using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;
using System.Reflection;
using Ink.Runtime;

public class NPCDialogue : MonoBehaviour
{
	public SceneTransitionFade fadeSceneScript;
	
	public GameObject portraitObject;
	
    PlayerMovement playerMovement;
    public GameObject nameplate;
    public Text nameplateText;
    public Text dialogueText;
    public GameObject choiceOne;
    public GameObject choiceTwo;
    public GameObject choiceThree;
    public Text choiceOneText;
    public Text choiceTwoText;
    public Text choiceThreeText;
    Button choiceOneButton;
    Button choiceTwoButton;
    Button choiceThreeButton;
    public GameObject dialogOk;
    Button dialogOkButton;
	
	IQuest quest;
    AudioSource audioSource;
    string nextScene;
    string nextBook;
    string nextMusicPlayer;

    //bool showingChoices;
    //int currentChoice;
    string currentName;

    private void Awake()
    {
        
		playerMovement = GameObject.Find("Player").gameObject.GetComponent<PlayerMovement>();
		/*
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

        dialogOk = transform.Find("DialogOk").gameObject;
		*/
		
		choiceOneButton = choiceOne.GetComponent<Button>();
        choiceOneButton.onClick.AddListener(ClickedChoiceOne);

        choiceTwoButton = choiceTwo.GetComponent<Button>();
        choiceTwoButton.onClick.AddListener(ClickedChoiceTwo);

        choiceThreeButton = choiceThree.GetComponent<Button>();
        choiceThreeButton.onClick.AddListener(ClickedChoiceThree);
		
		dialogOkButton = dialogOk.GetComponent<Button>();
        dialogOkButton.onClick.AddListener(ClickedOk);
		
		HideDialog();
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
                if (tag.Substring(6) == "InstrumentPianoPartOne")
                {
                    quest = new InstrumentPianoPartOne();
					quest.Setup();
					quest.Progress();
                }

                GameManager.Instance.quests.Add(quest);
            }

            if (tag.StartsWith("item"))
            {
                InventoryItem item = GameManager.Instance.inventoryCatalog.Find(i => i.itemName == tag.Substring(5).Replace("+", " "));

                GameManager.Instance.AddInventoryItem(item.itemName, item.description, item.icon, item.weight, item.value, item.unique, item.clickAction);
            }

            if (tag.StartsWith("play"))
            {
                nextMusicPlayer = tag.Substring(5);
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

            if (tag.StartsWith("scene"))
            {
                // Save the nextScene info
                nextScene = tag.Substring(6);
            }

            if (tag.StartsWith("book"))
            {
                // Save the nextBook info
                nextBook = tag.Substring(5);
            }
        }
    }

    private void HideDialog()
    {
        transform.gameObject.SetActive(false);

        // Check for music player info, set with the #play tag
        if (nextMusicPlayer != null) {

            string[] args = nextMusicPlayer.Replace("+", " ").Split('|');
            GameManager.Instance.ShowMusicPlayer(args[0], args[1], args[2], args[3], args[4]);

            // Clear the var
            nextMusicPlayer = null;
        }

        // Check for a book to display, set with the #book tag
        if (nextBook != null)
        {

            // Enable the backdrop
            GameObject uiCanvas = GameObject.Find("UICanvas").gameObject;
            GameObject backdrop = uiCanvas.transform.Find("Backdrop").gameObject;
            backdrop.SetActive(true);

            // Show the selected book
            GameObject books = uiCanvas.transform.Find("Books").gameObject;
            if (nextBook == "piano")
            {
                GameObject pianoBook = books.transform.Find("KeyboardBook").gameObject;
                pianoBook.SetActive(true);
            }

            // Clear the var
            nextBook = null;
        }

        // Check for a nextScene, parse the info, and move there
        // This is set with the "#scene" tag in dialog
        if (nextScene != null)
        {
            string[] args = nextScene.Split('|');
            string[] playerPos = args[1].Split(',');
            string[] cameraPos = args[2].Split(',');
            string[] playerDir = args[3].Split(',');

			if (fadeSceneScript != null)
			{
				fadeSceneScript.FadeOut(args[0], new Vector2(float.Parse(playerPos[0]), float.Parse(playerPos[1])), new Vector3(float.Parse(cameraPos[0]), float.Parse(cameraPos[1]), float.Parse(cameraPos[2])), new Vector2(float.Parse(playerDir[0]), float.Parse(playerDir[1])));
			}
			else
			{
				GameManager.Instance.LoadScene(args[0], new Vector2(float.Parse(playerPos[0]), float.Parse(playerPos[1])), new Vector3(float.Parse(cameraPos[0]), float.Parse(cameraPos[1]), float.Parse(cameraPos[2])), new Vector2(float.Parse(playerDir[0]), float.Parse(playerDir[1])));
			}

            // Clear the nextScene variable
            nextScene = null;
        }        

        // Allow the player to move again
        playerMovement.immobilized = false;
        
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
        //showingChoices = true;
        //currentChoice = 0;

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
        //showingChoices = false;

        choiceOne.SetActive(false);
        choiceTwo.SetActive(false);
        choiceThree.SetActive(false);
    }
}
