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

    private int numPages;
    private int i = 1;

    // Start is called before the first frame update
    void Start()
    {
        // Count the number of Facts
        numPages = facts.transform.childCount;

        // Update the totalPages text
        Text totalPagesText = totalPages.gameObject.GetComponent<Text>();
        totalPagesText.text = numPages.ToString();
    }

    public void NextPage()
    {
        // Hide child of Facts at current index
        HideFact(i);

        // Increment the index
        if (i < numPages)
        {
            i++;
        }
        else
        {
            i = 1;
        }

        // Update the currentPage text
        UpdateCurrentPage(i);

        // Show the child of Facts at new index
        ShowFact(i);
    }

    public void PrevPage()
    {
        // Hide child of Facts at current index
        HideFact(i);

        // Decrement the index
        if (i > 1)
        {
            i--;
        }
        else
        {
            i = numPages;
        }

        // Update the currentPage text
        UpdateCurrentPage(i);

        // Show the child of Facts at new index
        ShowFact(i);
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
