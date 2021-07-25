using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishableItem : Interaction
{
    private Animator animator;
    private Animator playerAnimator;
    private bool interacted = false;
    public bool removeAfterDestroy = false;
    public int playerPosX = 0;
    public int playerPosY = 0;

    public void Start()
    {
        animator = GetComponent<Animator>();
        playerAnimator = GameObject.Find("Player").GetComponent<Animator>();
    }

    public void OnMouseOver()
    {
        if ((int)GameManager.Instance.inkStory.variablesState["has_pole"] == 1)
        {
            interactionIcon = Resources.Load<Sprite>("UI/cursor_fishing");
            interactionIconActive = Resources.Load<Sprite>("UI/cursor_fishing_active");
        }
    }

    public override void Interact()
    {
        if (!interacted && ((int)GameManager.Instance.inkStory.variablesState["has_pole"] == 1))
        {
            animator.SetBool("interactionSwitch", true);

            StartCoroutine(AttackCo());

            interacted = true;

            interactionIcon = Resources.Load<Sprite>("UI/cursor");
            interactionIconActive = Resources.Load<Sprite>("UI/cursor_active");

            
        }
    }

    private IEnumerator AttackCo()
    {
        playerAnimator.SetFloat("moveX", playerPosX);
		playerAnimator.SetFloat("moveY", playerPosY);
        playerAnimator.SetBool("fishing", true);
        yield return null;
        playerAnimator.SetBool("fishing", false);
        yield return new WaitForSeconds(0.5f);

        if (removeAfterDestroy)
        {
            gameObject.SetActive(false);
        }
    }
}
