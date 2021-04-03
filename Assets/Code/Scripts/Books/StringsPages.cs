using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StringsPages : IPages
{
	public List<string> pages { get; set; }
	public int pagesFound { get; set; }

	public void CreatePages()
	{
		pages = new List<string>();
		pages.Add("Ah, the strings! The instruments of the this family produce smooth, touching sounds by the vibration of their strings. There are more string instruments in the orchestra than any other family. Some members of the string family are the cello, the bass, and the violin.");
		pages.Add("The violin, sometimes called a 'fiddle,' is the instrument with the highest sound in the string family.");
		pages.Add("Parts of a violin include the bridge (it holds the strings up), the neck (the long part where you move your fingers), and the tuning pegs (which change the tightness of the strings).");
		pages.Add("To play the violin, the violinist draws a horse-hair bow over the violin strings, vibrating them and producing a beautiful sound. The way the bow is moved is called 'bowing.'");
		pages.Add("Many famous people have been associated with the violin. A 'luthier' (instrument maker) named Stradivarius made violins that people think sound just perfect; works like Antonio Vivaldi's 'The Four Seasons' really show off the violin's beautiful sounds.");
		pages.Add("The four strings vibrate, and the body of the instrument vibrates too!  The violin has two holes called 'F-holes' to help this process.");
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
