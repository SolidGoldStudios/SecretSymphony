using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Gates : Interaction
{
	private Animator animator;
	private bool gateClosed = true;
	
	void Start()
	{
		animator = GetComponent<Animator>();
		
		interactionIcon = Resources.Load<Sprite>("UI/cursor_interact");
        interactionIconActive = Resources.Load<Sprite>("UI/cursor_interact_active");
	}
	
	public override void Interact()
    {
		if (gateClosed)
		{
			animator.SetBool("interactionSwitch", gateClosed);
			gameObject.GetComponent<NavMeshObstacle>().enabled = false;
		}
		interactionIcon = Resources.Load<Sprite>("UI/cursor");
        interactionIconActive = Resources.Load<Sprite>("UI/cursor_active");
	}
}
