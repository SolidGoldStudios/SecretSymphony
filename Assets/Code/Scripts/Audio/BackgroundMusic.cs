using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMusic : MonoBehaviour
{
    public AudioSource bassTrack;
    public AudioSource bassDrumTrack;
    public AudioSource clarinetTrack;
    public AudioSource fluteTrack;
    public AudioSource frenchHornTrack;
    public AudioSource harpTrack;
    public AudioSource marimbaTrack;
    public AudioSource oboeTrack;
    public AudioSource pianoTrack;
    public AudioSource snareDrumTrack;
    public AudioSource tromboneTrack;
    public AudioSource trumpetTrack;
    public AudioSource tubaTrack;
    public AudioSource violaTrack;
    public AudioSource violinTrack;

    private bool bassActive = false;
    private bool bassDrumActive = false;
    private bool clarinetActive = false;
    private bool fluteActive = false;
    private bool frenchHornActive = false;
    private bool harpActive = false;
    private bool marimbaActive = false;
    private bool oboeActive = false;
    private bool pianoActive = false;
    private bool snareDrumActive = false;
    private bool tromboneActive = false;
    private bool trumpetActive = false;
    private bool tubaActive = false;
    private bool violaActive = false;
    private bool violinActive = false;
    
    private float bassVolume;
    private float bassDrumVolume;
    private float clarinetVolume;
    private float fluteVolume;
    private float frenchHornVolume;
    private float harpVolume;
    private float marimbaVolume;
    private float oboeVolume;
    private float pianoVolume;
    private float snareDrumVolume;
    private float tromboneVolume;
    private float trumpetVolume;
    private float tubaVolume;
    private float violaVolume;
    private float violinVolume;

    void Awake()
    {

        GameManager.Instance.inkStory.ObserveVariable("completed_bass_quest", (string varName, object newValue) =>
        {
            if ((int)newValue == 1)
            {
                StartAllTracks();
                bassTrack.mute = false;
                bassActive = true;
            }
        });

        GameManager.Instance.inkStory.ObserveVariable("completed_bass_drum_quest", (string varName, object newValue) =>
        {
            if ((int)newValue == 1)
            {
                StartAllTracks();
                bassDrumTrack.mute = false;
                bassDrumActive = true;
            }
        });

        GameManager.Instance.inkStory.ObserveVariable("completed_clarinet_quest", (string varName, object newValue) =>
        {
            if ((int)newValue == 1)
            {
                StartAllTracks();
                clarinetTrack.mute = false;
                clarinetActive = true;
            }
        });

        GameManager.Instance.inkStory.ObserveVariable("completed_flute_quest", (string varName, object newValue) =>
        {
            if ((int)newValue == 1)
            {
                StartAllTracks();
                fluteTrack.mute = false;
                fluteActive = true;
            }
        });

        GameManager.Instance.inkStory.ObserveVariable("completed_french_horn_quest", (string varName, object newValue) =>
        {
            if ((int)newValue == 1)
            {
                StartAllTracks();
                frenchHornTrack.mute = false;
                frenchHornActive = true;
            }
        });

        GameManager.Instance.inkStory.ObserveVariable("completed_harp_quest", (string varName, object newValue) =>
        {
            if ((int)newValue == 1)
            {
                StartAllTracks();
                harpTrack.mute = false;
                harpActive = true;
            }
        });

        GameManager.Instance.inkStory.ObserveVariable("completed_marimba_quest", (string varName, object newValue) =>
        {
            if ((int)newValue == 1)
            {
                StartAllTracks();
                marimbaTrack.mute = false;
                marimbaActive = true;
            }
        });

        GameManager.Instance.inkStory.ObserveVariable("completed_oboe_quest", (string varName, object newValue) =>
        {
            if ((int)newValue == 1)
            {
                StartAllTracks();
                oboeTrack.mute = false;
                oboeActive = true;
            }
        });

        GameManager.Instance.inkStory.ObserveVariable("completed_piano_quest", (string varName, object newValue) =>
        {
            if ((int)newValue == 1)
            {
                StartAllTracks();
                pianoTrack.mute = false;
                pianoActive = true;
            }
        });

        GameManager.Instance.inkStory.ObserveVariable("completed_snare_drum_quest", (string varName, object newValue) =>
        {
            if ((int)newValue == 1)
            {
                StartAllTracks();
                snareDrumTrack.mute = false;
                snareDrumActive = true;
            }
        });

        GameManager.Instance.inkStory.ObserveVariable("completed_trombone_quest", (string varName, object newValue) =>
        {
            if ((int)newValue == 1)
            {
                StartAllTracks();
                tromboneTrack.mute = false;
                tromboneActive = true;
            }
        });

        GameManager.Instance.inkStory.ObserveVariable("completed_trumpet_quest", (string varName, object newValue) =>
        {
            if ((int)newValue == 1)
            {
                StartAllTracks();
                trumpetTrack.mute = false;
                trumpetActive = true;
            }
        });

        GameManager.Instance.inkStory.ObserveVariable("completed_tuba_quest", (string varName, object newValue) =>
        {
            if ((int)newValue == 1)
            {
                StartAllTracks();
                tubaTrack.mute = false;
                tubaActive = true;
            }
        });

        GameManager.Instance.inkStory.ObserveVariable("completed_viola_quest", (string varName, object newValue) =>
        {
            if ((int)newValue == 1)
            {
                StartAllTracks();
                violaTrack.mute = false;
                violaActive = true;
            }
        });

        GameManager.Instance.inkStory.ObserveVariable("completed_violin_quest", (string varName, object newValue) =>
        {
            if ((int)newValue == 1)
            {
                StartAllTracks();
                violinTrack.mute = false;
                violinActive = true;
            }
        });
    }

    private void StartAllTracks()
    {
        Debug.Log("starting all background music tracks");
        bassTrack.Play();
        bassDrumTrack.Play();
        clarinetTrack.Play();
        fluteTrack.Play();
        frenchHornTrack.Play();
        harpTrack.Play();
        marimbaTrack.Play();
        oboeTrack.Play();
        pianoTrack.Play();
        snareDrumTrack.Play();
        tromboneTrack.Play();
        trumpetTrack.Play();
        tubaTrack.Play();
        violaTrack.Play();
        violinTrack.Play();
    }

    public void MuteTracks()
    {
        /* There's got to be a better way... */ 
        bassVolume = bassTrack.volume;
        bassDrumVolume = bassDrumTrack.volume;
        clarinetVolume = clarinetTrack.volume;
        fluteVolume = fluteTrack.volume;
        frenchHornVolume = frenchHornTrack.volume;
        harpVolume = harpTrack.volume;
        marimbaVolume = marimbaTrack.volume;
        oboeVolume = oboeTrack.volume;
        pianoVolume = pianoTrack.volume;
        snareDrumVolume = snareDrumTrack.volume;
        tromboneVolume = tromboneTrack.volume;
        trumpetVolume = trumpetTrack.volume;
        tubaVolume = tubaTrack.volume;
        violaVolume = violaTrack.volume;
        violinVolume = violinTrack.volume;
        
        if (bassActive) StartCoroutine(AudioFade.FadeOut(bassTrack, 1.0f));
        if (bassDrumActive) StartCoroutine(AudioFade.FadeOut(bassDrumTrack, 1.0f));
        if (clarinetActive) StartCoroutine(AudioFade.FadeOut(clarinetTrack, 1.0f));
        if (fluteActive) StartCoroutine(AudioFade.FadeOut(fluteTrack, 1.0f));
        if (frenchHornActive) StartCoroutine(AudioFade.FadeOut(frenchHornTrack, 1.0f));
        if (harpActive) StartCoroutine(AudioFade.FadeOut(harpTrack, 1.0f));
        if (marimbaActive) StartCoroutine(AudioFade.FadeOut(marimbaTrack, 1.0f));
        if (oboeActive) StartCoroutine(AudioFade.FadeOut(oboeTrack, 1.0f));
        if (pianoActive) StartCoroutine(AudioFade.FadeOut(pianoTrack, 1.0f));
        if (snareDrumActive) StartCoroutine(AudioFade.FadeOut(snareDrumTrack, 1.0f));
        if (tubaActive) StartCoroutine(AudioFade.FadeOut(tubaTrack, 1.0f));
        if (violaActive) StartCoroutine(AudioFade.FadeOut(violaTrack, 1.0f));
        if (violinActive) StartCoroutine(AudioFade.FadeOut(violinTrack, 1.0f));
        if (tromboneActive) StartCoroutine(AudioFade.FadeOut(tromboneTrack, 1.0f));
        if (trumpetActive) StartCoroutine(AudioFade.FadeOut(trumpetTrack, 1.0f));
        //pianoTrack.mute = true;
        //tromboneTrack.mute = true;
    }

    public void UnmuteTracks()
    {
        if (pianoActive) StartCoroutine(AudioFade.FadeIn(pianoTrack, pianoVolume, 1.0f));
        if (tromboneActive) StartCoroutine(AudioFade.FadeIn(tromboneTrack, tromboneVolume, 1.0f));
        if (trumpetActive) StartCoroutine(AudioFade.FadeIn(trumpetTrack, trumpetVolume, 1.0f));
        if (bassActive) StartCoroutine(AudioFade.FadeIn(bassTrack, bassVolume, 1.0f));
        if (bassDrumActive) StartCoroutine(AudioFade.FadeIn(bassDrumTrack, bassDrumVolume, 1.0f));
        if (clarinetActive) StartCoroutine(AudioFade.FadeIn(clarinetTrack, clarinetVolume, 1.0f));
        if (fluteActive) StartCoroutine(AudioFade.FadeIn(fluteTrack, fluteVolume, 1.0f));
        if (frenchHornActive) StartCoroutine(AudioFade.FadeIn(frenchHornTrack, frenchHornVolume, 1.0f));
        if (harpActive) StartCoroutine(AudioFade.FadeIn(harpTrack, harpVolume, 1.0f));
        if (marimbaActive) StartCoroutine(AudioFade.FadeIn(marimbaTrack, marimbaVolume, 1.0f));
        if (oboeActive) StartCoroutine(AudioFade.FadeIn(oboeTrack, oboeVolume, 1.0f));
        if (snareDrumActive) StartCoroutine(AudioFade.FadeIn(snareDrumTrack, snareDrumVolume, 1.0f));
        if (tubaActive) StartCoroutine(AudioFade.FadeIn(tubaTrack, tubaVolume, 1.0f));
        if (violaActive) StartCoroutine(AudioFade.FadeIn(violaTrack, violaVolume, 1.0f));
        if (violinActive) StartCoroutine(AudioFade.FadeIn(violinTrack, violinVolume, 1.0f));
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