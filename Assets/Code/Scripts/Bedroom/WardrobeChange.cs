using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WardrobeChange : Interaction
{
    public Animator animator;

    public override void Interact()
    {
		GameManager.Instance.wearingNightgown = false;
		animator.SetBool("wearingNightgown", false);
		GameManager.Instance.ShowTooltipWithTimeout("All dressed!");
		this.enabled = false;
    }
}
