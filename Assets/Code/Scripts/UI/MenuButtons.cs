using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtons : MonoBehaviour
{
	public SceneTransitionFade fadeSceneScript;
	
    public void MenuToggleInventory()
    {
        GameManager.Instance.ToggleInventory();
        Debug.Log("Toggling inventory!");
    }

    public void MenuToggleQuestLog()
    {
        GameManager.Instance.ToggleQuestLog();
        Debug.Log("Toggling quest log!");
    }
    
    public void MenuHideEverything()
    {
        GameManager.Instance.HideInventory();
        GameManager.Instance.HideQuestLog();

        // Hide the books layer
        GameObject uiCanvas = GameObject.Find("UICanvas").gameObject;
        GameObject books = uiCanvas.transform.Find("Books").gameObject;
        Canvas booksCanvas = books.GetComponent<Canvas>();
        booksCanvas.enabled = false;
    }

    public void MenuStartGame()
    {
		if (fadeSceneScript != null)
		{
			fadeSceneScript.FadeOut("Level/Scenes/Cutscenes/BedroomCutscene", new Vector2(.96f, -.19f), new Vector3(-1.4f, -1.03f, -10f), new Vector2(0f, 1f));
		}
		else
		{
			GameManager.Instance.LoadScene("Level/Scenes/Cutscenes/BedroomCutscene", new Vector2(.96f, -.19f), new Vector3(-1.4f, -1.03f, -10f), new Vector2(0f, 1f));
		}
    }
}
