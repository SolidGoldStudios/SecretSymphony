using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleInstrumentScroll : MonoBehaviour
{ 
    public Image scrollOpenBG;
    public Image scrollClosedBG;
    public GameObject menuButton;

    private Button toggleButton;

    void Start()
    {
        toggleButton = GetComponent<Button>();
        toggleButton.onClick.AddListener(ToggleScroll);
    }

    void ToggleScroll()
    {
        if (scrollOpenBG.enabled == true)
        {
            scrollOpenBG.enabled = false;
            scrollClosedBG.enabled = true;
            menuButton.SetActive(true);
        }
        else
        {
            scrollOpenBG.enabled = true;
            scrollClosedBG.enabled = false;
            menuButton.SetActive(false);
        }
    }

}
