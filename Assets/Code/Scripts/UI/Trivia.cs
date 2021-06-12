using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Trivia : MonoBehaviour
{
    PlayerMovement playerMovement;
    Image topPortrait;
    Image bottomPortrait;
    Text dialogueText;
    Text sideDialogueText;
    GameObject imageClue;
    GameObject audioClue;
    GameObject choiceOne;
    GameObject choiceTwo;
    GameObject choiceThree;
    GameObject okButtonObject;
    Text choiceOneText;
    Text choiceTwoText;
    Text choiceThreeText;
    Button choiceOneButton;
    Button choiceTwoButton;
    Button choiceThreeButton;
    Button okButton;
    Image check1;
    Image check2;
    Image check3;
    AudioSource audioSource;

    List<TriviaQuestion> triviaQuestions;
    int currentQuestion;
    int correctAnswer;
    int score;

    string failKnot;
    string successKnot;

    void OnEnable()
    {
        //HideTrivia();

        topPortrait = transform.Find("TopPortrait").gameObject.GetComponent<Image>();
        bottomPortrait = transform.Find("BottomPortrait").gameObject.GetComponent<Image>();
        bottomPortrait.sprite = Resources.Load<Sprite>("Portraits_Characters/Melody/Melody_thinking");
        dialogueText = transform.Find("Dialogue").gameObject.GetComponent<Text>();
        sideDialogueText = transform.Find("SideDialogue").gameObject.GetComponent<Text>();

        dialogueText.enabled = false;
        sideDialogueText.enabled = false;

        imageClue = transform.Find("ImageClue").gameObject;
        audioClue = transform.Find("AudioClue").gameObject;

        imageClue.SetActive(false);
        audioClue.SetActive(false);

        choiceOne = transform.Find("ChoiceOne").gameObject;
        choiceTwo = transform.Find("ChoiceTwo").gameObject;
        choiceThree = transform.Find("ChoiceThree").gameObject;
        okButtonObject = transform.Find("OkButton").gameObject;

        choiceOneText = choiceOne.transform.Find("Text").gameObject.GetComponent<Text>();
        choiceTwoText = choiceTwo.transform.Find("Text").gameObject.GetComponent<Text>();
        choiceThreeText = choiceThree.transform.Find("Text").gameObject.GetComponent<Text>();

        choiceOneButton = choiceOne.GetComponent<Button>();
        choiceOneButton.onClick.AddListener(ClickedChoiceOne);

        choiceTwoButton = choiceTwo.GetComponent<Button>();
        choiceTwoButton.onClick.AddListener(ClickedChoiceTwo);

        choiceThreeButton = choiceThree.GetComponent<Button>();
        choiceThreeButton.onClick.AddListener(ClickedChoiceThree);

        okButton = okButtonObject.GetComponent<Button>();
        okButton.onClick.AddListener(ClickedOk);

        choiceOne.SetActive(true);
        choiceTwo.SetActive(true);
        choiceThree.SetActive(true);
        okButtonObject.SetActive(false);

        GameObject scorePanel = transform.Find("ScorePanel").gameObject;
        check1 = scorePanel.transform.Find("Check1").gameObject.GetComponent<Image>();
        check2 = scorePanel.transform.Find("Check2").gameObject.GetComponent<Image>();
        check3 = scorePanel.transform.Find("Check3").gameObject.GetComponent<Image>();

        check1.enabled = false;
        check2.enabled = false;
        check3.enabled = false;

        // Enable the backdrop
        GameObject uiCanvas = GameObject.Find("UICanvas").gameObject;
        GameObject backdrop = uiCanvas.transform.Find("Backdrop").gameObject;
        backdrop.SetActive(true);

        ShowTrivia("Scarecrow", Resources.Load<Sprite>("Portraits_Characters/Scarecrow/Scarecrow_neutral"), "piano", null, null);
    }

    private void OnDisable()
    {
        choiceOneButton.onClick.RemoveListener(ClickedChoiceOne);
        choiceTwoButton.onClick.RemoveListener(ClickedChoiceTwo);
        choiceThreeButton.onClick.RemoveListener(ClickedChoiceThree);
        okButton.onClick.RemoveListener(ClickedOk);

        // Disable the backdrop
        GameObject uiCanvas = GameObject.Find("UICanvas").gameObject;
        GameObject backdrop = uiCanvas.transform.Find("Backdrop").gameObject;
        backdrop.SetActive(false);
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
        if (i == correctAnswer)
        {
            score += 1;
            bottomPortrait.sprite = Resources.Load<Sprite>("Portraits_Characters/Melody/Melody_happy");
            audioSource = GetComponent<AudioSource>();
            audioSource.clip = Resources.Load<AudioClip>("Audio/trivia_answer_correct");
            audioSource.Play();
            StartCoroutine(DelayAndShowThinking());

            ShowFollowupFact();
        }
        else
        {
            bottomPortrait.sprite = Resources.Load<Sprite>("Portraits_Characters/Melody/Melody_sad");
            audioSource = GetComponent<AudioSource>();
            audioSource.clip = Resources.Load<AudioClip>("Audio/trivia_answer_wrong");
            audioSource.Play();
            StartCoroutine(DelayAndShowThinking());

            ShowHint();
        }

        Debug.Log("Score: " + score);

        if (score == 1)
        {
            check1.enabled = true;
        }
        else if (score == 2)
        {
            check1.enabled = true;
            check2.enabled = true;
        }
        else if (score == 3)
        {
            check1.enabled = true;
            check2.enabled = true;
            check3.enabled = true;
        }
    }

    void ClickedOk()
    {
        if (score == 3)
        {
            dialogueText.text = "Great job!";
            choiceOne.SetActive(false);
            choiceTwo.SetActive(false);
            choiceThree.SetActive(false);
            okButtonObject.SetActive(false);
            bottomPortrait.sprite = Resources.Load<Sprite>("Portraits_Characters/Melody/Melody_happy");

            audioSource = GetComponent<AudioSource>();
            audioSource.clip = Resources.Load<AudioClip>("Audio/trivia_game_success");
            audioSource.Play();
            StartCoroutine(DelayAndHideTrivia());

            return;
        }

        currentQuestion += 1;
        Debug.Log("currentQuestion " + currentQuestion);

        if (currentQuestion == 5 || currentQuestion == triviaQuestions.Count)
        {
            HideTrivia();

            if (failKnot != null)
            {
                GameObject uiCanvas = GameObject.Find("UICanvas");
                GameObject dialogBox = uiCanvas.transform.Find("DialogBox").gameObject;
                NPCDialogue npcDialogue = dialogBox.GetComponent<NPCDialogue>();

                npcDialogue.ShowDialog(failKnot);
            }

            return;
        }

        ShowQuestion();
    }

    private IEnumerator DelayAndShowThinking()
    {
        yield return new WaitForSeconds(1.0f);
        bottomPortrait.sprite = Resources.Load<Sprite>("Portraits_Characters/Melody/Melody_thinking");
        yield return null;
    }

    private IEnumerator DelayAndHideTrivia()
    {
        yield return new WaitForSeconds(3.9f);
        HideTrivia();
        if (successKnot != null)
        {
            GameObject uiCanvas = GameObject.Find("UICanvas");
            GameObject dialogBox = uiCanvas.transform.Find("DialogBox").gameObject;
            NPCDialogue npcDialogue = dialogBox.GetComponent<NPCDialogue>();
            npcDialogue.ShowDialog(successKnot);
        }
        yield return null;
    }

    public void ShowTrivia(string name, Sprite portrait, string questionFile, string toSuccessKnot, string toFailKnot)
    {
        Debug.Log("show trivia: " + name);
        playerMovement = GameObject.Find("Player").gameObject.GetComponent<PlayerMovement>();
        playerMovement.immobilized = true;

        transform.gameObject.SetActive(true);

        topPortrait.sprite = portrait;

        string triviaJson = Resources.Load<TextAsset>("Trivia/" + questionFile).ToString();
        TriviaQuestionContainer triviaQuestionContainer = JsonUtility.FromJson<TriviaQuestionContainer>(triviaJson);
        triviaQuestions = triviaQuestionContainer.triviaQuestions;
        triviaQuestions.Shuffle();

        currentQuestion = 0;
        score = 0;
        Debug.Log("Score: " + score);
        successKnot = toSuccessKnot;
        failKnot = toFailKnot;

        ShowQuestion();
    }

    private void HideTrivia()
    {
        playerMovement = GameObject.Find("Player").gameObject.GetComponent<PlayerMovement>();
        playerMovement.immobilized = false;

        transform.gameObject.SetActive(false);
    }

    private void ShowQuestion()
    {
        TriviaQuestion triviaQuestion = triviaQuestions[currentQuestion];

        if (triviaQuestion.image != null)
        {
            sideDialogueText.text = triviaQuestion.question;

            dialogueText.enabled = false;
            sideDialogueText.enabled = true;

            imageClue.SetActive(true);
            audioClue.SetActive(false);

            imageClue.GetComponent<Image>().sprite = Resources.Load<Sprite>(triviaQuestion.image);
        }
        else if (triviaQuestion.audio != null)
        {
            sideDialogueText.text = triviaQuestion.question;

            dialogueText.enabled = false;
            sideDialogueText.enabled = true;

            imageClue.SetActive(false);
            audioClue.SetActive(true);

            audioClue.GetComponent<Button>().onClick.RemoveAllListeners();
            audioClue.GetComponent<Button>().onClick.AddListener(() => {
                audioSource = GetComponent<AudioSource>();
                audioSource.clip = Resources.Load<AudioClip>(triviaQuestion.audio);
                audioSource.Play();
            });
        }
        else
        {
            dialogueText.text = triviaQuestion.question;

            dialogueText.enabled = true;
            sideDialogueText.enabled = false;

            imageClue.SetActive(false);
            audioClue.SetActive(false);
        }

        choiceOne.SetActive(true);
        choiceTwo.SetActive(true);
        choiceThree.SetActive(true);
        okButtonObject.SetActive(false);

        switch (Random.Range(0, 3))
        {
            case 0:
                correctAnswer = 0;
                choiceOneText.text = triviaQuestion.correctAnswer;
                choiceTwoText.text = triviaQuestion.wrongAnswer1;
                choiceThreeText.text = triviaQuestion.wrongAnswer2;
                break;
            case 1:
                correctAnswer = 1;
                choiceOneText.text = triviaQuestion.wrongAnswer1;
                choiceTwoText.text = triviaQuestion.correctAnswer;
                choiceThreeText.text = triviaQuestion.wrongAnswer2;
                break;
            case 2:
                correctAnswer = 2;
                choiceOneText.text = triviaQuestion.wrongAnswer1;
                choiceTwoText.text = triviaQuestion.wrongAnswer2;
                choiceThreeText.text = triviaQuestion.correctAnswer;
                break;
        }
    }

    private void ShowHint()
    {
        TriviaQuestion triviaQuestion = triviaQuestions[currentQuestion];
        dialogueText.text = triviaQuestion.hint;

        choiceOne.SetActive(false);
        choiceTwo.SetActive(false);
        choiceThree.SetActive(false);
        okButtonObject.SetActive(true);
    }

    private void ShowFollowupFact()
    {
        TriviaQuestion triviaQuestion = triviaQuestions[currentQuestion];
        dialogueText.text = triviaQuestion.followupFact;

        choiceOne.SetActive(false);
        choiceTwo.SetActive(false);
        choiceThree.SetActive(false);
        okButtonObject.SetActive(true);
    }
}

static class MyExtensions
{
    public static void Shuffle<T>(this IList<T> list)
    {
        int n = list.Count;
        while (n > 1)
        {
            n--;
            int k = Random.Range(0, n + 1);
            T value = list[k];
            list[k] = list[n];
            list[n] = value;
        }
    }
}
