﻿using System.Collections;
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
    public string clickAction;
	
    AudioSource audioSource;


    private void Start()
    {
		if (InventoryController.CheckForInventoryItem(itemName))
		{
			gameObject.SetActive(false);
		}

        interactionIcon = Resources.Load<Sprite>("UI/cursor_interact");
        interactionIconActive = Resources.Load<Sprite>("UI/cursor_interact_active");
    }

    public override void Interact()
    {
        if (!disabled)
        {
            GameManager.Instance.ShowTooltipWithTimeout("Collected " + itemName + "!");
            audioSource = GetComponent<AudioSource>();
            if (audioSource != null)
            {
                audioSource.Play();
            }
			
            InventoryItem item = ItemCreator.CreateInventoryItem(itemName, description, icon, weight, value, unique, clickAction);
			InventoryController.AddInventoryItem(item);
			
            gameObject.SetActive(false);

            interactionIcon = Resources.Load<Sprite>("UI/cursor");
            interactionIconActive = Resources.Load<Sprite>("UI/cursor_active");
        }
    }
}
