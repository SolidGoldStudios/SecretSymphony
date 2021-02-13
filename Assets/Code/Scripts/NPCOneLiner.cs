using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class NPCOneLiner : Interaction
{
    public GameObject dialogBox;
    public Sprite npcPortrait;
    public string npcName;
    public string dialogue;
    public bool playerInRange;

    PlayerMovement playerMovement;
    GameObject portraitObject;
    GameObject nameplate;
    Text nameplateText;
    Text dialogueText;
	bool OneLinerActive = false;
	
    private AudioSource source;

    void Start()
    {
        playerMovement = GameObject.Find("Player").gameObject.GetComponent<PlayerMovement>();

        portraitObject = dialogBox.transform.Find("Portrait").gameObject;

        nameplate = dialogBox.transform.Find("Nameplate").gameObject;
        nameplateText = nameplate.transform.Find("NameLabel").gameObject.GetComponent<Text>();

        dialogueText = dialogBox.transform.Find("Dialogue").gameObject.GetComponent<Text>();

		interactionIcon = Resources.Load<Sprite>("UI/cursor_speak");
        interactionIconActive = Resources.Load<Sprite>("UI/cursor_speak_active");
		moveToTarget = true;
		
        source = GetComponent<AudioSource>();
    }

    void Update()
    {
		if (OneLinerActive && Input.GetMouseButtonDown(0))
        {
            if (dialogBox.activeInHierarchy)
            {
                HideDialog();
            }
        }
    }

    private void ShowDialog()
    {
        if (playerMovement != null)
        {
            playerMovement.immobilized = true;
        }

        dialogueText.text = dialogue;

        if (npcPortrait)
        {
            dialogueText.rectTransform.offsetMin = new Vector2(80, 16);

            portraitObject.GetComponent<Image>().sprite = npcPortrait;
            portraitObject.SetActive(true);

            nameplateText.text = npcName;
            nameplate.SetActive(true);
        }
        else
        {
            dialogueText.rectTransform.offsetMin = new Vector2(16, 16);

            portraitObject.SetActive(false);

            nameplate.SetActive(false);
        }

		OneLinerActive = true;
        dialogBox.SetActive(true);

        if (source) source.Play();
    }

    private void HideDialog()
    {
		if (playerMovement != null)
        {
			playerMovement.immobilized = false;
		}
		OneLinerActive = false;
        dialogBox.SetActive(false);
    }

    /*
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerInRange = true;
        }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerInRange = false;
            HideDialog();
        }
    }
	*/
	
	public override void Interact()
	{
		ShowDialog();
	}
}
