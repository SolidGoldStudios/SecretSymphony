using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayerView : MonoBehaviour
{
	public GameObject musicPlayerViewer;
	public MusicPlayer musicPlayer;
	
    public void ShowMusicPlayer(string instrument, string songName, string songNotes, string songFile, string knot)
    {
		GameManager.Instance.playerMovement.immobilized = true;
		
		musicPlayerViewer.SetActive(true);
        musicPlayer.StartSong(instrument, songName, songNotes, songFile, knot);
		
    }

    public void HideMusicPlayer()
    {
		musicPlayerViewer.SetActive(false);

		GameManager.Instance.playerMovement.immobilized = false;
    }
}
