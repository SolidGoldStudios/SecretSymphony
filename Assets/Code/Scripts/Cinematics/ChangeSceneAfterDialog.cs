using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* *
 * TODO: This should use a delegate, but I don't know how to do that.
 * For now, it will have to live on the DialogBox in a relevant scene.
 * */
public class ChangeSceneAfterDialog : MonoBehaviour
{
    public string toScene;
    public Vector2 toPosition;
    public Vector3 toCameraPosition;
    public Vector2 toDirection;

    private void OnDisable()
    {
        GameManager.Instance.LoadScene(toScene, toPosition, toCameraPosition, toDirection);
    }
}
