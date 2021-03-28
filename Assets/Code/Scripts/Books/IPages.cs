using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPages
{
	List<string> pages {get; set;}
	int pagesFound {get; set;}

	void CreatePages();
    string GetPageText(int pageNum);
	void SetPagesFound(int num);
}
