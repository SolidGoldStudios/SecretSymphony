using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Ink.Runtime;
using System.Collections;
using System.Collections.Generic;

public class GameManager : Singleton<GameManager>
{
    // Defining the state at game start
    public bool wearingNightgown = true;
	public bool hasPromptedDestruction = false;
	public bool hasFinishedTutorialMovement = false;
	public bool hasFinishedTutorialCurtains = false;
	public bool hasFinishedTutorialLamp = false;
	public bool hasFinishedTutorialWardrobe = false;

	// Ink story
	public TextAsset inkAsset;
    public Story inkStory;

    // Our persistent inventory
    public List<InventoryItem> inventory = new List<InventoryItem>();
    public List<InventoryItem> inventoryCatalog;
    public int inventoryCursor = 0;

    // Quests
	public List<IQuest> quests = new List<IQuest>();
	
	public Hashtable books = new Hashtable();
	public Hashtable pages = new Hashtable();

	// Background Music
	public GameObject backgroundMusic;

    // Used for the ChangeScene script
	bool setDefaultPos = false;
    Vector2 nextPosition;
    Vector3 nextCameraPosition;
    Vector2 nextDirection;
	
	public bool loadingFromSave = false;
	
	public GameObject player;
	public PlayerMovement playerMovement;

    protected GameManager() { }

    void Awake()
    {
        inventoryCatalog = InventoryItemCatalog.GetInventoryItemCatalog();

        SceneManager.sceneLoaded += OnSceneLoaded;
        inkAsset = Resources.Load<TextAsset>("Dialogue/MainStory");
        inkStory = new Story(inkAsset.text);

        // Listen for a change to the "tooltip" variable in an Ink script
        // When it changes, display a tooltip with the new value
        inkStory.ObserveVariable ("tooltip", (string varName, object newValue) => {
            ShowTooltipWithTimeout(newValue.ToString());
        });

		backgroundMusic = Instantiate(Resources.Load("Prefabs/BackgroundMusic")) as GameObject;
		DontDestroyOnLoad(backgroundMusic);
    }
	
	void Start()
	{
		if (   SceneManager.GetActiveScene().name != "TitleScreen"
			&& SceneManager.GetActiveScene().name != "TownEarwormCutscene")
		{
			player = GameObject.Find("Player").gameObject;
			playerMovement = player.GetComponent<PlayerMovement>();
		}
	}

    /**
     * Handling Scenes
     **/
    public void LoadScene(string scene, Vector2 toPosition, Vector3 toCameraPosition, Vector2 toDirection)
    {
        nextPosition = toPosition;
        nextCameraPosition = toCameraPosition;
        nextDirection = toDirection;
        //nextKnot = toKnot;

        SceneManager.LoadScene(scene);
    }
	
	public void LoadScene(string scene)
	{
		setDefaultPos = true;
		SceneManager.LoadScene(scene);
	}

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
		player = GameObject.Find("Player").gameObject;
		playerMovement = player.GetComponent<PlayerMovement>();
		
