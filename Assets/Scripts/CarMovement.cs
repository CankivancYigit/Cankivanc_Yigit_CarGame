using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMovement : MonoBehaviour
{
    Rigidbody2D rgb;
    [SerializeField] float moveSpeed = 3f;
    private Vector3 startPosition;
    private Quaternion startRotation;
    void Start()
    {
        rgb = GetComponent<Rigidbody2D>();
        startPosition = transform.position;
        startRotation = transform.rotation;
    }

    void Update()
    {
       
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        rgb.velocity = transform.up * moveSpeed;
    }

    public Vector3 GetStartPosition()
    {
        transform.position = startPosition;
        return startPosition;
    }

    public Quaternion GetStartRotation()
    {
        transform.rotation = startRotation;
        return startRotation;
    }
}
