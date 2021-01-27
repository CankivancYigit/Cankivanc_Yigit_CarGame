using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    [SerializeField] float rotateSpeed = 100f;
    Transform currentTransform;
    WaypointsController waypointsController;

    public float RotateSpeed { get => rotateSpeed; set => rotateSpeed = value; }

    void Start()
    {
        waypointsController = FindObjectOfType<WaypointsController>();
        currentTransform = GetComponent<Transform>();
    }

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if (mousePos.x < 0)
            {
                TurnLeft();
            }
            else if (mousePos.x > 0)
            {
                TurnRight();
            }
        }
    }

    void TurnLeft()
    {
        transform.Rotate(0, 0, RotateSpeed * Time.deltaTime);
        //GetCurrentTransformAndAddToWaypointsList();
    }   

    void TurnRight()
    {
        transform.Rotate(0, 0, -RotateSpeed * Time.deltaTime);
       // GetCurrentTransformAndAddToWaypointsList();
    }

    private void GetCurrentTransformAndAddToWaypointsList()
    {
        currentTransform.position = new Vector2(transform.position.x, transform.position.y);
        //waypointsController.AddWaypointsToList(currentTransform);
    }
}
