using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interaction : MonoBehaviour
{
    public Sprite interactionIcon;
    public Sprite interactionIconActive;

    public abstract void Interact();
}
