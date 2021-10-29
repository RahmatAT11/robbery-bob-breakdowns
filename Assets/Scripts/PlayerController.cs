using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float _movementSpeed = 5f;

    private Vector3 _movementDirection;

    private Rigidbody2D _rigidbody;

    private Camera _mainCamera;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _mainCamera = Camera.main;
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
        // mengambil nilai axis
        float xAxis = Input.GetAxisRaw("Horizontal");
        float yAxis = Input.GetAxisRaw("Vertical");

        // membuat vector baru sesuai arah axis
        _movementDirection = new Vector2(xAxis, yAxis).normalized;
    }

    private void Walking()
    {
        // menggerakkan player ke vector
        _rigidbody.velocity = _movementDirection * _movementSpeed;
    }
}
