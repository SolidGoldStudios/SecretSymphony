using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Playables;
using System;
using System.Collections;
using System.Reflection;
using Ink.Runtime;

public class NPCDialogue : MonoBehaviour
{
	public SceneTransitionFade fadeSceneScript;
	
	public GameObject portraitObject;
	
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
    public GameObject timelineManager;
    public PlayableDirector timeline;

    public GameObject triviaBox;
	public GameObject books;

    public SpriteRenderer orbRenderer;
    public GameObject fairyMusicParticles;
    public GameObject fairySparkleParticles;
	
	IQuest quest;
    AudioSource audioSource;
    string nextScene;
    string nextBook;
    string nextMusicPlayer;
	public MusicPlayerView musicPlayerView;

    //bool showingChoices;
    //int currentChoice;
    string currentName;

    private void Start()
    {
		choiceOneButton = choiceOne.GetComponent<Button>();
        choiceOneButton.onClick.AddListener(ClickedChoiceOne);

        choiceTwoButton = choiceTwo.GetComponent<Button>();
        choiceTwoButton.onClick.AddListener(ClickedChoiceTwo);

        choiceThreeButton = choiceThree.GetComponent<Button>();
        choiceThreeButton.onClick.AddListener(ClickedChoiceThree);
		
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
        GameManager.Instance.SetPlayerImmobilized(true);

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

                InventoryItem itemCreated = ItemCreator.CreateInventoryItem(item.itemName, item.description, item.icon, item.weight, item.value, item.unique, item.clickAction);
				InventoryController.AddInventoryItem(itemCreated);
            }

            if (tag.StartsWith("play"))
            {
                // We'll show the music player after dialog is closed
                nextMusicPlayer = tag.Substring(5);
            }

            if (tag.StartsWith("trivia"))
            {
                Debug.Log("trivia tag!  args: " + tag.Substring(7));
                string[] args = tag.Substring(7).Replace("+", " ").Split(',');

                Trivia trivia = triviaBox.GetComponent<Trivia>();

                HideDialog();

                trivia.ShowTrivia(args[0], Resources.Load<Sprite>("Portraits_Characters/" + args[0] + "/" + args[0] + "_neutral"), args[1], args[2], args[3]);
            }

            if (tag.StartsWith("scene"))
            {
                // Save the nextScene info
                // We'll handle the scene change after dialog is closed
                nextScene = tag.Substring(6);
            }

            if (tag.StartsWith("book"))
            {
                // Save the nextBook info
                // We'll show the book after dialog is closed
                nextBook = tag.Substring(5);
            }

            if (tag.StartsWith("showSparkles"))
            {
                if (orbRenderer) orbRenderer.enabled = true;
                if (fairyMusicParticles) fairyMusicParticles.SetActive(true);
                if (fairySparkleParticles) fairySparkleParticles.SetActive(true);
            }

            if (tag.StartsWith("hideSparkles"))
            {
                if (orbRenderer) orbRenderer.enabled = false;
                if (fairyMusicParticles) fairyMusicParticles.SetActive(false);
                if (fairySparkleParticles) fairySparkleParticles.SetActive(false);
            }
            if (tag.StartsWith("timeline"))
            {
                string timelineObject = tag.Substring(9);
                timelineManager = GameObject.Find(timelineObject).gameObject;
                timeline = timelineManager.GetComponent<PlayableDirector>();
                timeline.Play();
            }
            if(tag.StartsWith("victory"))
            {
                // Show the victory pose and show the tooltip
                GameObject player = GameObject.Find("Player").gameObject;
                GameManager.Instance.playerMovement.RunRaiseArms(null);
            }
        }
    }

    private void HideDialog()
    {
        if (orbRenderer) orbRenderer.enabled = false;
        if (fairyMusicParticles) fairyMusicParticles.SetActive(false);
        if (fairySparkleParticles) fairySparkleParticles.SetActive(false);

        transform.gameObject.SetActive(false);

        // Check for music player info, set with the #play tag
        if (nextMusicPlayer != null) {

            string[] args = nextMusicPlayer.Replace("+", " ").Split('|');
            musicPlayerView.ShowMusicPlayer(args[0], args[1], args[2], args[3], args[4]);

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
            GameManager.Instance.books.Add(nextBook, 1);
            books.SetActive(true);
            books.GetComponent<PageCreator>().SetBook(nextBook);

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
        GameManager.Instance.SetPlayerImmobilized(false);
        
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
