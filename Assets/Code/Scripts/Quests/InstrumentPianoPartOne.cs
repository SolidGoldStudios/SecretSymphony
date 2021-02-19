using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InstrumentPianoPartOne : IQuest
{
	public QuestData questData {get;set;}
	IQuest script {get; set;}
	
	public void Setup()
	{
		questData = new QuestData();
		
		questData.questName = "InstrumentPianoPartOne";
		questData.isComplete = false;
		
		questData.progress = new Hashtable();
		questData.progress.Add("ScytheAcquired", false);
		questData.progress.Add("ChoppedUpFirewood", false);
	}
	
	public void Progress()
	{
		if (GameManager.Instance.CheckForInventoryItem("Scythe"))
		{
			questData.progress["ScytheAcquired"] = true;
		}
		if ((int)GameManager.Instance.inkStory.variablesState["has_spoken_to_spirit_piano"] != 0)
		{
			questData.progress["ChoppedUpFirewood"] = true;
		}
	}
	
	public string QuestTitle()
	{
		return "Chop Up Firewood";
	}
	
	public string QuestDescription()
	{
		return "A strange lump of firewood showed up in the living room. I should get my scythe from the barn outside and chop it up for kindling.";
	}
	
	public void ProgressText(List<Text> tasks)
	{
		if (!(bool)questData.progress["ScytheAcquired"])
		{
			tasks[0].text = "Reterive Scythe";
			tasks[0].color = Color.red;
		}
		else
		{
			tasks[0].text = "Scythe Reterived";
			tasks[0].color = Color.green;
		}
		
		if (!(bool)questData.progress["ChoppedUpFirewood"])
		{
			tasks[1].text = "Chop wood thing in living room.";
			tasks[1].color = Color.red;
		}
		else
		{
			tasks[1].text = "Piano Discovered!";
			tasks[1].color = Color.green;
		}
	}
	
	
	public void Complete()
	{
		questData.isComplete = true;
	}
}
