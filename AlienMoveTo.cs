using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienMoveTo : MonoBehaviour
{
    public Transform startMarker;
    public Vector3 endMarker;
    private float speed = 0.1F;
    private float startTime;
    private float journeyLength;

    void Start()
    {
        journeyLength = 0;
    }

    void Update()
    {
        if (journeyLength > 0)
        {
            float distCovered = (Time.time - startTime) * speed;
            float fracJourney = distCovered / journeyLength;
            transform.position = Vector3.Lerp(startMarker.position, endMarker, fracJourney);
        }
    }

    public void StartMove(Vector3 endPos)
    {
        startMarker = this.transform;
        endMarker = endPos;
        startTime = Time.time;
        journeyLength = Vector3.Distance(startMarker.position, endMarker);
    }
}
