using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RevealInstrument : MonoBehaviour
{
    public GameObject filled;
    public string placedVar;

    void Start()
    {
        GameManager.Instance.inkStory.ObserveVariable(placedVar, (string varName, object newValue) =>
        {
            if ((int)newValue == 1)
            {
                ShowFilled();
            }
        });
    }

    void ShowFilled() {
        if (filled != null) {
            filled.SetActive(true);
        }
    }
}
