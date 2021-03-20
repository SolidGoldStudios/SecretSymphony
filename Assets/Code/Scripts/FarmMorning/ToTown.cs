using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToTown : MonoBehaviour
{
    void OnEnable()
    {
        GameManager.Instance.LoadScene("TownAfternoon", new Vector2(-2.571f, -62.41f), new Vector3(-2.571f, -57.92f, -44.120f), new Vector2(0,0));
    }
}
