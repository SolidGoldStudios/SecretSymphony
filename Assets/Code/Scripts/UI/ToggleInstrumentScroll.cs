using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleInstrumentScroll : MonoBehaviour
{ 
    public Image scrollOpenBG;
    public Image scrollClosedBG;
    public GameObject menuButton;
    public GameObject InstrumentContainer;

    private Button toggleButton;
    private RectTransform rect;

    void Start()
    {
        toggleButton = GetComponent<Button>();
        toggleButton.onClick.AddListener(ToggleScroll);

        rect = GetComponent<RectTransform>();
    }

    void ToggleScroll()
    {
        if (scrollOpenBG.enabled == true)
        {
            scrollOpenBG.enabled = false;
            scrollClosedBG.enabled = true;
            menuButton.SetActive(true);
            InstrumentContainer.SetActive(false);
            rect.anchoredPosition3D = new Vector3(-49f, 0f, 0f);
        }
        else
        {
            scrollOpenBG.enabled = true;
            scrollClosedBG.enabled = false;
            menuButton.SetActive(false);
            InstrumentContainer.SetActive(true);
            rect.anchoredPosition3D = new Vector3(-312f, 0f, 0f);
        }
    }

}
