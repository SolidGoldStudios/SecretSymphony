using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PianoPages : IPages
{
    public List<string> pages {get;set;}
	public int pagesFound {get; set;}
	
	public void CreatePages()
	{
		pages = new List<string>();
		pages.Add("The piano is a musical instrument. The player makes sound by pressing the black and white keys.");
		pages.Add("The keys are attached to hammers, which hit bundles of string. The strings make beautiful sounds. You can make the sounds longer by pressing a pedal with your foot.");
		pages.Add("Many modern pianos have 88 keys. That's a lot! A person who plays piano professionally--a pianist--needs all 88 of them.");
	}
	
	public void SetPagesFound(int num)
	{
		pagesFound = num;
	}
	
	public string GetPageText(int pageNum)
	{
		return pages[pageNum];
	}
}
