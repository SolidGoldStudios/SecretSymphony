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
	public PlayerSaveData  saveData = null;
	
	private bool startAutoSaving = false;
	private bool saveDataExist = false;
	private float timer = 0.0f;
	private float autoSaveDelay = 3.0f;
	
    void Awake()
    {
		if(Instance == null)
		{
			Instance = this;
		}
		else if (Instance != this)
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
		//data.SetQuests(GameManager.Instance.GetQuests());
		
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
			GameManager.Instance.inkStory.state.LoadJson(saveData.GetInkJson());
			GameManager.Instance.wearingNightgown = saveData.GetNightGown();
			GameManager.Instance.SetInventory(saveData.GetInventory());
			file.Close();
		}
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
	//private List<Quest> quests;
	
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
	
	/*
	public void SetQuests(List<Quest> quests)
	{
		this.quests = quests;
	}
	
	public List<Quest> GetQuests()
	{
		return this.quests;
	}
	*/
}