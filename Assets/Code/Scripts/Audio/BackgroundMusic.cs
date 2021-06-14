using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMusic : MonoBehaviour
{
    public AudioSource pianoTrack;
    public AudioSource tromboneTrack;

    private bool pianoActive = false;
    private bool tromboneActive = false;

    private float pianoVolume;
    private float tromboneVolume;

    void Awake()
    {
        GameManager.Instance.inkStory.ObserveVariable("completed_piano_quest", (string varName, object newValue) =>
        {
//            pianoTrack = GameObject.Find("PianoTrack").GetComponent<AudioSource>();
//            tromboneTrack = GameObject.Find("TromboneTrack").GetComponent<AudioSource>();

            if ((int)newValue == 1)
            {
                pianoTrack.mute = false;
                pianoActive = true;

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
                tromboneActive = true;
            }
        });
    }

    public void MuteTracks()
    {
        pianoVolume = pianoTrack.volume;
        tromboneVolume = tromboneTrack.volume;

        if (pianoActive) StartCoroutine(AudioFade.FadeOut(pianoTrack, 1.0f));
        if (tromboneActive) StartCoroutine(AudioFade.FadeOut(tromboneTrack, 1.0f));
        //pianoTrack.mute = true;
        //tromboneTrack.mute = true;
    }

    public void UnmuteTracks()
    {
        if (pianoActive) StartCoroutine(AudioFade.FadeIn(pianoTrack, pianoVolume, 1.0f));
        if (tromboneActive) StartCoroutine(AudioFade.FadeIn(tromboneTrack, tromboneVolume, 1.0f));
        //pianoTrack.mute = !pianoActive;
        //tromboneTrack.mute = !tromboneActive;
    }
}

public static class AudioFade
{
    public static IEnumerator FadeIn(AudioSource audioSource, float targetVolume, float FadeTime)
    {
        while (audioSource.volume < targetVolume)
        {
            audioSource.volume += targetVolume * Time.deltaTime / FadeTime;

            yield return null;
        }
    }

    public static IEnumerator FadeOut(AudioSource audioSource, float FadeTime)
    {
        float startVolume = audioSource.volume;

        while (audioSource.volume > 0)
        {
            audioSource.volume -= startVolume * Time.deltaTime / FadeTime;

            yield return null;
        }
    }
}