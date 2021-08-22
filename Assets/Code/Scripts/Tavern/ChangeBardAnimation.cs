using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeBardAnimation : MonoBehaviour
{
    public string inkVar;
    public GameObject newAnim;
    private SpriteRenderer bardSprite;

    void Start()
    {
        Debug.Log("Starting bard script!");

        if ((int)GameManager.Instance.inkStory.variablesState[inkVar] == 1)
        {
            SetIdleAnimation();
        } 
        else
        {   
            //GameManager.Instance.inkStory.RemoveVariableObserver(null, inkVar);
            GameManager.Instance.inkStory.ObserveVariable(inkVar, (string varName, object newValue) =>
            {
                if ((int)newValue == 1)
                {
                    Debug.Log("Var changed!");
                    SetIdleAnimation();
                }
            });
        }
    }

    private void SetIdleAnimation()
    {
        //GameManager.Instance.inkStory.RemoveVariableObserver(null, inkVar);

        // if (this != null)
        // {
        //     Animator animator = GetComponent<Animator>();

        //     if (animator != null)
        //     {
        //         animator.runtimeAnimatorController = Resources.Load("Animation/Bard 1") as RuntimeAnimatorController;
        //     }
        // }

        // Hide the crying bard
        bardSprite = GetComponent<SpriteRenderer>();
        if (bardSprite != null)
        {
            bardSprite.enabled = false;
        }

        // Show the idle bard
        newAnim.SetActive(true);
    }

}
