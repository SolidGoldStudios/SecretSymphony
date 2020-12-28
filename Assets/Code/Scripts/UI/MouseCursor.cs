using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseCursor : MonoBehaviour
{
    private SpriteRenderer cursorSprite;
    public Sprite defaultCursor;
    public Sprite defaultActiveCursor;
    public Sprite interactCursor;
    public Sprite interactActiveCursor;
    public Sprite speakCursor;
    public Sprite speakActiveCursor;

    void Start()
    {
        Cursor.visible = false;
        cursorSprite = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        Vector2 cursorPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = cursorPos;

        CastRay();
    }

    void CastRay()
    {
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
        if (hit.collider != null)
        {
            string objectTag = hit.collider.gameObject.tag;

            if (objectTag == "Interact")
            {
                if (Input.GetMouseButtonDown(0))
                {
                    cursorSprite.sprite = interactActiveCursor;
                    GetComponent<AudioSource>().Play();
                }
                else if (Input.GetMouseButtonUp(0))
                {
                    cursorSprite.sprite = interactCursor;
                    GetComponent<AudioSource>().Stop();
                }
                else
                {
                    cursorSprite.sprite = interactCursor;
                }
            }
            else if (objectTag == "Speak")
            {
                if (Input.GetMouseButtonDown(0))
                {
                    cursorSprite.sprite = speakActiveCursor;
                    GetComponent<AudioSource>().Play();
                }
                else if (Input.GetMouseButtonUp(0))
                {
                    cursorSprite.sprite = speakCursor;
                    GetComponent<AudioSource>().Stop();
                }
                else
                {
                    cursorSprite.sprite = speakCursor;
                }
            }
            else
            {
                if (Input.GetMouseButtonDown(0))
                {
                    cursorSprite.sprite = defaultActiveCursor;
                    GetComponent<AudioSource>().Play();
                }
                else if (Input.GetMouseButtonUp(0))
                {
                    cursorSprite.sprite = defaultCursor;
                    GetComponent<AudioSource>().Stop();
                }
            }
        }
        else
        {
            if (Input.GetMouseButtonDown(0))
            {
                cursorSprite.sprite = defaultActiveCursor;
                GetComponent<AudioSource>().Play();
            }
            else if (Input.GetMouseButtonUp(0))
            {
                cursorSprite.sprite = defaultCursor;
                GetComponent<AudioSource>().Stop();
            }
        }
    }
}
