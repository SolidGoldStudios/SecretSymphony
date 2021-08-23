using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PageCollector : Interaction
{
	public string bookName;
	public int pageNum;
	public GameObject sparkleParticles;

	void OnEnable()
	{
		if ((blockedBy == null) || (!blockedBy.activeInHierarchy))
		{
			interactionIcon = Resources.Load<Sprite>("UI/cursor_interact");
			interactionIconActive = Resources.Load<Sprite>("UI/cursor_interact_active");
		}
	}

    //public void Update()
    //{
    //    if ((blockedBy == null) || (!blockedBy.activeInHierarchy))
    //    {
    //        interactionIcon = Resources.Load<Sprite>("UI/cursor_interact");
    //        interactionIconActive = Resources.Load<Sprite>("UI/cursor_interact_active");
    //    }
    //}


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

			if (sparkleParticles != null)
			{
				sparkleParticles.SetActive(false);
			}

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
			books.GetComponent<PageCreator>().bookPager.GoToNewestPage();
		}
	}

	public void FadeIn()
    {
		StartCoroutine(FadeInCo());
    }

	public IEnumerator FadeInCo()
	{
		SpriteRenderer renderer = transform.GetComponent<SpriteRenderer>();
		Color color = new Color(1f, 1f, 1f, 0f);
		for (float f = 0f; f < 1f; f += 0.1f)
		{
			color.a = f;
			renderer.color = color;
			yield return new WaitForSeconds(0.1f);
		}
        color.a = 1;
        renderer.material.color = color;
    }
}
