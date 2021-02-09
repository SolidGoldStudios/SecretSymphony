using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SceneTransitionFade : MonoBehaviour
{
	public float fadeTime;
	
	private bool fadingIn = true;
	private bool fadingOut = false;
	private  Image fadeScreen;
	private float timer = 0.0f;
	
	private Color fadeColor = new Color(0.0f, 0.0f, 0.0f, 1.0f);
	
	private string toScene;
	private Vector2 toPosition;
    private Vector3 toCameraPosition;
    private Vector2 toDirection;
	
    void Start()
    {
        fadeScreen = this.GetComponent<Image>();
    }

    void Update()
    {
        if (fadingIn)
		{
			timer += Time.deltaTime;
			if (fadeTime > timer)
			{
				fadeColor.a = 1.0f - (float)((255 * (timer / fadeTime)) / 255 );
				fadeScreen.color = fadeColor;
			}
			else
			{
				fadeColor.a = 0.0f;
				fadeScreen.color = fadeColor;
				fadingIn = false;
				timer = 0.0f;
			}
		}
		if (fadingOut)
		{
			timer += Time.deltaTime;
			if (fadeTime > timer)
			{
				fadeColor.a = (float)((255 * (timer / fadeTime)) / 255 );
				fadeScreen.color = fadeColor;
			}
			else
			{
				fadeColor.a = 1.0f;
				fadeScreen.color = fadeColor;
				timer = 0.0f;
				GameManager.Instance.LoadScene(toScene, toPosition, toCameraPosition, toDirection);
			}
		}
    }
	
	public void FadeOut(string scene, Vector2 position, Vector3 cameraPosition, Vector2 direction)
	{
		toScene = scene;
		toPosition = position;
		toCameraPosition = cameraPosition;
		toDirection = direction;
		fadingOut = true;
	}
}
