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
                    SetIdleAnimation();
                }
            });
        }
    }

    private void SetIdleAnimation()
    {

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