        // Find the player in the scene
		if (!loadingFromSave && SceneManager.GetActiveScene().name != "TitleScreen")
		{
			NavMeshAgent navMeshAgent = player.GetComponent<NavMeshAgent>();

			// Move her to the position defined in ChangeScene
			if (!setDefaultPos)
			{
				navMeshAgent.Warp(nextPosition);
				
				Animator animator = player.transform.GetComponent<Animator>();
				
				animator.SetFloat("moveX", nextDirection.x);
				animator.SetFloat("moveY", nextDirection.y);
				
				Camera.main.transform.position = nextCameraPosition;
			}
			else
			{
				setDefaultPos = false;
			}
		}
		else
		{
			//Awake();
			playerMovement = null;
			loadingFromSave = false;
		}
    }

    /**
     * Tooltips and dialogs
     **/
    public void ShowTooltip(string newText)
    {
        // Find the Tooltip object in the scene
        GameObject uiCanvas = GameObject.Find("UICanvas").gameObject;
        GameObject tooltip = uiCanvas.transform.Find("Tooltip").gameObject;

        // In that Tooltip object, find the Text object
        Text tooltipText = tooltip.transform.Find("TooltipText").gameObject.GetComponent<Text>();

        // Update the tooltip text
        tooltipText.text = newText;

        // Show the tooltip!
        tooltip.SetActive(true);
    }

    public void ShowTooltipWithTimeout(string newText)
    {
        // Find the Tooltip object in the scene
        GameObject uiCanvas = GameObject.Find("UICanvas").gameObject;
        GameObject tooltip = uiCanvas.transform.Find("Tooltip").gameObject;

        // In that Tooltip object, find the Text object
        Text tooltipText = tooltip.transform.Find("TooltipText").gameObject.GetComponent<Text>();

        // Update the tooltip text
        tooltipText.text = newText;

        // Show the tooltip!
        tooltip.SetActive(true);

        // Start this special function to hide the tooltip after 5 secs
        StartCoroutine(TimeoutTooltip());
    }

    public void HideTooltip()
    {
        // Find the Tooltip object in the scene
        GameObject uiCanvas = GameObject.Find("UICanvas").gameObject;
        GameObject tooltip = uiCanvas.transform.Find("Tooltip").gameObject;

        // Hide the tooltip
        tooltip.SetActive(false);
    }

    IEnumerator TimeoutTooltip()
    {
        // Because this function has a timer in it, it's considered a
        // "coroutine" and needs to be an IEnumerator function to run.
        // We can't put coroutines in normal "void" functions.
        yield return new WaitForSeconds(5);
        HideTooltip();
    }
	public void RunRaiseArms(Sprite icon, bool immobilize = true)
	{
		StartCoroutine(RaiseArms(icon, immobilize));
	}

	public IEnumerator RaiseArms(Sprite icon, bool immobilize)
	{
		player = GameObject.Find("Player").gameObject;
		playerMovement = player.GetComponent<PlayerMovement>();
		GameObject itemSprite = player.transform.Find("ItemSprite").gameObject;
		SpriteRenderer itemIcon = itemSprite.GetComponent<SpriteRenderer>();
		Animator animator = player.GetComponent<Animator>();

		if (immobilize) playerMovement.immobilized = true;
		animator.SetBool("collecting", true);

		if (icon != null)
		{
			itemIcon.sprite = icon;
			itemSprite.SetActive(true);
		}

		yield return new WaitForSeconds(3f);
		animator.SetBool("collecting", false);
		if (icon != null)
		{
			itemSprite.SetActive(false);
		}

		
		if (immobilize) playerMovement.immobilized = false;
		yield return null;
	}

	public int GetInventoryCount(string itemName)
    {
        return inventory.Exists(i => i.itemName == itemName) ? inventory.Find(i => i.itemName == itemName).count : 0;
    }
	
	public List<InventoryItem> GetInventory()
	{
		return inventory;
	}
	
	public void SetInventory(List<InventoryItem> loadInventory)
	{
		inventory = loadInventory;
	}
	
	public bool HaveQuest(string checkQuest)
	{
		for (int q = 0; q < quests.Count; q++)
		{
			if (quests[q].questData.questName == checkQuest)
			{
				return true;
			}
		}
		return false;
	}
	
	public List<QuestData> GetQuests()
	{
		List<QuestData> questData = new List<QuestData>();
		for (int q = 0; q < quests.Count; q++)
		{
			questData.Add(quests[q].questData);
		}
		return questData;
	}
	
	public void SetQuests(List<QuestData> questData)
	{
		for (int q = 0; q < questData.Count; q++)
		{
			IQuest quest = QuestType.SetQuestType(questData[q].questName);
			quest.questData = questData[q];
			quests.Add(quest);
		}
	}
	
	public void SetPlayerImmobilized(bool state)
	{
		if (playerMovement != null)
		{
			playerMovement.immobilized = state;
		}
	}
	
	public void SetBooks(Hashtable bookData)
	{
		books = bookData;
	}
	
	public Hashtable GetBooks()
	{
		return books;
	}
	
	public void SetPages(Hashtable pageData)
	{
		pages = pageData;
	}
	
	public Hashtable GetPages()
	{
		return pages;
	}
}
