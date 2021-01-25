using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    [SerializeField] float rotateSpeed = 1f;

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
        transform.Rotate(0, 0, rotateSpeed);
    }

    void TurnRight()
    {
        transform.Rotate(0, 0, -rotateSpeed);
    }
}
