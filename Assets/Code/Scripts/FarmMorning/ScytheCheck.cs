using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class ScytheCheck : MonoBehaviour
{
    void Start()
    {
        if ((int)GameManager.Instance.inkStory.variablesState["has_scythe"] != 0)
        {
            gameObject.SetActive(false);
        }
    }
}
