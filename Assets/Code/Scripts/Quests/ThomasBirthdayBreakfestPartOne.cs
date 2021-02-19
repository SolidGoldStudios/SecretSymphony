using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ThomasBirthdayBreakfestPartOne : IQuest
{
	public QuestData questData {get;set;}
	
	public void Setup()
	{
		questData = new QuestData();
		
		questData.questName = "ThomasBirthdayBreakfestPartOne";
		questData.isComplete = false;
		
		questData.progress = new Hashtable();
		questData.progress.Add("SaffronFlowers", 0);
		questData.progress.Add("RosemarySprigs", 0);
		questData.progress.Add("Mushrooms", 0);
	}
	
	public void Progress()
	{
		questData.progress["SaffronFlowers"] = GameManager.Instance.GetInventoryCount("Saffron");
		questData.progress["RosemarySprigs"] = GameManager.Instance.GetInventoryCount("Rosemary");
		questData.progress["Mushrooms"] = GameManager.Instance.GetInventoryCount("Mushroom");
		
		if ((int)questData.progress["SaffronFlowers"] >= 5 && (int)questData.progress["RosemarySprigs"] >= 5 && (int)questData.progress["Mushrooms"] >= 5)
		{
			Complete();
		}
		
		//questData.progress["ScytheAcquired"] = true;
	}
	
	public string QuestTitle()
	{
		return "Thomas' Birthday Breakfast!";
	}
	
	public string QuestDescription()
	{
		return "It's your brother's birthday and Mom wants you to collect some ingredients from around the farm to make this dish extra special! She mentioned that Saffron flowers can be found near the Northern Forest, the Rosemary has been seen growing near the rocky river banks, and the Mushrooms sprout up around the Southern Pond.";
	}
	
	public void ProgressText(List<Text> tasks)
	{
		if ((int)questData.progress["SaffronFlowers"] < 5)
		{
			tasks[0].text = questData.progress["SaffronFlowers"] + " out of 5 Saffron Flowers";
			tasks[0].color = Color.red;
		}
		else
		{
			tasks[0].text = "5 out of 5 Saffron Flowers.";
			tasks[0].color = Color.green;
		}
		if ((int)questData.progress["RosemarySprigs"] < 5)
		{
			tasks[1].text = questData.progress["RosemarySprigs"] + " out of 5 Rosemary Sprigs.";
			tasks[1].color = Color.red;
		}
		else
		{
			tasks[1].text = "5 out of 5 Rosemary Sprigs.";
			tasks[1].color = Color.green;
		}
		if ((int)questData.progress["Mushrooms"] < 5)
		{
			tasks[2].text = questData.progress["Mushrooms"] + " out of 5 Mushrooms.";
			tasks[2].color = Color.red;
		}
		else
		{
			tasks[2].text = "5 out of 5 Mushrooms.";
			tasks[2].color = Color.green;
		}
	}
	
	
	public void Complete()
	{
		questData.isComplete = true;
	}
}
