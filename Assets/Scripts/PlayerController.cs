using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private GameController _gameController;
    private float _movementSpeed = 10.0f;
    private float _rotationSpeed = 40.0f;
    private Vector3 _movementDirection;
    private Rigidbody2D _rigidbody;
    private Camera _mainCamera;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _mainCamera = Camera.main;
    }

    private void Start()
    {
        transform.rotation = new Quaternion(0f, 0f, 0f, 0f);
    }

    private void Update()
    {
        ProcessInput();
    }

    private void FixedUpdate()
    {
        Walking();
        Turning();
    }

    private void ProcessInput()
    {
        // mengambil nilai axis
        /*float xAxis = Input.GetAxisRaw("Horizontal");
        float yAxis = Input.GetAxisRaw("Vertical");*/
        float xAxis = _gameController.InputHorizontal();
        float yAxis = _gameController.InputVertical();

        // membuat vector baru sesuai arah axis
        _movementDirection = new Vector3(xAxis, yAxis, 0f).normalized;
        Debug.Log(_movementDirection);
    }

    private void Walking()
    {
        // menggerakkan player ke vector
        _rigidbody.velocity = _movementDirection * _movementSpeed;
    }

    private void Turning()
    {
        // rotate if vector _movementDirection is not zero
        if (_movementDirection != Vector3.zero)
        {
            float angle = Vector2.SignedAngle(transform.up, _movementDirection);
            
            _rigidbody.MoveRotation(_rigidbody.rotation + angle);
        }
    }
}
