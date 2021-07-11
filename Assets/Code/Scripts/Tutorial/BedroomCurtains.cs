using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BedroomCurtains : InteractionAnimation
{

    public GameObject dialogBox;
    public string knotName;

    private void Start()
    {

        if (sparkleParticles != null)
        {
            sparkleParticles.SetActive(false);
        }
    }

    private void Update()
    {
        if(GameManager.Instance.hasFinishedTutorialMovement)
        {
            if (sparkleParticles != null)
            {
                sparkleParticles.SetActive(true);
            }

            interactionIcon = Resources.Load<Sprite>("UI/cursor_interact");
            interactionIconActive = Resources.Load<Sprite>("UI/cursor_interact_active");
        }
    }

    public override void Interact()
    {;
        if (!GameManager.Instance.hasFinishedTutorialCurtains && GameManager.Instance.hasFinishedTutorialMovement)
        {
            if (sparkleParticles != null)
            {
                sparkleParticles.SetActive(false);
            }
            GameManager.Instance.hasFinishedTutorialCurtains = true;
            NPCDialogue npcDialogue = dialogBox.GetComponent<NPCDialogue>();
            npcDialogue.ShowDialog(knotName);
            this.enabled = false;
        }
    }
}
