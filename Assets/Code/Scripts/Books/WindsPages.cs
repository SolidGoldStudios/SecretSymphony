using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindsPages : IPages
{
	public List<string> pages { get; set; }
	public int pagesFound { get; set; }

	public void CreatePages()
	{
		pages = new List<string>();
		pages.Add("Winds page #1");
		pages.Add("Winds page #2");
		pages.Add("Winds page #3");
		pages.Add("Winds page #4");
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
