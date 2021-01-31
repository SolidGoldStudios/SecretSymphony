using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TransitionBedroom : MonoBehaviour
{
    private void OnDisable()
    {
        GameManager.Instance.LoadScene("Level/Scenes/Cutscenes/TownEarwormCutscene", new Vector2(-2.64f, -1.5f), new Vector3(-100f, 100f, -10f), new Vector2(0, -1));
    }
}
