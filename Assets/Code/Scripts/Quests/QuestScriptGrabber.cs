using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class QuestScriptGrabber
{
	public static Hashtable questScripts = new Hashtable();
	
	public static void CreateQuestHashtable()
	{
		questScripts.Add("InstrumentPianoPartOne", new InstrumentPianoPartOne());
	}
	
	public static IQuest GrabScript(string scriptName)
	{
		return (IQuest)questScripts[scriptName];
	}
}
