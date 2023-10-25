using UnityEngine;
using System.Collections;
public class ObjectLooper : MonoBehaviour
{
    public Transform pointA;  // Transform of point A
    public Transform pointB;  // Transform of point B
    public float movementSpeed = 2.0f;  // Speed of movement

    private bool movingForward = true;  // Indicates if the object is moving from A to B

    private void Start()
    {
        // Start the movement coroutine
        StartCoroutine(MoveObject());
    }

    private IEnumerator MoveObject()
    {
        while (true)
        {
            float startTime = Time.time;

            // Calculate the length of the journey from A to B
            float journeyLength = Vector3.Distance(movingForward ? pointA.position : pointB.position, movingForward ? pointB.position : pointA.position);

            while (Time.time - startTime <= journeyLength / movementSpeed)
            {
                float journeyFraction = (Time.time - startTime) / (journeyLength / movementSpeed);

                // Move the object using Lerp (Linear interpolation) from A to B or B to A based on the direction
                transform.position = movingForward ? Vector3.Lerp(pointA.position, pointB.position, journeyFraction) : Vector3.Lerp(pointB.position, pointA.position, journeyFraction);

                yield return null;
            }

            // Reverse the direction
            movingForward = !movingForward;
        }
    }
}
