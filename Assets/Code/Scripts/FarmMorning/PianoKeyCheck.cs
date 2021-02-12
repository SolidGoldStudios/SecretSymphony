using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PianoKeyCheck : MonoBehaviour
{
    void Start()
    {
        if ((int)GameManager.Instance.inkStory.variablesState["has_spoken_to_spirit_piano"] != 0)
        {
            gameObject.SetActive(false);
        }
    }
}
