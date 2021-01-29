using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class Collectable : Interaction
{
    public string itemName;
    public string description;
    public Sprite icon;
    public int weight;
    public int value;
    //public bool playerInRange;
    public bool disabled = false;
    AudioSource audioSource;

    bool collected = false;

    SpriteRenderer myRenderer;
    Light2D myLight;

    private void Start()
    {
        myRenderer = GetComponent<SpriteRenderer>();
        myLight = GetComponent<Light2D>();

        interactionIcon = Resources.Load<Sprite>("UI/cursor_interact");
        interactionIconActive = Resources.Load<Sprite>("UI/cursor_interact_active");
    }

    public override void Interact()
    {
        if (!collected && !disabled)
        {
            GameManager.Instance.ShowTooltipWithTimeout("Collected " + itemName + "!");
            audioSource = GetComponent<AudioSource>();
            if (audioSource != null)
            {
                audioSource.Play();
            }
            GameManager.Instance.AddInventoryItem(itemName, description, icon, weight, value);
            GameManager.Instance.DebugInventory();
            myRenderer.enabled = false;
            if (myLight)
            {
                myLight.enabled = false;
            }
            collected = true;

            interactionIcon = Resources.Load<Sprite>("UI/cursor");
            interactionIconActive = Resources.Load<Sprite>("UI/cursor_active");
        }
    }

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.CompareTag("Player"))
    //    {
    //        playerInRange = true;

    //        if (!collected && !disabled) GameManager.Instance.ShowTooltip("Press E to collect");
    //    }
    //}

    //private void OnTriggerExit2D(Collider2D collision)
    //{
    //    if (collision.CompareTag("Player"))
    //    {
    //        playerInRange = false;

    //        if (!collected) GameManager.Instance.HideTooltip();
    //    }
    //}
}
