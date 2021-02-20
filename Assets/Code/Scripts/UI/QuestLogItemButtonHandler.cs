using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestLogItemButtonHandler : MonoBehaviour
{
	public int questIndex;
	public QuestLogController questLogController;
	public GameObject cursor;
	public Text questTitle;
	
    public void UpdateQuestIndex()
    {
        questLogController.ChangeLogEntry(questIndex);
    }
	
	public void IsSelected(bool selected)
	{
		cursor.SetActive(selected);
	}
}
