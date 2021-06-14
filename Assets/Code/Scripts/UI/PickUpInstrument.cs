using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpInstrument : MonoBehaviour
{
    public string inkVar;

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
        enabled = false;
    }
}
