using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointSpawner : MonoBehaviour
{
    GameObject waypoint;
    WaypointsCollector waypointsCollector;

    void Start()
    {
        waypointsCollector = FindObjectOfType<WaypointsCollector>();
        waypoint = new GameObject("Waypoints To Follow");
        InvokeRepeating("CreateWaypointAndAddToWaypointsList", 0f, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void CreateWaypointAndAddToWaypointsList()
    {
        GameObject newWaypoints = Instantiate(waypoint, transform.position, transform.rotation);
        waypointsCollector.Waypoints.Add(newWaypoints.transform); 
    }

    void StopAddingWaypointsToList()      //CreateWaypointAndAddToWaypointsList metodunun invokerepeatingini 
    {                                     //Collisionhandler da silebilmek icin olusturdum 
        CancelInvoke();
    }

    public void DeleteAllWayPoints()
    {    
        for (int i = 0; i < waypointsCollector.Waypoints.Count; i++)
        {
            GameObject waypointsToDelete = waypointsCollector.Waypoints[i].gameObject;
            Destroy(waypointsToDelete);
        }
        waypointsCollector.Waypoints.Clear();
    }
}
