using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackableItem : Interaction
{
    private Animator animator;
    private Animator playerAnimator;
    private bool interacted = false;

    public void Start()
    {
        animator = GetComponent<Animator>();
        playerAnimator = GameObject.Find("Player").GetComponent<Animator>();
    }

    public void Update()
    {
        if ((int)GameManager.Instance.inkStory.variablesState["has_scythe"] == 1)
        {
            interactionIcon = Resources.Load<Sprite>("UI/cursor_scythe");
            interactionIconActive = Resources.Load<Sprite>("UI/cursor_scythe_active");
        }
    }

    public override void Interact()
    {
        if (!interacted && ((int)GameManager.Instance.inkStory.variablesState["has_scythe"] == 1))
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
        playerAnimator.SetBool("attacking", true);
        yield return null;
        playerAnimator.SetBool("attacking", false);
        yield return new WaitForSeconds(0.5f);
    }
}

