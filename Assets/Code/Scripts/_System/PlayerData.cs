using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerData : MonoBehaviour
{
	public static PlayerData Instance = null;
	public PlayerSaveData saveData = null;
	
	private bool startAutoSaving = false;
	private bool saveDataExist = false;
	private float timer = 0.0f;
	private float autoSaveDelay = 10.0f;
	
    void Awake()
    {
		if(Instance == null)
		{
			Instance = this;
		}
		else
		{
			Destroy(gameObject);
		}
		DontDestroyOnLoad(this.gameObject);
		
		Load();
    }

    void Update()
    {
		if (startAutoSaving)
		{
			timer += Time.deltaTime;
			
			if (timer > autoSaveDelay)
			{
				Save();
				timer = 0.0f;
			}
		}
		else
		{
			if (SceneManager.GetActiveScene().name != "TitleScreen")
			{
				startAutoSaving = true;
			}
		}
    }
	
	public void ClearData()
	{
		saveData = new PlayerSaveData();
	}
	
	public void Save()
	{
		BinaryFormatter bf = new BinaryFormatter();
		FileStream file = File.Create(Application.persistentDataPath + "/playerInfo.dat");
		PlayerSaveData data = new PlayerSaveData();
		
		Debug.Log(SceneManager.GetActiveScene().path);
		data.SetSceneName(SceneManager.GetActiveScene().path);
		data.SetInkJson(GameManager.Instance.inkStory.state.ToJson());
		data.SetNightGown(GameManager.Instance.wearingNightgown);
		data.SetInventory(GameManager.Instance.GetInventory());
		data.SetQuests(GameManager.Instance.GetQuests());
		data.SetBooks(GameManager.Instance.GetBooks());
		data.SetPages(GameManager.Instance.GetPages());
		
		bf.Serialize(file, data);
		file.Close();
	}
	
	public void Load()
	{
		if (File.Exists(Application.persistentDataPath + "/playerInfo.dat"))
		{
			saveDataExist = true;
			BinaryFormatter bf = new BinaryFormatter();
			FileStream file = File.Open(Application.persistentDataPath + "/playerInfo.dat", FileMode.Open);
			PlayerSaveData data = (PlayerSaveData)bf.Deserialize(file);
			saveData = data;
			file.Close();
		}
	}
	
	public void SetLoad()
	{
		//Load();
		GameManager.Instance.inkStory.state.LoadJson(saveData.GetInkJson());
		GameManager.Instance.wearingNightgown = saveData.GetNightGown();
		GameManager.Instance.SetInventory(saveData.GetInventory());
		GameManager.Instance.SetQuests(saveData.GetQuests());
		GameManager.Instance.SetBooks(saveData.GetBooks());
		GameManager.Instance.SetPages(saveData.GetPages());
	}
	
	public bool SaveFileExists()
	{
		return saveDataExist;
	}
}

[Serializable]
public class PlayerSaveData
{
	private string sceneName;
	
	private string inkJson;
	private bool nightGown;
	private List<InventoryItem> inventory;
	private List<QuestData> quests;
	private Hashtable books;
	private Hashtable pages;
	
	public void SetSceneName(string sceneName)
	{
		this.sceneName = sceneName;
	}
	
	public string GetSceneName()
	{
		return this.sceneName;
	}
	
	public void SetInkJson(string inkJson)
	{
		this.inkJson = inkJson;
	}
	
	public string GetInkJson()
	{
		return this.inkJson;
	}
	
	public void SetNightGown(bool nightGown)
	{
		this.nightGown = nightGown;
	}
	
	public bool GetNightGown()
	{
		return this.nightGown;
	}
	
	public void SetInventory(List<InventoryItem> inventory)
	{
		this.inventory = inventory;
	}
	
	public List<InventoryItem> GetInventory()
	{
		return this.inventory;
	}
	
	public void SetQuests(List<QuestData> quests)
	{
		this.quests = quests;
	}
	
	public List<QuestData> GetQuests()
	{
		return this.quests;
	}
	
	public void SetBooks(Hashtable books)
	{
		this.books = books;
	}
	
	public Hashtable GetBooks()
	{
		return this.books;
	}
	
	public void SetPages(Hashtable pages)
	{
		this.pages = pages;
	}
	
	public Hashtable GetPages()
	{
		return this.pages;
	}
	
}