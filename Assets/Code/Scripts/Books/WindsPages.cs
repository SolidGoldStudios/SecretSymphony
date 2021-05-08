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
		pages.Add("The woodwind instruments come in all different shapes and sizes, and each one adds a distinct sound to the orchestra. Players make music with woodwinds by blowing air into them and over a sharp edge. There are two main types of woodwinds - the reed instruments and the flutes.");
		pages.Add("Some wind instruments have 'reeds,' which help the air vibrate. The flute, however, does not.");
		pages.Add("The flute is a very old kind of instrument. Like the piano, it has keys, but they look very different!");
		pages.Add("The player blows air over the mouthpiece and presses down the keys to change the way air moves through the flute. The flute player's tongue can stop the air to create breaks between notes.");
		pages.Add("The three main sections of the flute are the head joint, body joint, and foot joint.");
		pages.Add("Peter Pan plays a 'pan flute,' which has many different tubes pointing straight at the player. The concerto flute is different. The player holds it sideways. This makes it a 'transverse' flute.");
		pages.Add("A person who plays a flute is sometimes called a 'flautist,' and sometimes called a 'flutist' or 'flute player.' Flutes can be in orchestras, and also marching bands. It must be nice to have such a light instrument to carry!");
	}

	public void SetPagesFound(int num)
	{
		pagesFound = num;
	}

	public string GetPageText(int pageNum)
	{
		return pages[pageNum];
	}
	
	public int GetMaxPages()
	{
		return this.pages.Count;
	}
}
