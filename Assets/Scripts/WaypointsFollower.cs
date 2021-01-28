using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointsFollower : MonoBehaviour
{
    [SerializeField] List<Transform> waypoints;
    [Tooltip("Speed for Previously Driven Cars")] public float moveSpeed = 3f;
    [Tooltip("Rotation Speed for Previously Driven Cars")] [SerializeField] float rotationSpeed = 1f;
    bool isFollowing = false;
    private int waypointIndex = 0;

    public List<Transform> Waypoints { get => waypoints; set => waypoints = value; }
    public bool IsFollowing { get => isFollowing; set => isFollowing = value; }
    public int WaypointIndex { get => waypointIndex; set => waypointIndex = value; }

    private void Awake()
    {
        waypoints = new List<Transform>();
    }

    void Update()
    {
        if (IsFollowing == true)
        {
            FollowPath();
        }  
    }

    private void FollowPath()   //Listeye eklenen waypointleri takip eder
    {
            transform.position = Vector2.MoveTowards(transform.position,
                waypoints[WaypointIndex].transform.position,
                moveSpeed * Time.deltaTime);

        transform.rotation = Quaternion.Slerp(transform.rotation, waypoints[WaypointIndex].transform.rotation, rotationSpeed);

        if (Vector2.Distance(transform.position,waypoints[WaypointIndex].transform.position) < 0.01f)
        { 
            if (WaypointIndex < waypoints.Count - 1)
            {
                WaypointIndex++;
            }
            else
            {
                moveSpeed = 0;
            }
        }
    }
}
