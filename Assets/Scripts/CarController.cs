using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    [Tooltip("Rotation Speed for Current Driven Car")] [SerializeField] float rotateSpeed = 100f; 

    public float RotateSpeed { get => rotateSpeed; set => rotateSpeed = value; }

    void Update()
    {
        if (Input.GetMouseButton(0))  
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if (mousePos.x < 0)   //Eger ekranin soluna tiklanir ise sola doner
            {
                TurnLeft();
            }
            else if (mousePos.x > 0)   //Eger ekranin sagina tiklanir ise saga doner
            {
                TurnRight();
            }
        }
    }

    void TurnLeft()
    {
        transform.Rotate(0, 0, RotateSpeed * Time.deltaTime);
    }   

    void TurnRight()
    {
        transform.Rotate(0, 0, -RotateSpeed * Time.deltaTime);
    }
}
