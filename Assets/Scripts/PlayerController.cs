using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float _movementSpeed = 5f;

    private Vector2 _movementDirection;

    private Rigidbody2D _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        ProcessInput();
    }

    private void FixedUpdate()
    {
        Walking();
    }

    private void ProcessInput()
    {
        float xAxis = Input.GetAxisRaw("Horizontal");
        float yAxis = Input.GetAxisRaw("Vertical");

        _movementDirection = new Vector2(xAxis, yAxis).normalized;
    }

    private void Walking()
    {
        _rigidbody.velocity = _movementDirection * _movementSpeed;
    }
}
