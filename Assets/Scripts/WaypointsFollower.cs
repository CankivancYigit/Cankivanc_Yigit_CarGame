using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointsFollower : MonoBehaviour
{
    [SerializeField] List<Transform> waypoints;
    public float moveSpeed = 2f;
    bool isFollowing = false;
    private int waypointIndex = 0;
    public List<Transform> Waypoints { get => waypoints; set => waypoints = value; }
    public bool IsFollowing { get => isFollowing; set => isFollowing = value; }
    public int WaypointIndex { get => waypointIndex; set => waypointIndex = value; }

    private void Awake()
    {
        waypoints = new List<Transform>();
    }

    void Start()
    {
        //transform.position = waypoints[waypointIndex].transform.position;     
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
                waypoints[WaypointIndex].transform.position,
                moveSpeed * Time.deltaTime);

            if (transform.position == waypoints[WaypointIndex].transform.position)
            {
                WaypointIndex += 1;
            }

            if (WaypointIndex == waypoints.Count -1)
            {
                moveSpeed = 0;
            }
    }
}
