using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicPlayer : MonoBehaviour
{
    public GameObject noteSlot;
    AudioSource audioSource;
    public NPCDialogue npcDialogue;
    public GameObject musicSheetContent;
    public Text musicSheetTitle;
	
	public MusicPlayerView musicPlayerView;

    private string songInProgress = "";
    private string instrument;
    private string songName;
    private string songNotes;
    private string songFile;
    private string resumeKnot;

    public void StartSong(string selectedInstrument, string selectedSongName, string selectedSongNotes, string selectedSongFile, string selectedKnot) 
    {
        instrument = selectedInstrument;
        songName = selectedSongName;
        songNotes = selectedSongNotes;
        songFile = selectedSongFile;
        resumeKnot = selectedKnot;

        Populate();

        GameManager.Instance.backgroundMusic.GetComponent<BackgroundMusic>().MuteTracks();
    }

    public void PressKey(string key)
    {
        songInProgress += key;

        if (songInProgress.Equals(songNotes))
        {
            // Make the last note opaque
            // Get the current note in the prefab and make it opaque
            Image noteImage = musicSheetContent.transform.GetChild(songInProgress.Length - 1).Find("Note" + songInProgress.Substring(songInProgress.Length - 1)).GetComponent<Image>();
            noteImage.color = new Color(255, 255, 255, 1);
            
            GameManager.Instance.SetPlayerImmobilized(true);

            // Play the full song 
            StartCoroutine(PlayFullSong());
			
            // Resume dialog
            StartCoroutine(ResumeDialog());

        }
        else if (songInProgress.Equals(songNotes.Substring(0, songInProgress.Length)))
        {
            // Get the current note in the prefab and make it opaque
            Image noteImage = musicSheetContent.transform.GetChild(songInProgress.Length - 1).Find("Note" + songInProgress.Substring(songInProgress.Length - 1)).GetComponent<Image>();
            noteImage.color = new Color(255, 255, 255, 1);
        }
        else
        {
            Populate();

            // Play a negative "bzzt" sound
            StartCoroutine(PlayWrongSound());

            // Reset the song in progress
            songInProgress = "";
        }

    }

    void Populate()
    {
        foreach (Transform child in musicSheetContent.transform)
        {
            GameObject.Destroy(child.gameObject);
        }

        GameObject newNote;        

        // Set the title
        musicSheetTitle.text = songName;

        // Create array from selected song
        char[] notes = songNotes.ToCharArray();

        // Populate the notes from the selected song
        foreach(char note in notes)
        {
            newNote = (GameObject)Instantiate(noteSlot, musicSheetContent.transform);

            // Find all the note images
            // There is probably a more efficient way to do this...
            GameObject noteA = newNote.transform.Find("NoteA").gameObject;
            Image noteAImage = noteA.GetComponent<Image>();
            GameObject noteB = newNote.transform.Find("NoteB").gameObject;
            Image noteBImage = noteB.GetComponent<Image>();
            GameObject noteC = newNote.transform.Find("NoteC").gameObject;
            Image noteCImage = noteC.GetComponent<Image>();
            GameObject noteD = newNote.transform.Find("NoteD").gameObject;
            Image noteDImage = noteD.GetComponent<Image>();
            GameObject noteE = newNote.transform.Find("NoteE").gameObject;
            Image noteEImage = noteE.GetComponent<Image>();
            GameObject noteF = newNote.transform.Find("NoteF").gameObject;
            Image noteFImage = noteF.GetComponent<Image>();
            GameObject noteG = newNote.transform.Find("NoteG").gameObject;
            Image noteGImage = noteG.GetComponent<Image>();

            // Enable the correct image
            if (note == 'A')
            {
                noteAImage.enabled = true;
            }
            else if (note == 'B')
            {
                noteBImage.enabled = true;
            }
            else if (note == 'C')
            {
                noteCImage.enabled = true;
            }
            else if (note == 'D')
            {
                noteDImage.enabled = true;
            }
            else if (note == 'E')
            {
                noteEImage.enabled = true;
            }
            else if (note == 'F')
            {
                noteFImage.enabled = true;
            }
            else if (note == 'G')
            {
                noteGImage.enabled = true;
            }
        }
    }

	IEnumerator PlayFullSong()
	{
		yield return new WaitForSeconds(1);
		audioSource = GetComponent<AudioSource>();
		audioSource.clip = Resources.Load<AudioClip>("Audio/" + songFile);
		audioSource.Play();
		
		songInProgress = "";
        GameManager.Instance.inkStory.variablesState["has_played_piano"] = true;
        musicPlayerView.HideMusicPlayer();

        // Show the victory pose and show the tooltip
        GameObject player = GameObject.Find("Player").gameObject;
        GameManager.Instance.RunRaiseArms(null, false);
        GameManager.Instance.ShowTooltipWithTimeout("You played the song!");
	}

    IEnumerator ResumeDialog()
    {
        yield return new WaitForSeconds(7.5f);
        GameManager.Instance.backgroundMusic.GetComponent<BackgroundMusic>().UnmuteTracks();
        npcDialogue.ShowDialog(resumeKnot);
    }

    IEnumerator PlayWrongSound()
    {
        yield return new WaitForSeconds(0.25f);
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = Resources.Load<AudioClip>("Audio/trivia_answer_wrong");
        audioSource.Play();
    }
}