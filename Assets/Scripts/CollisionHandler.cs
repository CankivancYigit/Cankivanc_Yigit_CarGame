using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    static List<GameObject> carList = new List<GameObject>();
    private void Start()
    {
                           
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Finish")
        {
            carList.Add(gameObject);
            FindObjectOfType<GameManager>().DisableCarController(gameObject);
            FindObjectOfType<GameManager>().ChangeCarTag(gameObject);
            FindObjectOfType<GameManager>().ResetPositions(carList);
            //FindObjectOfType<GameManager>().AddNavMeshAgent(gameObject,other.gameobject); metoda other.gameobject.position eklenecek
            FindObjectOfType<GameManager>().SpawnCarAndControlSpawnerIndex();
            FindObjectOfType<GameManager>().StopGameWithPanel();
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "UsedCar")
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

        if (other.gameObject.tag == "Obstacle")
        {

        }
    }
}
