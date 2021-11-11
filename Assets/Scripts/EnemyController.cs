using System;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : CharacterBaseController
{
    private PlayerController player;

    private float _detectionRadius = 5.0f;
    private float _detectionAngle = 90.0f;

    [SerializeField] private List<Transform> paths;

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
            if (Vector3.Dot(distanceToPlayer.normalized, transform.up) > 
                Mathf.Cos((_detectionAngle * 0.5f) * Mathf.Deg2Rad))
            {
                Debug.Log("Player has been detected!");
                return player;
            }
        }
        
        return null;
    }

#if UNITY_EDITOR
    private void OnDrawGizmosSelected()
    {
        Color c = new Color(0.8f, 0, 0, 0.4f);
        UnityEditor.Handles.color = c;

        Vector3 rotatedForward = Quaternion.Euler(
            0,
            0,
            -_detectionAngle * 0.5f) * transform.up;

        UnityEditor.Handles.DrawSolidArc(
            transform.position,
            Vector3.forward,
            rotatedForward,
            _detectionAngle,
            _detectionRadius);
    }
#endif
}
