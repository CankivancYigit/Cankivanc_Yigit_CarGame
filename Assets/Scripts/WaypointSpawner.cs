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
        InvokeRepeating("CreateWaypointAndAddToWaypointsList", 0f, 0.3f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void CreateWaypointAndAddToWaypointsList()
    {
       // waypointsCollector.Waypoints = new List<Transform>(); //hızlı gitmeye engel
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
