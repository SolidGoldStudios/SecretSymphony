using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookCollected : MonoBehaviour
{
	public GameObject[] pages;
	public string bookName;
	
	void Start()
	{
		if (!GameManager.Instance.pages.ContainsKey(bookName))
		{
			GameManager.Instance.pages.Add(bookName, new bool[pages.Length]);
		}
		else
		{
			ActivePages();
			gameObject.SetActive(false);
		}
	}
	
    public void ActivePages()
	{
		bool[] collected = (bool[])GameManager.Instance.pages[bookName];
		Debug.Log("ActivePages called " + pages.Length);
		for (int i = 0; i < pages.Length; i++)
		{
			pages[i].GetComponent<PageCollector>().bookName = bookName;
			pages[i].GetComponent<PageCollector>().pageNum = i;

			if (collected[i])
            {
				pages[i].SetActive(false);
            }
            else
            {
				SpriteRenderer renderer = pages[i].GetComponent<SpriteRenderer>();
				Color color = new Color(1f, 1f, 1f, 0f);

				renderer.color = color;

				pages[i].SetActive(true);
				pages[i].GetComponent<PageCollector>().FadeIn();
            }
		}
	}
}
