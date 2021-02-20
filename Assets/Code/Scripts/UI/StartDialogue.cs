using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartDialogue : Interaction
{
    public GameObject dialogBox;
    public string knotName;
	public bool questGiver = false;
	public string questName;
	
	private GameObject questIcon;

    public void Start()
    {
		Debug.Log("running StartDialogue Start");
        interactionIcon = Resources.Load<Sprite>("UI/cursor_speak");
        interactionIconActive = Resources.Load<Sprite>("UI/cursor_speak_active");
        moveToTarget = true;
		
		if (questGiver)
		{
			SetQuestIcon();
			SetQuestObservers();
		}
	}

	public void SetQuestIcon()
	{
		if (questGiver)
		{
			if ((int)GameManager.Instance.inkStory.variablesState["has_" + questName] == 1)
			{
				foreach (Transform child in gameObject.transform) 
				{
					GameObject.Destroy(child.gameObject);
				}
			}
			else if ((int)GameManager.Instance.inkStory.variablesState["ready_for_" + questName] == 1)
			{
				CreateQuestIcon("Quest Icon");
			}
		}
	}
	
	public void CreateQuestIcon(string type)
	{
		foreach (Transform child in gameObject.transform) 
		{
			GameObject.Destroy(child.gameObject);
		}
		GameObject questIconPrefab = Resources.Load("Prefabs/" + type) as GameObject;
		questIcon = Instantiate(questIconPrefab);
		Vector3 pos = questIcon.transform.position;
		questIcon.transform.parent = this.gameObject.transform;
		questIcon.transform.localPosition = pos;
	}
	
	public void SetQuestObservers()
	{
		GameManager.Instance.inkStory.ObserveVariable("has_" + questName, (string varName, object newValue) => 
		{
            if ((int)newValue == 1)
            {
                SetQuestIcon();
            }
		});
		GameManager.Instance.inkStory.ObserveVariable("ready_for_" + questName, (string varName, object newValue) => 
		{
            if ((int)newValue == 1)
            {
                SetQuestIcon();
            }
		});
	}
	
	void OnApplicationQuit()
	{
		questGiver = false;
	}
	
	void OnDestroy()
    {
		if (questGiver)
		{
			GameManager.Instance.inkStory.RemoveVariableObserver(null, "has_" + questName);
			GameManager.Instance.inkStory.RemoveVariableObserver(null, "ready_for_" + questName);
		}
    }

    public override void Interact()
    {
		dialogBox.SetActive(true);
        if (!dialogBox.activeInHierarchy)
        {
            NPCDialogue npcDialogue = dialogBox.GetComponent<NPCDialogue>();

            npcDialogue.ShowDialog(knotName);
        }
    }
}
