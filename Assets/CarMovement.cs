using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMovement : MonoBehaviour
{
    Rigidbody2D rgb;
    [SerializeField] float rotateAmount = 1f;
    [SerializeField] float moveSpeed = 3f;

    void Start()
    {
        rgb = GetComponent<Rigidbody2D>();
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

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        rgb.velocity = transform.up * moveSpeed;
    }

    void TurnLeft()
    {
        transform.Rotate(0, 0, rotateAmount);
    }
    void TurnRight()
    {
        transform.Rotate(0, 0, -rotateAmount);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Finish")
        {
            Debug.Log("abc");
        }
    }
}
