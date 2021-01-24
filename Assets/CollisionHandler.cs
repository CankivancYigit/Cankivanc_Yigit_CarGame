using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Finish")
        {
            Debug.Log("abc");
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Car" || other.gameObject.tag == "Obstacle")
        {
            Debug.Log("abc");
            Destroy(gameObject);
        }
    }
}
