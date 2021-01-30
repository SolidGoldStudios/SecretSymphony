using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Trivia : MonoBehaviour
{
    PlayerMovement playerMovement;
    GameObject nameplate;
    Image topPortrait;
    Image bottomPortrait;
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
    AudioSource audioSource;

    bool showingChoices;
    int currentChoice;
    string currentName;

    private void Awake()
    {
        playerMovement = GameObject.Find("Player").gameObject.GetComponent<PlayerMovement>();

        //HideDialog();

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

        dialogOk = transform.Find("DialogOk").gameObject;
        dialogOkButton = dialogOk.GetComponent<Button>();
        dialogOkButton.onClick.AddListener(ClickedOk);
    }

    void ClickedOk()
    {
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
    }

    public void ShowTrivia()
    {
        playerMovement.immobilized = true;

        transform.gameObject.SetActive(true);
    }

    private void HideTrivia()
    {
        playerMovement.immobilized = false;

        transform.gameObject.SetActive(false);
    }
}
