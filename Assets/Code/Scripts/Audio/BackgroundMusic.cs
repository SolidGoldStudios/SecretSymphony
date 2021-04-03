using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMusic : MonoBehaviour
{
    public AudioSource pianoTrack;
    public AudioSource tromboneTrack;

    void Awake()
    {
        GameManager.Instance.inkStory.ObserveVariable("completed_piano_quest", (string varName, object newValue) =>
        {
//            pianoTrack = GameObject.Find("PianoTrack").GetComponent<AudioSource>();
//            tromboneTrack = GameObject.Find("TromboneTrack").GetComponent<AudioSource>();

            if ((int)newValue == 1)
            {
                pianoTrack.mute = false;
                pianoTrack.Play();
                tromboneTrack.Play();
            }
        });

        GameManager.Instance.inkStory.ObserveVariable("completed_trombone_quest", (string varName, object newValue) =>
        {
//            tromboneTrack = GameObject.Find("TromboneTrack").GetComponent<AudioSource>();

            if ((int)newValue == 1)
            {
                tromboneTrack.mute = false;
            }
        });
    }
}
