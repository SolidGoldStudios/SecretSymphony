using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartDialogue : Interaction
{
    public GameObject dialogBox;
    public string knotName;
	public string questName;
	
	private GameObject questIcon;

    public void Start()
    {
        interactionIcon = Resources.Load<Sprite>("UI/cursor_speak");
        interactionIconActive = Resources.Load<Sprite>("UI/cursor_speak_active");
        moveToTarget = true;
		
		//Adding the QuestIcon through code if it matches quest name.
		if (questName != "" && (int)GameManager.Instance.inkStory.variablesState["ready_for_" + questName] == 1)
		{
			GameObject questIconPrefab = Resources.Load("Prefabs/Quest Icon") as GameObject;
			questIcon = Instantiate(questIconPrefab);
			Vector3 pos = questIcon.transform.position;
			questIcon.transform.parent = this.gameObject.transform;
			questIcon.transform.localPosition = pos;
		}
    }

    public override void Interact()
    {
        if (!dialogBox.activeInHierarchy)
        {
            NPCDialogue npcDialogue = dialogBox.GetComponent<NPCDialogue>();

            npcDialogue.ShowDialog(knotName);
        }
    }
}
