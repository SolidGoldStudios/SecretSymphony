using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseBackdrop : MonoBehaviour
{
    private PlayerMovement playerMovement;

    // Start is called before the first frame update
    void Start()
    {
        playerMovement = GameObject.Find("Player").gameObject.GetComponent<PlayerMovement>();
    }

    public void BackdropClick()
    {
        playerMovement.immobilized = false;
    }
}
