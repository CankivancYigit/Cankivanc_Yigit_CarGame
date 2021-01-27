using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointsController : MonoBehaviour
{
    List<Transform> waypoints = new List<Transform>();
    Transform targetWaypoint;
    int targetWaypointIndex = 0;
    float minDistance = 0f; 
    int lastWaypointIndex;
    float movementSpeed;
    float rotationSpeed;

    //Encapsulation 
    //public List<Transform> Waypoints { get => waypoints; set => waypoints = value; }

    void Start()
    {
        movementSpeed = FindObjectOfType<CarMovement>().MoveSpeed;
        rotationSpeed = FindObjectOfType<CarController>().RotateSpeed;
        lastWaypointIndex = waypoints.Count - 1;
        targetWaypoint = waypoints[targetWaypointIndex];
    }

    void Update()
    {
        float movementStep = movementSpeed * Time.deltaTime;
        float rotationStep = rotationSpeed * Time.deltaTime;

        Vector3 directionToTarget = targetWaypoint.position - transform.position;
        Quaternion rotationToTarget = Quaternion.LookRotation(directionToTarget);

        transform.rotation = Quaternion.Slerp(transform.rotation, rotationToTarget, rotationStep);

        float distance = Vector3.Distance(transform.position, targetWaypoint.position);
        CheckDistanceToWaypoint(distance);

        transform.position = Vector3.MoveTowards(transform.position, targetWaypoint.position, movementStep);
    }

    void CheckDistanceToWaypoint(float currentDistance)
    {
        if (currentDistance <= minDistance)
        {
            if (targetWaypointIndex == lastWaypointIndex)
            {
                movementSpeed = 0f;
            }
            else
            {
                targetWaypointIndex++;
                UpdateTargetWaypoint();
            }      
        }
    }

    void UpdateTargetWaypoint()
    {
        targetWaypoint = waypoints[targetWaypointIndex];
    }

    public void AddWaypointsToList(Transform waypoint)
    {
        waypoints.Add(waypoint);
        Debug.Log(waypoint.position);
    }

    //Eger kullanılan araba duvara ya da önceki arabalara carpar ise olusturulan waypointleri sileriz.
    public void DeleteAllWayPoints()
    {
        waypoints.Clear();
    }

}
