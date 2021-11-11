using System;
using UnityEngine;

public class EnemyController : CharacterBaseController
{
    private PlayerController player;

    private float _detectionRadius = 5.0f;
    private float _detectionAngle = 45.0f;

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
        //MovementDirection = (player.transform.position - transform.position).normalized;
        DetectPlayer();
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

    private PlayerController DetectPlayer()
    {
        PlayerController player = FindObjectOfType<PlayerController>();
        if (player == null)
        {
            return null;
        }

        Vector3 currentPosition = transform.position;
        Vector3 distanceToPlayer = player.transform.position - currentPosition;
        distanceToPlayer.z = 0;

        if (distanceToPlayer.magnitude <= _detectionRadius)
        {
            Debug.Log("Player has been detected!");
        }
        
        return player;
    }
}
