using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private GameJoystickController gameJoystickController;
    private float _movementSpeed = 10.0f;
    private Vector3 _movementDirection;
    
    private Rigidbody2D _rigidbody;
    
    private bool _isSprinting;
    public bool IsSprinting
    {
        get
        {
            return _isSprinting;
        }
        set
        {
            _isSprinting = value;
        }
    }
    private float _sprintSpeedMultiplier = 1.7f;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
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
        Sprinting();
    }

    private void ProcessInput()
    {
        // mengambil nilai axis
        /*float xAxis = Input.GetAxisRaw("Horizontal");
        float yAxis = Input.GetAxisRaw("Vertical");*/
        float xAxis = gameJoystickController.InputHorizontal();
        float yAxis = gameJoystickController.InputVertical();

        // membuat vector baru sesuai arah axis
        _movementDirection = new Vector3(xAxis, yAxis, 0f).normalized;

        /*if (Input.GetKey(KeyCode.LeftShift))
        {
            _isSprinting = true;
        }
        else
        {
            _isSprinting = false;
        }*/
    }

    private void Walking()
    {
        // menggerakkan player ke vector
        _rigidbody.velocity = _movementDirection * _movementSpeed;
    }

    private void Sprinting()
    {
        if (_isSprinting)
        {
            _rigidbody.velocity = _movementDirection * _movementSpeed * _sprintSpeedMultiplier;
        }
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
