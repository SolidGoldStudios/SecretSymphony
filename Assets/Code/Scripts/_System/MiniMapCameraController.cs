using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniMapCameraController : MonoBehaviour
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

        targetPosition.x = (float)Math.Round(targetPosition.x, 1, MidpointRounding.ToEven);
        targetPosition.y = (float)Math.Round(targetPosition.y, 1, MidpointRounding.ToEven);

        targetPosition.x = Mathf.Round(targetPosition.x);
        targetPosition.y = Mathf.Round(targetPosition.y);

        targetPosition.z = -10;

        transform.position = targetPosition;
    }
}
