using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    static List<GameObject> carList = new List<GameObject>();
    GameManager gameManager;
    WaypointSpawner waypointSpawner;
    WaypointsCollector waypointsCollector;
    
    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        waypointSpawner = FindObjectOfType<WaypointSpawner>();
        waypointsCollector = FindObjectOfType<WaypointsCollector>();
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Finish")  //Finish cizgisine degilir ise
        {
            //waypointsCollector.IsFollowing = true;
            carList.Add(gameObject);
            //gameManager.EnableCarsPathFollowing(carList);
            waypointSpawner.SendMessage("StopAddingWaypointsToList"); //Yeni olusan Waypointleri once kullanılan arabaya eklememek icin kullanıyoruz 
            //gameManager.DeleteWaypointSpawner(gameObject);
            gameManager.DisableCarController(gameObject);
            gameManager.DisableCarMovement(gameObject);
            gameManager.ChangeRigidBodyToStatic(gameObject);
            gameManager.DeleteCollisionHandler(gameObject);
            gameManager.ChangeCarTag(gameObject);
            gameManager.ResetPositions(carList);
            gameManager.FinishLineSwitch();
            gameManager.SpawnCarAndControlSpawnerIndex();
            gameManager.StopGameWithPanel();
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "UsedCar" || other.gameObject.tag == "Obstacle")  //duvar ya da arabaya carpilir ise
        {
            waypointSpawner.DeleteAllWayPoints();                                       //Kullanılan arabaya ait waypointleri sileriz
            carList.Add(gameObject);                                                    //Once kullanılan arabayı carlist'e ekleriz
            GameObject[] cars = GameObject.FindGameObjectsWithTag("UsedCar");           //Sonra onceki arabaları carlist'e ekleriz
            for (int i = 0; i < cars.Length; i++)
            {
                carList.Add(cars[i]);
            }
            gameManager.ResetPositionsWhenCollide(carList);                            //Carlistteki butun arabaların pozisyonlarını resetleriz
            gameManager.StopGameWithPanel();
        }
    }
}
