using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    private string song = "";
    private string OdeToJoy = "EEFGGFED";

    public void Start()
    {
        Debug.Log("Music player start!");
    }

    public void PressKey(string key)
    {
        Debug.Log("Pressed the " + key + " key!");

        song += key;

        Debug.Log("Song so far: " + song);

        if (song.Equals(OdeToJoy))
        {
            Debug.Log("Finished the song!");
            song = "";
            GameManager.Instance.inkStory.variablesState["has_played_piano"] = true;
            GameManager.Instance.HideMusicPlayer();
            GameManager.Instance.ShowTooltipWithTimeout("You played the song!");

        }
        else if (song.Equals(OdeToJoy.Substring(0, song.Length)))
        {
            Debug.Log("Playing it right!");
        }
        else
        {
            Debug.Log("You fucked up!");
            song = "";
        }

    }
}