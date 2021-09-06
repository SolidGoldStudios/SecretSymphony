using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShrinkEarworm : MonoBehaviour
{
    private int wormState;
    public GameObject state0;
    public GameObject state1;
    public GameObject state2;
    public GameObject state3;
    public GameObject state4;

    void Start()
    {
        wormState = 0;

        /* Piano - percussion family */
        GameManager.Instance.inkStory.ObserveVariable("has_placed_piano", (string varName, object newValue) =>
        {
            if ((int)newValue == 1)
            {
                CheckPercussionFamily();
            }
        });

        /* Harp - percussion family */
        GameManager.Instance.inkStory.ObserveVariable("has_placed_harp", (string varName, object newValue) =>
        {
            if ((int)newValue == 1)
            {
                CheckPercussionFamily();
            }
        });

        /* Marimba - percussion family */
        GameManager.Instance.inkStory.ObserveVariable("has_placed_marimba", (string varName, object newValue) =>
        {
            if ((int)newValue == 1)
            {
                CheckPercussionFamily();
            }
        });

        /* Bass drum - percussion family */
        GameManager.Instance.inkStory.ObserveVariable("has_placed_bass_drum", (string varName, object newValue) =>
        {
            if ((int)newValue == 1)
            {
                CheckPercussionFamily();
            }
        });

        /* Snare drum - percussion family */
        GameManager.Instance.inkStory.ObserveVariable("has_placed_snare_drum", (string varName, object newValue) =>
        {
            if ((int)newValue == 1)
            {
                CheckPercussionFamily();
            }
        });

        /* French horn - brass family */
        GameManager.Instance.inkStory.ObserveVariable("has_placed_french_horn", (string varName, object newValue) =>
        {
            if ((int)newValue == 1)
            {
                CheckBrassFamily();
            }
        });

        /* Trumpet - brass family */
        GameManager.Instance.inkStory.ObserveVariable("has_placed_trumpet", (string varName, object newValue) =>
        {
            if ((int)newValue == 1)
            {
                CheckBrassFamily();
            }
        });

        /* Trombone - brass family */
        GameManager.Instance.inkStory.ObserveVariable("has_placed_trombone", (string varName, object newValue) =>
        {
            if ((int)newValue == 1)
            {
                CheckBrassFamily();
            }
        });

        /* Tuba - brass family */
        GameManager.Instance.inkStory.ObserveVariable("has_placed_tuba", (string varName, object newValue) =>
        {
            if ((int)newValue == 1)
            {
                CheckBrassFamily();
            }
        });

        /* Bass - string family */
        GameManager.Instance.inkStory.ObserveVariable("has_placed_bass", (string varName, object newValue) =>
        {
            if ((int)newValue == 1)
            {
                CheckStringFamily();
            }
        });

        /* Viola - string family */
        GameManager.Instance.inkStory.ObserveVariable("has_placed_viola", (string varName, object newValue) =>
        {
            if ((int)newValue == 1)
            {
                CheckStringFamily();
            }
        });

        /* Violin - string family */
        GameManager.Instance.inkStory.ObserveVariable("has_placed_violin", (string varName, object newValue) =>
        {
            if ((int)newValue == 1)
            {
                CheckStringFamily();
            }
        });

        /* Oboe - woodwind family */
        GameManager.Instance.inkStory.ObserveVariable("has_placed_oboe", (string varName, object newValue) =>
        {
            if ((int)newValue == 1)
            {
                CheckWoodwindFamily();
            }
        });

        /* Flute - woodwind family */
        GameManager.Instance.inkStory.ObserveVariable("has_placed_flute", (string varName, object newValue) =>
        {
            if ((int)newValue == 1)
            {
                CheckWoodwindFamily();
            }
        });

        /* Clarinet - woodwind family */
        GameManager.Instance.inkStory.ObserveVariable("has_placed_clarinet", (string varName, object newValue) =>
        {
            if ((int)newValue == 1)
            {
                CheckWoodwindFamily();
            }
        });
    }

    void CheckPercussionFamily() {
        if (
            ((int)GameManager.Instance.inkStory.variablesState["has_placed_piano"] == 1) &&
            ((int)GameManager.Instance.inkStory.variablesState["has_placed_harp"] == 1) &&
            ((int)GameManager.Instance.inkStory.variablesState["has_placed_marimba"] == 1) &&
            ((int)GameManager.Instance.inkStory.variablesState["has_placed_bass_drum"] == 1) &&
            ((int)GameManager.Instance.inkStory.variablesState["has_placed_snare_drum"] == 1)
        ) {
            wormState++;
            ChangeWormState();
        }
    }

    void CheckBrassFamily() {
        if (
            ((int)GameManager.Instance.inkStory.variablesState["has_placed_french_horn"] == 1) &&
            ((int)GameManager.Instance.inkStory.variablesState["has_placed_trumpet"] == 1) &&
            ((int)GameManager.Instance.inkStory.variablesState["has_placed_trombone"] == 1) &&
            ((int)GameManager.Instance.inkStory.variablesState["has_placed_tuba"] == 1)
        ) {
            wormState++;
            ChangeWormState();
        }
    }

    void CheckStringFamily() {
        if (
            ((int)GameManager.Instance.inkStory.variablesState["has_placed_bass"] == 1) &&
            ((int)GameManager.Instance.inkStory.variablesState["has_placed_viola"] == 1) &&
            ((int)GameManager.Instance.inkStory.variablesState["has_placed_violin"] == 1)
        ) {
            wormState++;
            ChangeWormState();
        }
    }

    void CheckWoodwindFamily() {
        if (
            ((int)GameManager.Instance.inkStory.variablesState["has_placed_oboe"] == 1) &&
            ((int)GameManager.Instance.inkStory.variablesState["has_placed_flute"] == 1) &&
            ((int)GameManager.Instance.inkStory.variablesState["has_placed_clarinet"] == 1)
        ) {
            wormState++;
            ChangeWormState();
        }
    }

    void ChangeWormState() {
        Debug.Log("Worm state: " + wormState);

        if (wormState == 4) {
            GameManager.Instance.inkStory.variablesState["worm_state_4"] = true;
            if (state0 != null) { state0.SetActive(false); }
            if (state1 != null) { state1.SetActive(false); }
            if (state2 != null) { state2.SetActive(false); }
            if (state3 != null) { state3.SetActive(false); }
            if (state4 != null) { state4.SetActive(true); }
        } else if (wormState == 3) {
            GameManager.Instance.inkStory.variablesState["worm_state_3"] = true;
            if (state0 != null) { state0.SetActive(false); }
            if (state1 != null) { state1.SetActive(false); }
            if (state2 != null) { state2.SetActive(false); }
            if (state3 != null) { state3.SetActive(true); }
            if (state4 != null) { state4.SetActive(false); }
        } else if (wormState == 2) {
            GameManager.Instance.inkStory.variablesState["worm_state_2"] = true;
            if (state0 != null) { state0.SetActive(false); }
            if (state1 != null) { state1.SetActive(false); }
            if (state2 != null) { state2.SetActive(true); }
            if (state3 != null) { state3.SetActive(false); }
            if (state4 != null) { state4.SetActive(false); }
        } else if (wormState == 1) {
            GameManager.Instance.inkStory.variablesState["worm_state_1"] = true;
            if (state0 != null) { state0.SetActive(false); }
            if (state1 != null) { state1.SetActive(true); }
            if (state2 != null) { state2.SetActive(false); }
            if (state3 != null) { state3.SetActive(false); }
            if (state4 != null) { state4.SetActive(false); }
        }
    }   
}
