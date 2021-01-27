using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointsCollector : MonoBehaviour
{
    [SerializeField] List<Transform> waypoints;
    private float moveSpeed = 2f;
    bool isFollowing = false;
    private int waypointIndex = 1;
    public List<Transform> Waypoints { get => waypoints; set => waypoints = value; }
    public bool IsFollowing { get => isFollowing; set => isFollowing = value; }

    void Start()
    {
        waypoints = new List<Transform>();
        transform.position = waypoints[waypointIndex].transform.position;     
    }

    void Update()
    {
        if (IsFollowing == true)
        {
            FollowPath();
        }  
    }

    private void FollowPath()
    {
        transform.position = Vector2.MoveTowards(transform.position,
            waypoints[waypointIndex].transform.position,
            moveSpeed * Time.deltaTime);

        if (transform.position == waypoints[waypointIndex].transform.position)
        {
            waypointIndex += 1;
        }

        if (waypointIndex == waypoints.Count)
        {
            moveSpeed = 0;
        }
    }
}
