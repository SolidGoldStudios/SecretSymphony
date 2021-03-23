using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
	public SceneTransitionFade fadeSceneScript;
	
	public GameObject resumeButtonObject;
	
	void Start()
	{
		if(PlayerData.Instance.SaveFileExists() && SceneManager.GetActiveScene().name == "TitleScreen")
		{
			resumeButtonObject.SetActive(true);
		}
	}

    public void MenuStartGame()
    {
		PlayerData.Instance.ClearData();
		fadeSceneScript.FadeOut("Scenes/Cutscenes/BedroomCutscene", new Vector2(.96f, -.19f), new Vector3(-1.4f, -1.03f, -10f), new Vector2(0f, 1f));
    }
	
	public void MenuResumeGame()
	{
		PlayerData.Instance.Load();
		PlayerData.Instance.SetLoad();
		GameManager.Instance.loadingFromSave = true;
		fadeSceneScript.FadeOut(PlayerData.Instance.saveData.GetSceneName());
		
	}
}
