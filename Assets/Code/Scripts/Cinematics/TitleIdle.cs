using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleIdle : MonoBehaviour
{
    void OnEnable()
    {
        GameManager.Instance.LoadScene("IdleScreen", new Vector2(-2.571f, -62.41f), new Vector3(-8f, -8.17f, -10f), new Vector2(0, 0));
    }
}
