using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrollInstrument : MonoBehaviour
{
    public string inkVar;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Button>().enabled = false;

        if ((int)GameManager.Instance.inkStory.variablesState[inkVar] == 1)
        {
            EnableInstrument();
        }

        GameManager.Instance.inkStory.ObserveVariable(inkVar, (string varName, object newValue) =>
        {
            if ((int)newValue == 1)
            {
               EnableInstrument();
            }
        });
    }

    private void EnableInstrument()
    {
        GetComponent<Image>().color = new Color(1f, 1f, 1f, 1f);
        GetComponent<Button>().enabled = true;
    }
}
