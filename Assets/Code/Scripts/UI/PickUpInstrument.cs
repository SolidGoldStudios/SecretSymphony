using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickUpInstrument : MonoBehaviour
{
    public string inkVar;
    public GameObject sparkleParticles;
    public GameObject itemLight;
    private SpriteRenderer instrumentSprite;

    // Start is called before the first frame update
    void Start()
    {
        if ((int)GameManager.Instance.inkStory.variablesState[inkVar] == 1)
        {
            HideInstrument();
        } 
        else
        {
            GameManager.Instance.inkStory.RemoveVariableObserver(null, inkVar);
            GameManager.Instance.inkStory.ObserveVariable(inkVar, (string varName, object newValue) =>
            {
                if ((int)newValue == 1)
                {
                    HideInstrument();
                }
            });
        }
    }

    private void HideInstrument()
    {

        GameManager.Instance.inkStory.RemoveVariableObserver(null, inkVar);

        if (this != null)
        {
            instrumentSprite = GetComponent<SpriteRenderer>();

            if (instrumentSprite != null)
            {
                instrumentSprite.enabled = false;
            }
        }

        if (sparkleParticles != null)
        {
            Debug.Log("*************** hiding sparkles!");
            sparkleParticles.SetActive(false);
        }

        if (itemLight != null)
        {
            Debug.Log("*************** hiding light!");
            itemLight.SetActive(false);
        }
    }
}
