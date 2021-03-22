using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameAudioSetting : MonoBehaviour
{
    void Start()
    {
		if (!PlayerPrefs.HasKey("gameVolume"))
		{
			PlayerPrefs.SetFloat("gameVolume", 0.5f);
		}
		AudioListener.volume = PlayerPrefs.GetFloat("gameVolume");
		Debug.Log(PlayerPrefs.GetFloat("gameVolume"));
    }
}
