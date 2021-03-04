using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuButtons : MonoBehaviour
{	
	public GameObject MainMenu;
	public GameObject Inventory;
	public GameObject QuestLog;
	public GameObject BookView;
	public GameObject Backdrop;
	
	
	private PlayerMovement playerMovement;
	
	void Start()
	{
		playerMovement = GameObject.Find("Player").gameObject.GetComponent<PlayerMovement>();
		MenuClose();
	}
	
	public void MainMenuOpen()
	{
        playerMovement.immobilized = true;
		MainMenu.SetActive(true);
		Backdrop.SetActive(true);
	}
	
    public void MenuToggleInventory()
    {
		MenuHideAll();
        Inventory.SetActive(true);
    }

    public void MenuToggleQuestLog()
    {
		MenuHideAll();
        QuestLog.SetActive(true);
    }
	
	public void MenuToggleBook()
	{
		MenuHideAll();
        BookView.SetActive(true);
	}
	
	public void MenuHideAll()
	{
		MainMenu.SetActive(false);
		Inventory.SetActive(false);
		QuestLog.SetActive(false);
		BookView.SetActive(false);
	}
    
    public void MenuClose()
    {
		MenuHideAll();
		Backdrop.SetActive(false);
		playerMovement.immobilized = false;
    }
}
