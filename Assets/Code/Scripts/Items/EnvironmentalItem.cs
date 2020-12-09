using System.Collections;
using System.Collections.Generic;
using System.Runtime.Versioning;
using UnityEngine;

public class EnvironmentalItem : MonoBehaviour
{
    public bool interactionSwitch;
    private Animator animator;

    public void Start()
    {
        animator = GetComponent<Animator>();
    }

    //public void OnMouseOver()
    //{
    //    if (Input.GetMouseButtonDown(0))
    //    {
    //        PlayerInteract();
    //    }
    //}

    public virtual void PlayerInteract()
    {
        interactionSwitch = !interactionSwitch;
        animator.SetBool("interactionSwitch", interactionSwitch);

        //Code for displaying dialogue goes here.

    }
}

