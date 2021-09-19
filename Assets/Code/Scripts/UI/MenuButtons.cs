using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuButtons : MonoBehaviour
{	
	public GameObject MainMenu;
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
	
	public void MenuToggleBook()
	{
		MenuHideAll();
    BookView.SetActive(true);
	}
	
	public void MenuHideAll()
	{
		MainMenu.SetActive(false);
		BookView.SetActive(false);
	}

		public void MenuQuit()
    {
			MenuHideAll();
			Backdrop.SetActive(false);

			Debug.Log("I should be returning to the Title Screen now");
			GameManager.Instance.LoadScene("TitleScreen", new Vector2(-1.98f, -9.79f), new Vector3(-8.09f, -8.17f, -10f), new Vector2(1f, 1f));
		}
	
    
    public void MenuClose()
    {
			MenuHideAll();
			Backdrop.SetActive(false);
			playerMovement.immobilized = false;
    }
}
