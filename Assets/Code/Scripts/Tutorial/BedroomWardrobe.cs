using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BedroomWardrobe : InteractionAnimation
{
    public Animator animator;
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
        if (GameManager.Instance.hasFinishedTutorialMovement
            && GameManager.Instance.hasFinishedTutorialCurtains
            && GameManager.Instance.hasFinishedTutorialLamp)
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
    {
        if (!GameManager.Instance.hasFinishedTutorialWardrobe
            && GameManager.Instance.hasFinishedTutorialMovement
            && GameManager.Instance.hasFinishedTutorialLamp
            && GameManager.Instance.hasFinishedTutorialCurtains)
        {
            if (sparkleParticles != null)
            {
                sparkleParticles.SetActive(false);
            }
            GameManager.Instance.hasFinishedTutorialWardrobe = true;
            GameManager.Instance.wearingNightgown = false;
            animator.SetBool("wearingNightgown", false);
            NPCDialogue npcDialogue = dialogBox.GetComponent<NPCDialogue>();
            npcDialogue.ShowDialog(knotName);
            this.enabled = false;
        }
    }
}