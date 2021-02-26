using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestLogController : MonoBehaviour
{
	public Text questTitle;
	public Text questDecription;
	
	public GameObject questLogContents;
	public List<GameObject> questLogItems;
	public GameObject tasks;
	public List<GameObject> questTasks;
	
	public GameObject taskProgressPrefab;
	public GameObject questLogItemPrefab;
	
	private int currentIndex = 0;

	public void UpdateQuestLog()
	{	
		if (GameManager.Instance.quests.Count > 0)
		{
	
			foreach (Transform child in questLogContents.transform) 
			{
				GameObject.Destroy(child.gameObject);
				questLogItems = new List<GameObject>();
			}
			
			for (int q = 0; q < GameManager.Instance.quests.Count; q++)
			{
				GameManager.Instance.quests[q].Progress();
				questLogItems.Add((GameObject)Instantiate(questLogItemPrefab, questLogContents.transform));
				questLogItems[q].GetComponent<QuestLogItemButtonHandler>().questIndex = q;
				questLogItems[q].GetComponent<QuestLogItemButtonHandler>().questLogController = this;
				questLogItems[q].GetComponent<QuestLogItemButtonHandler>().questTitle.text = GameManager.Instance.quests[q].QuestTitle();
			}
			
			ChangeLogEntry(currentIndex);
		}
	}
	
	public void ChangeLogEntry(int index)
	{
		questTitle.text = GameManager.Instance.quests[index].QuestTitle();
		questDecription.text = GameManager.Instance.quests[index].QuestDescription();
		
		
		foreach (Transform child in tasks.transform) 
		{
			GameObject.Destroy(child.gameObject);
			questTasks = new List<GameObject>();
		}
		
		List<Text> tasksList = new List<Text>();
		for (int t = 0; t < GameManager.Instance.quests[index].questData.progress.Count; t++)
		{
			questTasks.Add((GameObject)Instantiate(taskProgressPrefab, tasks.transform));
			tasksList.Add(questTasks[t].GetComponent<Text>());
		}
		GameManager.Instance.quests[index].ProgressText(tasksList);
		
		
		questLogItems[currentIndex].GetComponent<QuestLogItemButtonHandler>().IsSelected(false);
		questLogItems[index].GetComponent<QuestLogItemButtonHandler>().IsSelected(true);
		currentIndex = index;
	}
}
