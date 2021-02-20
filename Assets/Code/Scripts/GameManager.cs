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

    // Ink story
    public TextAsset inkAsset;
    public Story inkStory;

    // Our persistent inventory
    List<InventoryItem> inventory = new List<InventoryItem>();
    public List<InventoryItem> inventoryCatalog;
    public int inventoryCursor = 0;
    Sprite inventorySlotSprite;

    public delegate void ItemAddDelegate(string name);
    public ItemAddDelegate itemAddDelegate;

    public delegate void ItemRemoveDelegate(string name);
    public ItemRemoveDelegate itemRemoveDelegate;

    // Quests
    //public List<string> questNames = new List<string>();
	public List<IQuest> quests = new List<IQuest>();

    // Used for the ChangeScene script
    Vector2 nextPosition;
    Vector3 nextCameraPosition;
    Vector2 nextDirection;

    public bool viewingInventory = false;
    public bool viewingQuestLog = false;
    public bool viewingMusicPlayer = false;
	
	public bool loadingFromSave = false;

    protected GameManager() { }

    void Awake()
    {
        inventoryCatalog = InventoryItemCatalog.GetInventoryItemCatalog();

        inventorySlotSprite = Resources.Load<Sprite>("UI/ui_inventory_slot");

        SceneManager.sceneLoaded += OnSceneLoaded;
        inkAsset = Resources.Load<TextAsset>("Dialogue/MainStory");
        inkStory = new Story(inkAsset.text);

        // Listen for a change to the "tooltip" variable in an Ink script
        // When it changes, display a tooltip with the new value
        inkStory.ObserveVariable ("tooltip", (string varName, object newValue) => {
            ShowTooltipWithTimeout(newValue.ToString());
        });

        // Listen for a change to the "music_player" variable in an Ink script
        // When it changes, launch the MusicPlayer screen in the new mode
        //inkStory.ObserveVariable("music_player", (string varName, object newValue) => {
        //    ShowMusicPlayer();
        //});
    }
	
	void Start()
	{
		UpdateInventory();
		UpdateQuests();
		/*
		IQuest thomsBirthdayBreaskfest = new ThomasBirthdayBreakfestPartOne();
		thomsBirthdayBreaskfest.Setup();
		thomsBirthdayBreaskfest.Progress();
		quests.Add(thomsBirthdayBreaskfest);
		*/
		
		
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
		SceneManager.LoadScene(scene);
	}

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
		
        // Find the player in the scene
		if (!loadingFromSave && SceneManager.GetActiveScene().name != "TitleScreen")
		{
			GameObject player = GameObject.Find("Player").gameObject;
			NavMeshAgent navMeshAgent = player.GetComponent<NavMeshAgent>();

			// Move her to the position defined in ChangeScene
			navMeshAgent.Warp(nextPosition);
			//player.transform.position = nextPosition;
			Debug.Log("player moved to " + nextPosition);

			// Get the player's Animator
			Animator animator = player.transform.GetComponent<Animator>();

			// Update her orientation to match ChangeScene
			animator.SetFloat("moveX", nextDirection.x);
			animator.SetFloat("moveY", nextDirection.y);

			// Set the camera to the position defined in ChangeScene
			Camera.main.transform.position = nextCameraPosition;
		}
		else
		{
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

    public void HideDialog()
    {
        // Find the Dialog object in the scene
        GameObject uiCanvas = GameObject.Find("UICanvas").gameObject;
        GameObject dialogBox = uiCanvas.transform.Find("DialogBox").gameObject;

        // Hide the dialog box
        dialogBox.SetActive(false);
    }

    /**
     * Inventory stuff
     **/

    public void DebugInventory()
    {
        foreach (InventoryItem i in inventory)
        {
            Debug.Log(i.itemName + " " + i.count);
        }
    }

    public void AddInventoryItem(string itemName, string description, string icon, int weight, int value, bool unique, string clickAction)
    {
        InventoryItem item = new InventoryItem
        {
            itemName = itemName,
            description = description,
            icon = icon,
            weight = weight,
            value = value,
            count = 1,
			unique = unique,
            clickAction = clickAction
        };

        if (inventory.Contains(item))
        {
            inventory.Find(i => i.itemName.Equals(itemName)).count++;
        }
        else
        {
            inventory.Add(item);
        }

        UpdateInventory();

        itemAddDelegate?.Invoke(itemName);

        GameObject player = GameObject.Find("Player").gameObject;

        StartCoroutine(RaiseArms(player, Resources.Load<Sprite>(icon)));
    }
	
	public bool CheckForInventoryItem(string itemName)
	{
		InventoryItem item = inventory.Find(i => i.itemName.Equals(itemName));
		if (item != null)
        {
			return true;
		}
		return false;
	}

    public void RemoveInventoryItem(string itemName, int count = 1)
    {
        InventoryItem item = inventory.Find(i => i.itemName.Equals(itemName));

        if (item == null) return;

        if (item.count == count)
        {
            inventory.Remove(item);
        }
        else if (item.count > count)
        {
            inventory.Find(i => i.itemName.Equals(itemName)).count -= count;
        }
        else
        {
            Debug.Log("RemoveInventoryItem called on " + itemName + ", count=" + count + ", but only have " + item.count);
        }

        UpdateInventory();

        itemRemoveDelegate?.Invoke(itemName);
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

    public IEnumerator RaiseArms(GameObject player, Sprite icon)
    {
        PlayerMovement playerMovement = player.GetComponent<PlayerMovement>();
        Animator animator = player.transform.GetComponent<Animator>();
        GameObject itemSprite = player.transform.Find("ItemSprite").gameObject;
        SpriteRenderer itemIcon = itemSprite.GetComponent<SpriteRenderer>();

        playerMovement.immobilized = true;
        animator.SetBool("collecting", true);

        if (icon != null)
        {
            itemIcon.sprite = icon;
            itemSprite.SetActive(true);
        }

        yield return new WaitForSeconds(0.6f);

        if (icon != null)
        {
            itemSprite.SetActive(false);
        }

        animator.SetBool("collecting", false);
        playerMovement.immobilized = false;
        yield return null;
    }

    public void ToggleInventory()
    {       

        // Hide dialog and tooltip
        HideTooltip();
        HideDialog();

        // Hide other overlay views
        HideQuestLog();

        // Toggle the visibility of the inventory
        if (viewingInventory)
        {
            HideInventory();
        }
        else
        {
            ShowInventory();
        }
    }

    public void ShowInventory()
    {
        viewingInventory = true;
        inventoryCursor = 0;

        // Find the Inventory layer
        GameObject uiCanvas = GameObject.Find("UICanvas").gameObject;
        GameObject inventoryView = uiCanvas.transform.Find("Inventory").gameObject;
        Image inventoryImage = inventoryView.GetComponent<Image>();
        GameObject inventoryContents = inventoryView.transform.Find("InventoryContents").gameObject;
        Canvas inventoryCanvas = inventoryContents.GetComponent<Canvas>();
        GameObject inventoryClose = inventoryView.transform.Find("InventoryClose").gameObject;
        Image inventoryCloseImage = inventoryClose.GetComponent<Image>();

        // Show bag image and inventory contents
        inventoryImage.enabled = true;
        inventoryCanvas.enabled = true;
        inventoryCloseImage.enabled = true;

        // Find the Backdrop object in the scene
        GameObject backdrop = uiCanvas.transform.Find("Backdrop").gameObject;

        // Toggle the visibility of the backdrop based on Inventory state
        backdrop.SetActive(true);

        // Prevent player from moving
        PlayerMovement playerMovement = GameObject.Find("Player").gameObject.GetComponent<PlayerMovement>();
        playerMovement.immobilized = true;
    }

    public void HideInventory()
    {
        viewingInventory = false;

        // Find the Inventory layer
        GameObject uiCanvas = GameObject.Find("UICanvas").gameObject;
        GameObject inventoryView = uiCanvas.transform.Find("Inventory").gameObject;
        Image inventoryImage = inventoryView.GetComponent<Image>();
        GameObject inventoryContents = inventoryView.transform.Find("InventoryContents").gameObject;
        Canvas inventoryCanvas = inventoryContents.GetComponent<Canvas>();
        GameObject inventoryClose = inventoryView.transform.Find("InventoryClose").gameObject;
        Image inventoryCloseImage = inventoryClose.GetComponent<Image>();

        // Hide bag image and inventory contents
        inventoryImage.enabled = false;
        inventoryCanvas.enabled = false;
        inventoryCloseImage.enabled = false;

        // Find the Backdrop object in the scene
        GameObject backdrop = uiCanvas.transform.Find("Backdrop").gameObject;

        // Toggle the visibility of the backdrop based on Inventory state
        backdrop.SetActive(false);

        // Allow player to move
        PlayerMovement playerMovement = GameObject.Find("Player").gameObject.GetComponent<PlayerMovement>();
        playerMovement.immobilized = false;

        GameObject itemDescription = uiCanvas.transform.Find("ItemDescription").gameObject;
        itemDescription.SetActive(false);
    }

    public void UpdateInventory()
    {
        GameObject uiCanvas = GameObject.Find("UICanvas").gameObject;
        GameObject inventoryView = uiCanvas.transform.Find("Inventory").gameObject;
        GameObject inventoryContents = inventoryView.transform.Find("InventoryContents").gameObject;

        for (int i = 0; i < 32; i++)
        {
            GameObject inventorySlot = inventoryContents.transform.GetChild(i).gameObject;
            Image slot = inventorySlot.GetComponent<Image>();
            Image icon = inventorySlot.transform.GetChild(0).GetComponent<Image>();
            Text count = inventorySlot.transform.GetChild(0).GetChild(0).GetComponent<Text>();

            slot.sprite = inventorySlotSprite;

            if (i < inventory.Count)
            {
                icon.sprite = Resources.Load<Sprite>(inventory[i].icon);
                count.text = inventory[i].count.ToString();

                icon.enabled = true;
                count.enabled = true;

                Button button = inventorySlot.GetComponent<Button>();
                button.onClick.RemoveAllListeners();
                int index = i;
                button.onClick.AddListener(() => ClickedInventoryItem(index));
            }
            else
            {
                icon.enabled = false;
                count.enabled = false;
            }
        }
    }

    void ClickedInventoryItem(int index)
    {
        Debug.Log("inventory item clickAction: " + inventory[index].clickAction);
        string clickAction = inventory[index].clickAction;

        if (clickAction.StartsWith("book"))
        {
            HideInventory();

            string book = clickAction.Substring(5);

            // Enable the backdrop
            GameObject uiCanvas = GameObject.Find("UICanvas").gameObject;
            GameObject backdrop = uiCanvas.transform.Find("Backdrop").gameObject;
            backdrop.SetActive(true);

            // Show the selected book
            GameObject books = uiCanvas.transform.Find("Books").gameObject;
            if (book == "piano")
            {
                Debug.Log("clicked piano book");
                GameObject pianoBook = books.transform.Find("KeyboardBook").gameObject;
                pianoBook.SetActive(true);
            }

        }
    }

    /**
     * Quest stuff
     **/
    public void ToggleQuestLog()
    {
        // Hide dialog and tooltip
        HideTooltip();
        HideDialog();

        // Hide other overlay views
        HideInventory();

        if (viewingQuestLog)
        {
            HideQuestLog();
        }
        else
        {
            ShowQuestLog();
        }
    }

    public void ShowQuestLog()
    {
		viewingQuestLog = true;

        // Find the Quest Log layer
        GameObject uiCanvas = GameObject.Find("UICanvas").gameObject;
        GameObject questLog = uiCanvas.transform.Find("QuestLog").gameObject;
		questLog.SetActive(true);

        // Find the Backdrop object in the scene
        GameObject backdrop = uiCanvas.transform.Find("Backdrop").gameObject;

        // Toggle the visibility of the backdrop based on Quest Log state
        backdrop.SetActive(true);

        // Make sure the player can't move while Quest Log is open
        GameObject.Find("Player").gameObject.GetComponent<PlayerMovement>().immobilized = true;
		
    }

    public void HideQuestLog()
    {
		
        viewingQuestLog = false;

        // Find the Quest Log layer
        GameObject uiCanvas = GameObject.Find("UICanvas").gameObject;
        GameObject questLog = uiCanvas.transform.Find("QuestLog").gameObject;
        questLog.SetActive(false);

        // Find the Backdrop object in the scene
        GameObject backdrop = uiCanvas.transform.Find("Backdrop").gameObject;

        // Toggle the visibility of the backdrop based on Quest Log state
        backdrop.SetActive(false);

        GameObject.Find("Player").gameObject.GetComponent<PlayerMovement>().immobilized = false;
		
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
	
	public void UpdateQuests()
	{
		 for (int q = 0; q < quests.Count; q++)
		 {
			 
		 }
	}

    /**
     * Music-player stuff
     **/
    public void ShowMusicPlayer(string instrument, string songName, string songNotes, string songFile, string knot)
    {
        viewingMusicPlayer = true;

        // Find the MusicPlayer layer
        GameObject uiCanvas = GameObject.Find("UICanvas").gameObject;
        GameObject musicPlayerView = uiCanvas.transform.Find("MusicPlayer").gameObject;
        Canvas musicPlayerCanvas = musicPlayerView.GetComponent<Canvas>();
        MusicPlayer musicPlayer = musicPlayerView.GetComponent<MusicPlayer>();

        // Set up the song
        musicPlayer.StartSong(instrument, songName, songNotes, songFile, knot);

        // Reveal MusicPlayer
        musicPlayerCanvas.enabled = true;

        // Prevent player from moving
        PlayerMovement playerMovement = GameObject.Find("Player").gameObject.GetComponent<PlayerMovement>();
        playerMovement.immobilized = true;
    }

    public void HideMusicPlayer()
    {
        viewingMusicPlayer = false;

        // Find the MusicPlayer layer
        GameObject uiCanvas = GameObject.Find("UICanvas").gameObject;
        GameObject musicPlayerView = uiCanvas.transform.Find("MusicPlayer").gameObject;
        Canvas musicPlayerCanvas = musicPlayerView.GetComponent<Canvas>();

        // Hide MusicPlayer
        musicPlayerCanvas.enabled = false;

        // Allow Player to move again
        PlayerMovement playerMovement = GameObject.Find("Player").gameObject.GetComponent<PlayerMovement>();
        playerMovement.immobilized = false;
    }
}
