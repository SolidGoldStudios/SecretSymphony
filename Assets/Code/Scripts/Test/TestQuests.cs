using System.Collections;
using System.Collections.Generic;
using Ink.Runtime;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TestQuests : MonoBehaviour
{
	public SceneTransitionFade fadeSceneScript;
	
	PlayerSaveData testData = null;
	
	private List<QuestData> questsData = new List<QuestData>();
	private List<InventoryItem> inventory = new List<InventoryItem>();
	private TextAsset inkAsset;
	private Story inkStory;
	private Hashtable books = new Hashtable();
	private Hashtable pages = new Hashtable();
	
	private string scene;
	
	public void SetTestLoad()
	{
		testData.SetNightGown(false);
		//testData.SetInventory(inventory);
		testData.SetQuests(questsData);
		testData.SetBooks(books);
		testData.SetPages(pages);
		testData.SetInkJson(inkStory.state.ToJson());
		PlayerData.Instance.saveData = testData;
		GameManager.Instance.loadingFromSave = true;
		PlayerData.Instance.SetLoad();
		fadeSceneScript.FadeOut(scene);
	}
	
	public void TestPianoQuest()
	{
		testData = new PlayerSaveData();
		inkAsset = Resources.Load<TextAsset>("Dialogue/MainStory");
		inkStory = new Story(inkAsset.text);
		
		testData.SetNightGown(true);
		inkStory.variablesState["ready_for_piano_quest"] = 1;
		
		scene = "LivingRoom";
	}
	
	public void TestTromboneQuest()
	{
		TestPianoQuest();
		IQuest pianoQuest = new InstrumentPianoPartOne();
		pianoQuest.Setup();
		pianoQuest.Progress();
		pianoQuest.Complete();
		questsData.Add(pianoQuest.questData);
		
		inkStory.variablesState["has_piano_quest"] = 1;
		inkStory.variablesState["completed_piano_quest"] = 1;
		
		inkStory.variablesState["has_scythe"] = 1;
		inkStory.variablesState["has_hit_piano"] = 1;
		inkStory.variablesState["has_spoken_to_spirit_piano"] = 1;
		inkStory.variablesState["has_read_piano_book"] = 1;
		inkStory.variablesState["has_piano_key"] = 1;
		inkStory.variablesState["has_played_piano"] = 1;
		
		inkStory.variablesState["ready_for_trombone_quest"] = 1;
		
		InventoryItem scythe = ItemCreator.CreateInventoryItem("Scythe", " used for cutting wheat.", "Items/scythe", 0, 0, true, "");
		inventory.Add(scythe);
		
		//InventoryItem pianoBook = ItemCreator.CreateInventoryItem("Keyboards Book", "Keyboards rule", "Items/books/book_keyboards", 0, 0, true, "book:piano");
		//inventory.Add(pianoBook);
		//books.Add("piano", 4);
		
		//bool[] pianoPages = {true, true, true};
		//pages.Add("piano", pianoPages);
		
		scene = "FarmOutdoor";
	}
	
}
