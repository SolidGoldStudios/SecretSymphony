using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleTitleOnEnable : MonoBehaviour
{
    void OnEnable()
    {
        GameManager.Instance.LoadScene("TitleScreen", new Vector2(-2.571f, -62.41f), new Vector3(-8f, -8.17f, -10f), new Vector2(0, 0));
    }
}
