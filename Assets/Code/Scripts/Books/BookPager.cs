using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BookPager : MonoBehaviour
{
    public GameObject buttonPrev;
    public GameObject buttonNext;
    public GameObject currentPage;
    public GameObject totalPages;
    public GameObject facts;

    private int numPages = 0;
    private int index = 1;

    void OnEnable()
    {
		index = 1;
    }

    public void NextPage()
    {
        // Hide child of Facts at current index
        HideFact(index);

        // Increment the index
        if (index < numPages)
        {
            index++;
        }
        else
        {
            index = 1;
        }

        // Update the currentPage text
        UpdateCurrentPage(index);

        // Show the child of Facts at new index
        ShowFact(index);
    }
	
	public void PageCount(int num)
	{
		numPages = num;
    }
	
	public void SetTotalPages(int num)
	{
		Text totalPagesText = totalPages.gameObject.GetComponent<Text>();
        totalPagesText.text = num.ToString();
	}

    public void PrevPage()
    {
        // Hide child of Facts at current index
        HideFact(index);

        // Decrement the index
        if (index > 1)
        {
            index--;
        }
        else
        {
            index = numPages;
        }

        // Update the currentPage text
        UpdateCurrentPage(index);

        // Show the child of Facts at new index
        ShowFact(index);
    }
	
	public void GoToNewestPage()
	{
		foreach (Transform child in facts.transform) 
		{
			child.gameObject.SetActive(false);
		}
        facts.transform.GetChild(facts.transform.childCount - 1).gameObject.SetActive(true);
		index = numPages;
		UpdateCurrentPage(index);
	}

    void UpdateCurrentPage(int iPage)
    {
        Text currentPageText = currentPage.gameObject.GetComponent<Text>();
        currentPageText.text = iPage.ToString();
    }

    void HideFact(int iFact)
    {
        GameObject childFact = facts.transform.GetChild(iFact - 1).gameObject;
        childFact.SetActive(false);
    }

    void ShowFact(int iFact)
    {
        GameObject childFact = facts.transform.GetChild(iFact - 1).gameObject;
        childFact.SetActive(true);
    }
}
