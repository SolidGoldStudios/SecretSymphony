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
    private GameObject talkIcon;

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
        CreateTalkIcon("Talk Icon");
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

    public void CreateTalkIcon(string type)
	{
		foreach (Transform child in gameObject.transform) 
		{
			GameObject.Destroy(child.gameObject);
		}
		GameObject talkIconPrefab = Resources.Load("Prefabs/" + type) as GameObject;
		talkIcon = Instantiate(talkIconPrefab);
		Vector3 pos = new Vector3(0,this.gameObject.GetComponent<BoxCollider2D>().size.y + 1, 0);
		talkIcon.transform.parent = this.gameObject.transform;
		talkIcon.transform.localPosition = pos;
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

        foreach (Transform child in gameObject.transform) 
        {
            GameObject.Destroy(child.gameObject);
        }
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
