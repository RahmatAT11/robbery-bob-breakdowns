using System;
using UnityEngine;

public class EnemyController : CharacterBaseController
{
    private PlayerController player;

    private void Awake()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        SetRotationToZero();
        player = FindObjectOfType<PlayerController>();
        MovementSpeed = 7.0f;
    }

    private void Update()
    {
        MovementDirection = (player.transform.position - transform.position).normalized;
    }

    private void FixedUpdate()
    {
        Walking();
        Turning();
    }

    protected override void Sprinting()
    {
        Rigidbody2D.velocity = MovementDirection * (MovementSpeed * _sprintSpeedMultiplier);
    }
}
