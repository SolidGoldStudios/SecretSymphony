using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImmobilizeOnEnable : MonoBehaviour
{
    void OnEnable()
    {
        Debug.Log("Enabled!");
        GameManager.Instance.SetPlayerImmobilized(true);
    }

    void OnDisable()
    {
        Debug.Log("Disabled!");
        GameManager.Instance.SetPlayerImmobilized(false);
    }
}
