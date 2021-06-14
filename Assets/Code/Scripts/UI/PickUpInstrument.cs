using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickUpInstrument : MonoBehaviour
{
    public string inkVar;
    public GameObject sparkleParticles;
    public GameObject itemLight;

    // Start is called before the first frame update
    void Start()
    {
        if ((int)GameManager.Instance.inkStory.variablesState[inkVar] == 1)
        {
            HideInstrument();
        }

        GameManager.Instance.inkStory.ObserveVariable(inkVar, (string varName, object newValue) =>
        {
            if ((int)newValue == 1)
            {
                HideInstrument();
            }
        });
    }

    private void HideInstrument()
    {
        GetComponent<SpriteRenderer>().enabled = false;

        if (sparkleParticles != null)
        {
            sparkleParticles.SetActive(false);
        }

        if (itemLight != null)
        {
            itemLight.SetActive(false);
        }
    }
}
