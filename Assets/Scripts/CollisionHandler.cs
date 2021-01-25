using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    static List<GameObject> carList = new List<GameObject>();
    //GameManager gameManager = new GameManager();
    private void Start()
    {
                           
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Finish")
        {
            carList.Add(gameObject);
            FindObjectOfType<GameManager>().DisableCarController(gameObject);
            FindObjectOfType<GameManager>().DeleteCollisionHandler(gameObject);
            FindObjectOfType<GameManager>().ChangeCarTag(gameObject);
            FindObjectOfType<GameManager>().ResetPositions(carList);
            FindObjectOfType<GameManager>().FinishLineSwitch();
            //FindObjectOfType<GameManager>().AddNavMeshAgent(gameObject,other.gameobject); metoda other.gameobject.position eklenecek
            FindObjectOfType<GameManager>().SpawnCarAndControlSpawnerIndex();
            FindObjectOfType<GameManager>().StopGameWithPanel();
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "UsedCar" || other.gameObject.tag == "Obstacle")
        {
            carList.Add(gameObject);
            GameObject[] cars = GameObject.FindGameObjectsWithTag("UsedCar");
            for (int i = 0; i < cars.Length; i++)
            {
                carList.Add(cars[i]);
            }
            FindObjectOfType<GameManager>().ResetPositionsWhenCollide(carList);
            FindObjectOfType<GameManager>().StopGameWithPanel();
        }
    }
}
