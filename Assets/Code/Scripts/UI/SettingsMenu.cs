using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
	public Slider volumeSlider;
	
    void Start()
    {
		volumeSlider.value = PlayerPrefs.GetFloat("gameVolume");
    }

    public void ChangeVolume()
	{
		PlayerPrefs.SetFloat("gameVolume", volumeSlider.value);
		PlayerPrefs.Save();
		AudioListener.volume = PlayerPrefs.GetFloat("gameVolume");
	}
}
