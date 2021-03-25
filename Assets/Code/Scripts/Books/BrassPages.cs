using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrassPages : IPages
{
	public List<string> pages { get; set; }
	public int pagesFound { get; set; }

	public void CreatePages()
	{
		pages = new List<string>();
		pages.Add("The trombone is a musical instrument in the brass family. The player blows air through a length of tubing to produce sound.");
		pages.Add("A trombonist adjusts the pitch by sliding an adjustable tube up and down, increasing or decreasing the overall length of tubing.");
		pages.Add("Brass fact #3");
		pages.Add("Brass fact #4");
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
