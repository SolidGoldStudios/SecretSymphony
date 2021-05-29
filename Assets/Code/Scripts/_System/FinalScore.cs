using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class finalscore : MonoBehaviour
{
	public GameObject MainMenu;
	public GameObject Inventory;
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

	public void MenuToggleBook()
	{
		MenuHideAll();
		BookView.SetActive(true);
	}

	public void MenuHideAll()
	{
		MainMenu.SetActive(false);
		Inventory.SetActive(false);
		BookView.SetActive(false);
	}

	public void MenuQuit()
	{
		MenuHideAll();
		Backdrop.SetActive(false);

		Debug.Log("I should go to the finalscore now");
		GameManager.Instance.LoadScene("finalscore", new Vector2(-1.98f, -9.79f), new Vector3(-8.09f, -8.17f, -10f), new Vector2(1f, 1f));
	}

	public void MenuClose()
	{
		MenuHideAll();
		Backdrop.SetActive(false);
		playerMovement.immobilized = false;
	}
}