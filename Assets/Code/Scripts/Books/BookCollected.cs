﻿using System.Collections;
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
		if (GameManager.Instance.books.ContainsKey(bookName))
		{
			ActivePages();
			gameObject.SetActive(false);
		}
	}
	
    public void ActivePages()
	{
		bool[] state = (bool[])GameManager.Instance.pages[bookName];
		for (int i = 0; i < pages.Length; i++)
		{
			pages[i].GetComponent<PageCollector>().bookName = bookName;
			pages[i].GetComponent<PageCollector>().pageNum = i;
			pages[i].SetActive(!state[i]);
		}
	}
}