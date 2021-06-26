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

        // Attack Input
        if (Input.GetKeyDown(KeyCode.Q))
        {
            // Check to make sure we're not inside the house or bedroom
            // TODO: Check against an array of indoor scene names?
            if (sceneName != "Bedroom" && sceneName != "LivingRoom")
            {
                StartCoroutine(AttackCo());
            }
        }

        if (Input.GetMouseButtonDown(0))
        {
            //Debug.Log("mouse button 0 down " + Input.mousePosition);

            if (EventSystem.current.IsPointerOverGameObject() || immobilized) return;

            RaycastHit2D hit;

            hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

            interactionIcon.transform.position = Camera.main.ScreenPointToRay(Input.mousePosition).origin;
            interactionIcon.enabled = true;

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            //Debug.Log("ray " + ray);

            Vector3 dest = ray.origin;
            dest.z = 0;
            navMeshAgent.destination = dest;

            if (hit.collider != null)
            {
                interactionTarget = hit.transform.gameObject;
                Debug.Log("collider hit " + interactionTarget.name);
                Interaction interaction = interactionTarget.transform.GetComponent<Interaction>();

                if (interaction != null && interaction.enabled)
                {
                    Debug.Log("interactionTarget is now " + interactionTarget.name);
                    interactionIcon.sprite = interaction.interactionIconActive;

                    if (interaction.moveToTarget)
                    {
                        Bounds bounds = interactionTarget.GetComponent<SpriteRenderer>().bounds;

                        dest.x = bounds.center.x;
                        dest.y = bounds.center.y - (bounds.extents.y + 0.25f);
                        navMeshAgent.destination = dest;
                        Debug.Log("moveToTarget: " + dest);
                    }

                    StartCoroutine(MoveCheckCo());
                }
                else
                {
                    Debug.Log("interactionTarget is now null");
					interactionIcon.sprite = Resources.Load<Sprite>("UI/cursor_active");
                    interactionTarget = null;
                }
            }
            else
            {
                Debug.Log("interactionTarget is now null");
				interactionIcon.sprite = Resources.Load<Sprite>("UI/cursor_active");
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
