using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.UI;

public interface IQuest
{
	QuestData questData {get; set;}
	
	void Setup();
	void Progress();
	string QuestTitle();
	string QuestDescription();
	void ProgressText(List<Text> tasks);
	void Complete();
}

[Serializable]
public class QuestData
{
	public string questName {get; set;}
	public bool isComplete {get; set;}
	public Hashtable progress{get; set;}
}
