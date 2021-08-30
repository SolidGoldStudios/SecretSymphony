using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class Collectable : Interaction
{
    public string itemName;
    public string description;
    public string icon;
    public int weight;
    public int value;
    public bool disabled = false;
	public bool unique;
	public bool book;
    public string clickAction;
    public GameObject sparkleParticles;
	
    AudioSource audioSource;


    private void Start()
    {
		if (InventoryController.CheckForInventoryItem(itemName))
		{
			if (book)
			{
				gameObject.GetComponent<BookCollected>().ActivePages();
			}
			gameObject.SetActive(false);
		}

        interactionIcon = Resources.Load<Sprite>("UI/cursor_interact");
        interactionIconActive = Resources.Load<Sprite>("UI/cursor_interact_active");
    }

    public override void Interact()
    {
        if (!disabled)
        {
            GameManager.Instance.ShowTooltipWithTimeout("Collected " + itemName.Replace("+", " ") + "!");
            audioSource = GetComponent<AudioSource>();
            if (audioSource != null)
            {
                audioSource.Play();
            }

            if (sparkleParticles != null)
            {
                sparkleParticles.SetActive(false);
            }
			
            InventoryItem item = ItemCreator.CreateInventoryItem(itemName, description, icon, weight, value, unique, clickAction);
			InventoryController.AddInventoryItem(item);
			
			if (book)
			{
                BookCollected bookCollected = gameObject.GetComponent<BookCollected>();
                if (!GameManager.Instance.pages.ContainsKey(bookCollected.bookName))
                {
                    GameManager.Instance.pages.Add(bookCollected.bookName, new bool[bookCollected.pages.Length]);
                    bookCollected.ActivePages();
                }
            }
			
            gameObject.SetActive(false);

            interactionIcon = Resources.Load<Sprite>("UI/cursor");
            interactionIconActive = Resources.Load<Sprite>("UI/cursor_active");
        }
    }
}
