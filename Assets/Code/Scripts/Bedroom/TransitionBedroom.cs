using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TransitionBedroom : MonoBehaviour
{
    private void OnDisable()
    {
        GameManager.Instance.LoadScene("Level/Scenes/Farm/Home/Bedroom", new Vector2(-0.68f, -0.36f), new Vector3(-1.65f, -1f, -10), new Vector2(0, -1));
    }
}
