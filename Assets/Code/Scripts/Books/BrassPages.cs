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
		pages.Add("They're bright! They're shiny! They're loud! They are the brass instruments! A musician blows air into a brass intrument's mouthpiece and though its tubing to create a bright, clear sound. Members of the brass family include the trumpet, the tuba, and the trombone.");
		pages.Add("The trombone is a musical instrument in the brass family. ");
		pages.Add("The word 'trombone' means 'big trumpet,' but a trombone is different from a trumpet by more than just size!  This brass instrument is played by moving a long tube called a slide.");
		pages.Add("A trombone player is called a trombonist.  The trombonist moves the slide to seven positions to make different sounds on a trombone.");
		pages.Add("At the front of a trombone is the bell.  This is the big end of the trombone that makes the instrument's sound clear - and loud!");
		pages.Add("At the other end of the trombone is the mouthpiece.  By making a mouth shape - called embouchure - against the mouthpiece, a trombonist can correctly play the instrument.");
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
