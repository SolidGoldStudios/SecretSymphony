using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BedroomCurtains : Interaction
{
    public bool interactionSwitch;
    public GameObject sparkleParticles;
    public GameObject dialogBox;
    public string knotName;
    private Animator animator;
    AudioSource audioSource;

    private void Start()
    {
        animator = GetComponent<Animator>();

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
    {
        if (!GameManager.Instance.hasFinishedTutorialCurtains && GameManager.Instance.hasFinishedTutorialMovement)
        {
            if (sparkleParticles != null)
            {
                sparkleParticles.SetActive(false);
            }

            interactionSwitch = !interactionSwitch;
            animator.SetBool("interactionSwitch", interactionSwitch);

            audioSource = GetComponent<AudioSource>();
            if (audioSource != null)
            {
                audioSource.Play();
            }

            GameManager.Instance.hasFinishedTutorialCurtains = true;
            NPCDialogue npcDialogue = dialogBox.GetComponent<NPCDialogue>();
            npcDialogue.ShowDialog(knotName);

            this.enabled = false;
        }
    }
}
