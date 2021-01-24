using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    private void Start()
    {
                           
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Finish")
        {
            FindObjectOfType<GameManager>().DisableCarMovement(gameObject);
            FindObjectOfType<GameManager>().IncreaseCarSpawnersIndex();
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Car" || other.gameObject.tag == "Obstacle")
        {
            Destroy(gameObject);
        }
    }
}
