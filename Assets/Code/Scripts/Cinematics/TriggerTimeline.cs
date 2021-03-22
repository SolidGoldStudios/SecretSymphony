using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class TriggerTimeline : Interaction
{
    public PlayableDirector timeline;
    public Animator animator;

    public void Start()
    {
        if ((blockedBy == null) || (!blockedBy.activeInHierarchy))
        {
            interactionIcon = Resources.Load<Sprite>("UI/cursor_interact");
            interactionIconActive = Resources.Load<Sprite>("UI/cursor_interact_active");
        }
    }

    public void Update()
    {
        if ((blockedBy == null) || (!blockedBy.activeInHierarchy))
        {
            interactionIcon = Resources.Load<Sprite>("UI/cursor_interact");
            interactionIconActive = Resources.Load<Sprite>("UI/cursor_interact_active");
        }
    }

    public override void Interact()
    {
        if ((blockedBy == null) || (!blockedBy.activeInHierarchy)) {
            timeline.Play();

            if (animator != null) animator.SetBool("interactionSwitch", true);
        }
    }
}
