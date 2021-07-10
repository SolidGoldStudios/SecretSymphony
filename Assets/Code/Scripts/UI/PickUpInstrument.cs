using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickUpInstrument : MonoBehaviour
{
    public string inkVar;
    public GameObject sparkleParticles;
    public GameObject itemLight;
    SpriteRenderer instrumentSprite;

    // Start is called before the first frame update
    void Start()
    {
        instrumentSprite = GetComponent<SpriteRenderer>();
        //if ((int)GameManager.Instance.inkStory.variablesState[inkVar] == 1)
        //{
        //    HideInstrument();
        //}
    }

    void Update()
    {
        Debug.Log("Trombone status: " + instrumentSprite.enabled);

        GameManager.Instance.inkStory.ObserveVariable("has_trombone", (string varName, object newValue) =>
        {
            Debug.Log("has_trombone var changed!");
            if ((int)newValue == 1)
            {
                Debug.Log("has_trombone is true, hiding instrument");
                HideInstrument();
            } else
            {
                Debug.Log("has_trombone is false");
            }
        });
    }

    private void HideInstrument()
    {
        Debug.Log("Hiding instrument!");
        instrumentSprite.enabled = false;

        if (sparkleParticles != null)
        {
            Debug.Log("Hiding sparkles!");
            sparkleParticles.SetActive(false);
        }

        //if (itemLight != null)
        //{
        //    itemLight.SetActive(false);
        //}
    }
}
