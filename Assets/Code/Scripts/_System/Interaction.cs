using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interaction : MonoBehaviour
{
    public Sprite interactionIcon;
    public Sprite interactionIconActive;
    public bool moveToTarget = false;
    public GameObject blockedBy;

    public abstract void Interact();
}
