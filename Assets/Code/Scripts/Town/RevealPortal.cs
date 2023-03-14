using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RevealPortal : MonoBehaviour
{
    public GameObject portalOutline;
    public GameObject portalCenter;

    // Start is called before the first frame update
    void Start()
    {
        if (
            ((int)GameManager.Instance.inkStory.variablesState["has_piano"] == 1) && 
            ((int)GameManager.Instance.inkStory.variablesState["has_violin"] == 1) && 
            ((int)GameManager.Instance.inkStory.variablesState["has_viola"] == 1) && 
            ((int)GameManager.Instance.inkStory.variablesState["has_harp"] == 1) && 
            ((int)GameManager.Instance.inkStory.variablesState["has_bass"] == 1) && 
            ((int)GameManager.Instance.inkStory.variablesState["has_bass_drum"] == 1) && 
            ((int)GameManager.Instance.inkStory.variablesState["has_snare_drum"] == 1) && 
            ((int)GameManager.Instance.inkStory.variablesState["has_marimba"] == 1) && 
            ((int)GameManager.Instance.inkStory.variablesState["has_tuba"] == 1) && 
            ((int)GameManager.Instance.inkStory.variablesState["has_trombone"] == 1) && 
            ((int)GameManager.Instance.inkStory.variablesState["has_french_horn"] == 1) && 
            ((int)GameManager.Instance.inkStory.variablesState["has_trumpet"] == 1) && 
            ((int)GameManager.Instance.inkStory.variablesState["has_oboe"] == 1) && 
            ((int)GameManager.Instance.inkStory.variablesState["has_clarinet"] == 1) && 
            ((int)GameManager.Instance.inkStory.variablesState["has_flute"] == 1) 
        )
        {
            EnablePortal();
        }
    }
    
    // Update is called once per frame
    void Update()
    {
        if (
            ((int)GameManager.Instance.inkStory.variablesState["has_piano"] == 1) && 
            ((int)GameManager.Instance.inkStory.variablesState["has_violin"] == 1) && 
            ((int)GameManager.Instance.inkStory.variablesState["has_viola"] == 1) && 
            ((int)GameManager.Instance.inkStory.variablesState["has_harp"] == 1) && 
            ((int)GameManager.Instance.inkStory.variablesState["has_bass"] == 1) && 
            ((int)GameManager.Instance.inkStory.variablesState["has_bass_drum"] == 1) && 
            ((int)GameManager.Instance.inkStory.variablesState["has_snare_drum"] == 1) && 
            ((int)GameManager.Instance.inkStory.variablesState["has_marimba"] == 1) && 
            ((int)GameManager.Instance.inkStory.variablesState["has_tuba"] == 1) && 
            ((int)GameManager.Instance.inkStory.variablesState["has_trombone"] == 1) && 
            ((int)GameManager.Instance.inkStory.variablesState["has_french_horn"] == 1) && 
            ((int)GameManager.Instance.inkStory.variablesState["has_trumpet"] == 1) && 
            ((int)GameManager.Instance.inkStory.variablesState["has_oboe"] == 1) && 
            ((int)GameManager.Instance.inkStory.variablesState["has_clarinet"] == 1) && 
            ((int)GameManager.Instance.inkStory.variablesState["has_flute"] == 1) 
        )
        {
            EnablePortal();
        }
    }

    private void EnablePortal() {
        portalOutline.SetActive(true);
        portalCenter.SetActive(true);
        GameManager.Instance.backgroundMusic.GetComponent<BackgroundMusic>().MuteTracks();
    }
}