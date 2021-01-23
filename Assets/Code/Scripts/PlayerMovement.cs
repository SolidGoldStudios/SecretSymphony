using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Runtime.InteropServices.ComTypes;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.AI;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PlayerMovement : MonoBehaviour
{
    private NavMeshAgent navMeshAgent;
    private Animator animator;
    private GameObject interactionTarget = null;
    private SpriteRenderer interactionIcon;
    private bool moving = false;

    // Dialog variables
    public bool immobilized = false;

    // Scene variables
    private string sceneName;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        sceneName = SceneManager.GetActiveScene().name;
        navMeshAgent = GetComponent<NavMeshAgent>();
        navMeshAgent.updateRotation = false;
        navMeshAgent.updateUpAxis = false;

        interactionIcon = GameObject.Find("InteractionIcon").GetComponent<SpriteRenderer>();

        //attackAnimator = weapon.GetComponent<Animator>();
        //playerSilhouette = GameObject.Find("PlayerSprite_Silhouette");
        //silRenderer = playerSilhouette.GetComponent<SpriteRenderer>();

        if (GameManager.Instance.wearingNightgown)
        {
            animator.SetBool("wearingNightgown", true);
            animator.Play("Base Layer.Idle Nightgown");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (immobilized)
        {
            animator.SetBool("moving", false);
            return;
        }

        Vector3 velocity = navMeshAgent.steeringTarget - transform.position;

        if (velocity != Vector3.zero || navMeshAgent.pathPending)
        {
            //Debug.Log("moving");
            moving = true;
            animator.SetFloat("moveX", velocity.x);
            animator.SetFloat("moveY", velocity.y);
            animator.SetBool("moving", true);
        }
        else if (moving == true)
        {
            //Debug.Log("stopped");
            moving = false;
            animator.SetBool("moving", false);
            interactionIcon.sprite = null;
            interactionIcon.enabled = false;

            if (interactionTarget != null)
            {
                Interaction[] interactions = interactionTarget.transform.GetComponents<Interaction>();

                foreach (Interaction interaction in interactions)
                {
                    if (interaction.enabled) interaction.Interact();
                }

                interactionTarget = null;
            }
        }

        if (Input.GetKeyDown(KeyCode.I))
        {
            GameManager.Instance.ToggleInventory();
        }

        // Show/hide quest log
        if (Input.GetKeyDown(KeyCode.L))
        {
            GameManager.Instance.ToggleQuestLog();
        }

        if (GameManager.Instance.viewingInventory)
        {
            //if (Input.GetAxisRaw("Horizontal") < 0)
            if (Input.GetKeyDown(KeyCode.A))
            {
                if (GameManager.Instance.inventoryCursor > 0) GameManager.Instance.inventoryCursor -= 1;
                GameManager.Instance.UpdateInventory();
            }

            //if (Input.GetAxisRaw("Horizontal") > 0)
            if (Input.GetKeyDown(KeyCode.D))
            {
                if (GameManager.Instance.inventoryCursor < 31) GameManager.Instance.inventoryCursor += 1;
                GameManager.Instance.UpdateInventory();
            }

            //if (Input.GetAxisRaw("Vertical") > 0)
            if (Input.GetKeyDown(KeyCode.W))
            {
                if (GameManager.Instance.inventoryCursor - 8 >= 0) GameManager.Instance.inventoryCursor -= 8;
                GameManager.Instance.UpdateInventory();
            }

            //if (Input.GetAxisRaw("Vertical") < 0)
            if (Input.GetKeyDown(KeyCode.S))
            {
                if (GameManager.Instance.inventoryCursor + 8 <= 31) GameManager.Instance.inventoryCursor += 8;
                GameManager.Instance.UpdateInventory();
            }
        }

        if (GameManager.Instance.viewingQuestLog)
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                if (GameManager.Instance.questCursor > 0) GameManager.Instance.questCursor -= 1;
                GameManager.Instance.UpdateQuestLog();
            }

            if (Input.GetKeyDown(KeyCode.S))
            {
                if (GameManager.Instance.questCursor < GameManager.Instance.quests.Count - 1) GameManager.Instance.questCursor += 1;
                GameManager.Instance.UpdateQuestLog();
            }
        }

        // Attack Input
        if (Input.GetKeyDown(KeyCode.Q))
        {
            // Check to make sure we're not inside the house or bedroom
            // TODO: Check against an array of indoor scene names?
            if (sceneName != "Bedroom" && sceneName != "LivingRoom")
            {
                StartCoroutine(AttackCo());
            }
            // attackAnimator.SetFloat("moveX", velocity.x);
            // attackAnimator.SetFloat("moveY", velocity.y);
            // attackAnimator.SetTrigger("Attack");
        }

        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("mouse button 0 down " + Input.mousePosition);

            if (EventSystem.current.IsPointerOverGameObject()) return;

            RaycastHit2D hit;

            hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

            interactionIcon.transform.position = Camera.main.ScreenPointToRay(Input.mousePosition).origin;
            interactionIcon.enabled = true;

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Debug.Log("ray " + ray);

            Vector3 dest = ray.origin;
            dest.z = 0;
            navMeshAgent.destination = dest;

            if (hit.collider != null)
            {
                interactionTarget = hit.transform.gameObject;
                Interaction interaction = interactionTarget.transform.GetComponent<Interaction>();

                if (interaction != null && interaction.enabled)
                {
                    Debug.Log("interactionTarget is now " + hit.transform.gameObject.name);
                    interactionIcon.sprite = interactionTarget.transform.GetComponent<Interaction>().interactionIconActive;

                    StartCoroutine(MoveCheckCo());
                }
                else
                {
                    Debug.Log("interactionTarget is now null");
                    interactionTarget = null;
                }
            }
            else
            {
                Debug.Log("interactionTarget is now null");
                interactionTarget = null;
            }

            if (interactionIcon.sprite == null)
            {
                interactionIcon.sprite = Resources.Load<Sprite>("UI/cursor_active");
            }
        }
    }

    private IEnumerator AttackCo()
    {
        animator.SetBool("attacking", true);
        yield return null;
        animator.SetBool("attacking", false);
        yield return new WaitForSeconds(0.5f);
    }

    private IEnumerator MoveCheckCo()
    {
//        yield return new WaitForEndOfFrame();
        yield return new WaitForSeconds(0.05f);

        Vector3 velocity = navMeshAgent.steeringTarget - transform.position;

        if (velocity == Vector3.zero && !navMeshAgent.pathPending)
        {
            Debug.Log("clicked same spot twice i think");

            interactionIcon.sprite = null;
            interactionIcon.enabled = false;

            if (interactionTarget != null)
            {
                Interaction[] interactions = interactionTarget.transform.GetComponents<Interaction>();

                foreach (Interaction interaction in interactions)
                {
                    if (interaction.enabled) interaction.Interact();
                }

                interactionTarget = null;
            }
        }

        yield return null;
    }
}
