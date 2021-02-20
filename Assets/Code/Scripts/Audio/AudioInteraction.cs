using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioInteraction : Interaction
{ 
    private AudioSource source;

    void Start()
    {
        interactionIcon = Resources.Load<Sprite>("UI/cursor_speak");
        interactionIconActive = Resources.Load<Sprite>("UI/cursor_speak_active");
        moveToTarget = true;

        source = GetComponent<AudioSource>();
    }

    public override void Interact()
    {
        if (source) source.Play();
    }
}