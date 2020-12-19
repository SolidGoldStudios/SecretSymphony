using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WardrobeChange : Interaction
{
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GameObject.Find("Player").gameObject.GetComponent<Animator>();
    }

    public override void Interact()
    {
        if (GameManager.Instance.wearingNightgown)
        {
            GameManager.Instance.wearingNightgown = false;
            animator.SetBool("wearingNightgown", false);
            GameManager.Instance.ShowTooltipWithTimeout("All dressed!");
        }
    }
}
