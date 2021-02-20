using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class QuestType
{
    public static IQuest SetQuestType(string questName)
	{
		if (questName == "InstrumentPianoPartOne")
		{
			return new InstrumentPianoPartOne();
		}
		else if (questName == "ThomasBirthdayBreakfestPartOne")
		{
			return new ThomasBirthdayBreakfestPartOne();
		}
		return null;
	}
}
