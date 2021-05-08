using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PageCreator : MonoBehaviour
{
	public Image bookBackground;
	public GameObject pagePrefab;
	public GameObject pages;
	public BookPager bookPager;
	public IPages activeBook;
	
	private Hashtable books = new Hashtable();
	
	void Awake()
	{
		books.Add("piano", new PianoPages());
		books.Add("brass", new BrassPages());
		books.Add("strings", new StringsPages());
		books.Add("winds", new WindsPages());
		books.Add("percussion", new PercussionPages());
	}
	
	public void CreatePages()
	{
		foreach (Transform child in pages.transform) 
		{
			GameObject.Destroy(child.gameObject);
		}
		
		for (int p = 0; p < activeBook.pagesFound; p++)
		{
			GameObject page = Instantiate(pagePrefab, pages.transform);
			page.GetComponent<Text>().text = activeBook.GetPageText(p);
			if ( p > 0)
			{
				page.SetActive(false);
			}
		}
		bookPager.PageCount(activeBook.pagesFound);
		bookPager.SetTotalPages(activeBook.GetMaxPages());
	}
	
	public void SetBook(string key)
	{
		activeBook = (IPages)books[key];
		Debug.Log(activeBook);
		activeBook.SetPagesFound((int)GameManager.Instance.books[key]);
		activeBook.CreatePages();
		bookBackground.sprite = Resources.Load<Sprite>("UI/book_" + key);
		CreatePages();
	}
}
