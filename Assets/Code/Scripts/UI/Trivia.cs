using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Trivia : MonoBehaviour
{
    PlayerMovement playerMovement;
    Image topPortrait;
    Image bottomPortrait;
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
    Text scoreText;
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

        GameObject score = transform.Find("Score").gameObject;
        scoreText = score.GetComponent<Text>();

        //ShowTrivia("Scarecrow", Resources.Load<Sprite>("Portraits_Characters/Scarecrow/Scarecrow_neutral"), "Trivia/piano", null, null);
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
            audioSource = GetComponent<AudioSource>();
            audioSource.clip = Resources.Load<AudioClip>("Audio/trivia_answer_correct");
            audioSource.Play();
        }
        else
        {
            audioSource = GetComponent<AudioSource>();
            audioSource.clip = Resources.Load<AudioClip>("Audio/trivia_answer_wrong");
            audioSource.Play();
        }

        scoreText.text = "Score: " + score;

        if (score == 3)
        {
            audioSource = GetComponent<AudioSource>();
            audioSource.clip = Resources.Load<AudioClip>("Audio/trivia_game_success");
            audioSource.Play();
            HideTrivia();

            if (successKnot != null)
            {
                GameObject uiCanvas = GameObject.Find("UICanvas");
                GameObject dialogBox = uiCanvas.transform.Find("DialogBox").gameObject;
                NPCDialogue npcDialogue = dialogBox.GetComponent<NPCDialogue>();
                npcDialogue.ShowDialog(successKnot);

                return;
            }
        }

        currentQuestion += 1;

        if (currentQuestion == 5 || currentQuestion == triviaQuestions.Count)
        {
            HideTrivia();

            if (failKnot != null)
            {
                GameObject uiCanvas = GameObject.Find("UICanvas");
                GameObject dialogBox = uiCanvas.transform.Find("DialogBox").gameObject;
                NPCDialogue npcDialogue = dialogBox.GetComponent<NPCDialogue>();

                npcDialogue.ShowDialog(failKnot);

                return;
            }
        }
        else
        {
            ShowQuestion();
        }
    }

    public void ShowTrivia(string name, Sprite portrait, string questionFile, string toSuccessKnot, string toFailKnot)
    {
        Debug.Log("show trivia: " + name);
        playerMovement = GameObject.Find("Player").gameObject.GetComponent<PlayerMovement>();
        playerMovement.immobilized = true;

        transform.gameObject.SetActive(true);

        nameplateText.text = name;
        topPortrait.sprite = portrait;

        string triviaJson = Resources.Load<TextAsset>("Trivia/" + questionFile).ToString();
        TriviaQuestionContainer triviaQuestionContainer = JsonUtility.FromJson<TriviaQuestionContainer>(triviaJson);
        triviaQuestions = triviaQuestionContainer.triviaQuestions;
        triviaQuestions.Shuffle();

        currentQuestion = 0;
        score = 0;
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
        dialogueText.text = triviaQuestion.question;

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
