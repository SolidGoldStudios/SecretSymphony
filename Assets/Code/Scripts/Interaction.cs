using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interaction : MonoBehaviour
{
    public Sprite interactionIcon;

    public abstract void Interact();
}
