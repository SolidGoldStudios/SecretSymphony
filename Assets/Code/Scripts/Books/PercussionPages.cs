using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PercussionPages : IPages
{
	public List<string> pages { get; set; }
	public int pagesFound { get; set; }

	public void CreatePages()
	{
		pages = new List<string>();
		pages.Add("The percussion family is HUGE! There are lots of different instruments in it. Anything you can hit becomes a percussion instrument. Examples of percussion instrumentes in the orchestra are the snare drum, the bass drum, and the timpani.");
		pages.Add("'Percussion' means making sound by hitting something. Drums are in the percussion family, and they might just be the oldest kind of instrument.");
		pages.Add("Drums like the snare and bass drum sound best when the player strikes them on the tight flat part of the drum. This is called the drum 'head'.");
		pages.Add("Some percussion instruments make a 'tone' or a note that your ear can figure out. Some percussion instruments don't. The concert bass drum does not make a note, but the timpani drums do.");
		pages.Add("Because they can keep a steady rhythm, the instruments of the percussion family are typically used to keep time.");
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
