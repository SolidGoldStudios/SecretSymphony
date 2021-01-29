using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionAnimation : Interaction
{
    public bool interactionSwitch;
    private Animator animator;
    AudioSource audioSource;

    public void Start()
    {
        animator = GetComponent<Animator>();

        interactionIcon = Resources.Load<Sprite>("UI/cursor_interact");
        interactionIconActive = Resources.Load<Sprite>("UI/cursor_interact_active");

        audioSource = GetComponent<AudioSource>();
        if (audioSource != null)
        {
            audioSource.Play();
        }
    }

    public override void Interact()
    {
        interactionSwitch = !interactionSwitch;
        animator.SetBool("interactionSwitch", interactionSwitch);
    }
}
