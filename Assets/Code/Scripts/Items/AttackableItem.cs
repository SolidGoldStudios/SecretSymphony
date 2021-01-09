using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackableItem : Interaction
{
    public bool interactionSwitch;
    private Animator animator;
    private Animator playerAnimator;

    public void Start()
    {
        animator = GetComponent<Animator>();
        playerAnimator = GameObject.Find("Player").GetComponent<Animator>();

        interactionIcon = Resources.Load<Sprite>("UI/cursor_scythe");
        interactionIconActive = Resources.Load<Sprite>("UI/cursor_scythe_active");
    }

    public override void Interact()
    {
        interactionSwitch = !interactionSwitch;
        animator.SetBool("interactionSwitch", interactionSwitch);

        StartCoroutine(AttackCo());
    }

    private IEnumerator AttackCo()
    {
        playerAnimator.SetBool("attacking", true);
        yield return null;
        playerAnimator.SetBool("attacking", false);
        yield return new WaitForSeconds(0.5f);
    }
}

