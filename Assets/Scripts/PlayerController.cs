using UnityEngine;
using UnityEngine.UI;

public class PlayerController : CharacterBaseController
{
    [SerializeField] private GameJoystickController gameJoystickController;

    [SerializeField] Text coinCounter;
    [SerializeField] GameObject coinMagnet;
    [SerializeField] float TreasureCount;
    public Image TreaseureInfoUI;

    private float _coinNumber;

    private void Awake()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        SetRotationToZero();
        TreaseureInfoUI.fillAmount = 0;
    }

    private void Update()
    {
        ProcessInput();

        coinCounter.text = (_coinNumber / TreasureCount * 100).ToString() + "%";
        coinMagnet.transform.position = new Vector2(transform.position.x, transform.position.y);
        TreaseureInfoUI.fillAmount = _coinNumber * (1/TreasureCount);
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
        MovementDirection = new Vector3(xAxis, yAxis, 0f).normalized;

        /*if (Input.GetKey(KeyCode.LeftShift))
        {
            _isSprinting = true;
        }
        else
        {
            _isSprinting = false;
        }*/
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag.Equals("Coin"))
        {
            Destroy(col.gameObject);
            _coinNumber += 1;
        }
    }
}
