using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Vector3 _movementDir;

    private Rigidbody2D _playerRigidbody;
    
    private float _movementSpeed = 2;

    private void Start()
    {
        _playerRigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        
    }

    private void FixedUpdate()
    {
        Walking();
    }

    private void Walking()
    {
        float xAxis = Input.GetAxis("Horizontal");
        float yAxis = Input.GetAxis("Vertical");
        
        _movementDir.Set(xAxis, yAxis, 0f);
        
        float time = Time.deltaTime;
        
        _playerRigidbody.MovePosition(transform.position + _movementDir * _movementSpeed * time);
    }
}
