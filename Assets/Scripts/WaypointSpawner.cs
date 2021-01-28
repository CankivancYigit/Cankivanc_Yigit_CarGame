using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointSpawner : MonoBehaviour
{
    GameObject waypoint;
    WaypointsFollower waypointsFollower;

    void Start()
    {
        waypointsFollower = FindObjectOfType<WaypointsFollower>();
        waypoint = new GameObject("Waypoints To Follow");
        InvokeRepeating("CreateWaypointAndAddToWaypointsList", 0f, 0.1f);    //InvokeRepeating cagrilma hizi araba ilerlerken 
    }                                                                        //olusturulacak Waypoint sayisini belirler.

    void CreateWaypointAndAddToWaypointsList()      //Waypoint game objesi olusturur ve WaypointsFollower listesine ekler
    {
        GameObject newWaypoint = Instantiate(waypoint, transform.position, transform.rotation); 
        waypointsFollower.Waypoints.Add(newWaypoint.transform); 
    }

    void StopAddingWaypointsToList()      //CreateWaypointAndAddToWaypointsList metodunun invokerepeating ini 
    {                                     //Collisionhandler da silebilmek icin olusturdum 
        CancelInvoke();
    }

    public void DeleteAllWaypoints()        //Kullanılan araba duvara ya da diger arabalara carpar ise  
    {    
        for (int i = 0; i < waypointsFollower.Waypoints.Count; i++)
        {
            GameObject waypointsToDelete = waypointsFollower.Waypoints[i].gameObject;
            Destroy(waypointsToDelete);
        }
        waypointsFollower.Waypoints.Clear();
    }
}
