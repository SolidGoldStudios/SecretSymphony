using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionAnimation : Interaction
{
    public bool interactionSwitch;
    private Animator animator;

    public void Start()
    {
        animator = GetComponent<Animator>();
    }

    public override void Interact()
    {
        interactionSwitch = !interactionSwitch;
        animator.SetBool("interactionSwitch", interactionSwitch);
    }
}
