using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FairyFollow : MonoBehaviour
{
    public Transform target;
    public float smoothTime = 0.3f;
    private Vector3 velocity = Vector3.zero;

    void Start()
    {
        transform.position = target.TransformPoint(new Vector3(-1f, 3f, 0f));
    }

    void Update()
    {
        Vector3 targetPosition = target.TransformPoint(new Vector3(-1f, 3f, 0f));

        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
    }
}
