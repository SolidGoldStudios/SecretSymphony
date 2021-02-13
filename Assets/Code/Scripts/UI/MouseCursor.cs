using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MouseCursor : MonoBehaviour
{
    private Image cursorImage;
    public Sprite defaultCursor;
    public Sprite defaultActiveCursor;
    public Sprite interactCursor;
    public Sprite interactActiveCursor;
    public Sprite speakCursor;
    public Sprite speakActiveCursor;

    void Start()
    {
        Cursor.visible = false;
        cursorImage = GetComponent<Image>();
    }

    void Update()
    {
        //Vector2 cursorPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //transform.position = cursorPos;

        transform.position = Input.mousePosition;

        if (EventSystem.current.IsPointerOverGameObject())
        {
            cursorImage.sprite = defaultCursor;
        }
        else
        {
            CastRay();
        }
    }

    void CastRay()
    {
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

        if (hit.collider != null && hit.collider.gameObject != null)
        {
            Interaction interaction = hit.collider.gameObject.GetComponent<Interaction>();

            if (interaction != null && interaction.interactionIcon != null && interaction.enabled)
            {
                cursorImage.sprite = interaction.interactionIcon;
            }
            else
            {
                cursorImage.sprite = defaultCursor;
            }
        }
        else
        {
            cursorImage.sprite = defaultCursor;
        }

            //    string objectTag = hit.collider.gameObject.tag;

            //    if (objectTag == "Interact")
            //    {
            //        if (Input.GetMouseButtonDown(0))
            //        {
            //            cursorImage.sprite = interactActiveCursor;
            //            GetComponent<AudioSource>().Play();
            //        }
            //        else if (Input.GetMouseButtonUp(0))
            //        {
            //            cursorImage.sprite = interactCursor;
            //            GetComponent<AudioSource>().Stop();
            //        }
            //        else
            //        {
            //            cursorImage.sprite = interactCursor;
            //        }
            //    }
            //    else if (objectTag == "Speak")
            //    {
            //        if (Input.GetMouseButtonDown(0))
            //        {
            //            cursorImage.sprite = speakActiveCursor;
            //            GetComponent<AudioSource>().Play();
            //        }
            //        else if (Input.GetMouseButtonUp(0))
            //        {
            //            cursorImage.sprite = speakCursor;
            //            GetComponent<AudioSource>().Stop();
            //        }
            //        else
            //        {
            //            cursorImage.sprite = speakCursor;
            //        }
            //    }
            //    else
            //    {
            //        if (Input.GetMouseButtonDown(0))
            //        {
            //            cursorImage.sprite = defaultActiveCursor;
            //            GetComponent<AudioSource>().Play();
            //        }
            //        else if (Input.GetMouseButtonUp(0))
            //        {
            //            cursorImage.sprite = defaultCursor;
            //            GetComponent<AudioSource>().Stop();
            //        }
            //    }
            //}
            //else
            //{
            //    if (Input.GetMouseButtonDown(0))
            //    {
            //        cursorImage.sprite = defaultActiveCursor;
            //        GetComponent<AudioSource>().Play();
            //    }
            //    else if (Input.GetMouseButtonUp(0))
            //    {
            //        cursorImage.sprite = defaultCursor;
            //        GetComponent<AudioSource>().Stop();
            //    }
    }
}
