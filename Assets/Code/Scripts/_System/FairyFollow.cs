using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FairyFollow : MonoBehaviour
{
    public Transform target;
    public Transform[] pointsOfInterest;
    public float smoothTime = 1f;
    public Vector3 velocity = Vector3.zero;
    private List<Vector3> pointOfInterestPositions = new List<Vector3>();

    void Start()
    {
        transform.position = target.TransformPoint(new Vector3(-1f, 3f, 0f));

        foreach (Transform pointOfInterest in pointsOfInterest)
        {
            StartDialogue dialogue = pointOfInterest.gameObject.GetComponent<StartDialogue>();
            if (dialogue != null && dialogue.questGiver)
            {
                // Float above and to the left of NPCs with StartDialogue and questGiver
                pointOfInterestPositions.Add(pointOfInterest.TransformPoint(new Vector3(-1f, 3f, 0f)));
            } 
            else
            {
                // Hover directly above objects
                pointOfInterestPositions.Add(pointOfInterest.TransformPoint(new Vector3(0f, 1f, 0f)));
            }
        }
    }

    void Update()
    {
        Vector3 targetPosition = target.TransformPoint(new Vector3(-1f, 3f, 0f));
        float minDistance = 10f;

        for (int i = 0; i < pointsOfInterest.Length; i++)
        {
            Transform pointOfInterest = pointsOfInterest[i];

            if (!pointOfInterest.gameObject.activeInHierarchy) continue;

            Vector3 distance = target.position - pointOfInterest.position;
            if (distance.magnitude < minDistance)
            {
                minDistance = distance.magnitude;
                targetPosition = pointOfInterestPositions[i];
            }
        }

        velocity = Vector3.ClampMagnitude(velocity, 10f);

        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
    }
}
