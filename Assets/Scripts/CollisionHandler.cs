using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
     
    GameManager gameManager;
    WaypointSpawner waypointSpawner;
    
    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        waypointSpawner = FindObjectOfType<WaypointSpawner>(); 
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Finish")  //Finish cizgisine degilir ise
        {
            gameManager.CarList.Add(gameObject);
            gameManager.EnableCarsPathFollowing(gameManager.CarList);
            waypointSpawner.SendMessage("StopAddingWaypointsToList"); //Yeni olusan Waypointleri once kullanılan arabaya eklememek icin kullanıyoruz 
            gameManager.DisableCarController(gameObject);
            gameManager.DisableCarMovement(gameObject);
            gameManager.ChangeRigidBodyToStatic(gameObject);
            gameManager.DeleteCollisionHandler(gameObject);
            gameManager.ChangeCarTag(gameObject);
            gameManager.ResetPositions(gameManager.CarList);
            gameManager.FinishLineSwitch();
            gameManager.SpawnCar();
            gameManager.StopGameWithPanel();
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "UsedCar" || other.gameObject.tag == "Obstacle")  //duvar ya da arabaya carpilir ise
        {
            waypointSpawner.DeleteAllWaypoints();                                       //Kullanılan arabaya ait waypointleri sileriz
            gameManager.CarList.Add(gameObject);                                        //Once kullanılan arabayı carlist'e ekleriz
            GameObject[] cars = GameObject.FindGameObjectsWithTag("UsedCar");           //Sonra onceki arabaları carlist'e ekleriz
            for (int i = 0; i < cars.Length; i++)
            {
                gameManager.CarList.Add(cars[i]);
            }
            gameManager.ResetPositionsWhenCollide(gameManager.CarList);             //Carlistteki butun arabaların pozisyonlarını resetleriz
            gameManager.StopGameWithPanel();                                           
        }
    }
}
