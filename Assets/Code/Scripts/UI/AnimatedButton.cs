using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimatedButton : MonoBehaviour
{
    private Button triggerButton;
    public Image imageToAnimate;
    private Animator imageAnimator;

    private void Start()
    {
        imageAnimator = imageToAnimate.GetComponent<Animator>();
        triggerButton = GetComponent<Button>();
        triggerButton.onClick.AddListener(() => StartCoroutine(AnimateButtonImage()));
    }

    IEnumerator AnimateButtonImage()
    {
        Debug.Log("I was clicked!");
       
        imageAnimator.enabled = true;

        yield return new WaitForSeconds(3.45f);

        //imageAnimator.Play("Phono-Idle");
        imageAnimator.enabled = false;
    }



}
