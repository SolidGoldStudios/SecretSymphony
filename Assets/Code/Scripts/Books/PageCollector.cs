using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PageCollector : Interaction
{
	public string bookName;
	public int pageNum;
	
	void OnEnable()
	{
		if ((blockedBy == null) || (!blockedBy.activeInHierarchy))
		{
			interactionIcon = Resources.Load<Sprite>("UI/cursor_interact");
			interactionIconActive = Resources.Load<Sprite>("UI/cursor_interact_active");
		}
	}

	public void Update()
	{
		if ((blockedBy == null) || (!blockedBy.activeInHierarchy))
		{
			interactionIcon = Resources.Load<Sprite>("UI/cursor_interact");
			interactionIconActive = Resources.Load<Sprite>("UI/cursor_interact_active");
		}
	}


	public override void Interact()
    {
		if ((blockedBy == null) || (!blockedBy.activeInHierarchy))
		{
			GameManager.Instance.ShowTooltipWithTimeout("Found a lost page!");
			AudioSource audioSource = gameObject.GetComponent<AudioSource>();
			if (audioSource != null)
			{
				audioSource.Play();
			}

			GameManager.Instance.books[bookName] = (int)GameManager.Instance.books[bookName] + 1;
			Debug.Log(bookName + " now has " + GameManager.Instance.books[bookName] + " pages!");

			bool[] pagesCollected = (bool[])GameManager.Instance.pages[bookName];
			pagesCollected[pageNum] = true;
			GameManager.Instance.pages[bookName] = pagesCollected;

			gameObject.SetActive(false);

			interactionIcon = Resources.Load<Sprite>("UI/cursor");
			interactionIconActive = Resources.Load<Sprite>("UI/cursor_active");

			// Enable the backdrop
			GameObject uiCanvas = GameObject.Find("UICanvas").gameObject;
			GameObject backdrop = uiCanvas.transform.Find("Backdrop").gameObject;
			backdrop.SetActive(true);

			// Show the selected book
			GameObject books = uiCanvas.transform.Find("Books").gameObject;
			books.SetActive(true);
			books.GetComponent<PageCreator>().SetBook(bookName);
		}
	}
}
