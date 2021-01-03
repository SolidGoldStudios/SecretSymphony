﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtons : MonoBehaviour
{
    public void MenuToggleInventory()
    {
        GameManager.Instance.ToggleInventory();
        Debug.Log("Toggling inventory!");
    }

    public void MenuToggleQuestLog()
    {
        GameManager.Instance.ToggleQuestLog();
        Debug.Log("Toggling quest log!");
    }
    
    public void MenuHideEverything()
    {
        GameManager.Instance.HideInventory();
        GameManager.Instance.HideQuestLog();
    }

    public void MenuStartGame()
    {
        //SceneManager.LoadScene("Level/Scenes/Farm/Home/BedroomCutscene");
        GameManager.Instance.LoadScene("Level/Scenes/Farm/Home/BedroomCutscene", new Vector2(.96f, -.19f), new Vector3(-1.65f, -2.72f, -10f), new Vector2(0f, 1f));
    }
}
