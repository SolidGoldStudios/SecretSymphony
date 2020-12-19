using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Runtime.InteropServices.ComTypes;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.AI;
using UnityEngine.EventSystems;

public class PlayerMovement : MonoBehaviour
{
    private NavMeshAgent navMeshAgent;
    private Animator animator;
    private GameObject interactionTarget = null;

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
    void FixedUpdate()
    {
        if (immobilized)
        {
            animator.SetBool("moving", false);
            return;
        }

        //// Keeps silhouette and sprite on same animation frame.
        //silRenderer.sprite = sr.sprite;

        Vector3 velocity = navMeshAgent.steeringTarget - transform.position;

        if (velocity != Vector3.zero)
        {
            animator.SetFloat("moveX", velocity.x);
            animator.SetFloat("moveY", velocity.y);
            animator.SetBool("moving", true);

        }
        else
        {
            animator.SetBool("moving", false);

            if (!navMeshAgent.pathPending && interactionTarget != null)
            {
                Interaction[] interactions = interactionTarget.transform.GetComponents<Interaction>();

                foreach (Interaction interaction in interactions)
                {
                    interaction.Interact();
                }

                //EnvironmentalItem environmentalItem = interactionTarget.transform.GetComponent<EnvironmentalItem>();

                //if (environmentalItem != null)
                //{
                //    environmentalItem.PlayerInteract();
                //}

                interactionTarget = null;
            }
        }
    }

    void Update()
    {
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

        if (immobilized)
        {
            animator.SetBool("moving", false);
            return;
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
            if (EventSystem.current.IsPointerOverGameObject()) return;

            Debug.Log("mouse button 0 down " + Input.mousePosition);

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Debug.Log("ray " + ray);

            Vector3 dest = ray.origin;
            dest.z = 0;
            navMeshAgent.destination = dest;

            RaycastHit2D hit;

            hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

            if (hit.collider != null)
            {
                Debug.Log("interactionTarget is now " + hit.transform.gameObject.name);
                interactionTarget = hit.transform.gameObject;
            }
            else
            {
                Debug.Log("interactionTarget is now null");
                interactionTarget = null;
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
}
