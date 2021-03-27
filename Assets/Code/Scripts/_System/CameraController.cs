using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Vector2 maxPosition;
    public Vector2 minPosition;

    public Transform player;

    // Update is called once per frame
    void Update()
    {
        if (!player || player.position == transform.position) return;

        Vector3 targetPosition = player.position;

        targetPosition.x = Mathf.Clamp(targetPosition.x,
                                        minPosition.x,
                                        maxPosition.x);
        targetPosition.y = Mathf.Clamp(targetPosition.y,
                                        minPosition.y,
                                        maxPosition.y);
        targetPosition.z = -10;

        transform.position = targetPosition;
    }
}

