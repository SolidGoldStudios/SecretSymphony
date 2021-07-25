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
        //if ((int)GameManager.Instance.inkStory.variablesState[inkVar] == 1)
        //{
        //    HideInstrument();
        //}
    }

    private void OnDestroy()
    {
        Debug.Log("*********** Instrument destroyed");
    }

    void Update()
    { 
        Debug.Log("*************** observing " + inkVar );
        GameManager.Instance.inkStory.ObserveVariable(inkVar, (string varName, object newValue) =>
        {
            Debug.Log("*************** has_trombone var changed!");
            if ((int)newValue == 1)
            {
                Debug.Log("*************** has_trombone is true");
                Debug.Log("*************** calling HideInstrument");
                HideInstrument();
            } else
            {
                Debug.Log("*************** has_trombone is false");
            }
        });
    }

    private void HideInstrument()
    {
        Debug.Log("*************** hiding instrument!");

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
