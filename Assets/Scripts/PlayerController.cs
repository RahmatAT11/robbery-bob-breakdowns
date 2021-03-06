using UnityEngine;
using UnityEngine.UI;

public class PlayerController : CharacterBaseController
{
    public GameObject DoorWin, WinPanel, LosePanel, Star1, Star2, Star3;
    
    [SerializeField] private GameJoystickController gameJoystickController;

    [SerializeField] Text coinCounter, timeLeft;
    [SerializeField] GameObject coinMagnet, PanicEffect;
    [SerializeField] float TreasureCount;
    public Image TreaseureInfoUI;

    private float _coinNumber;
    public bool playerDetected;
    bool isWin, isLose;

    float currentTime = 0f;
    float startingTime = 30f;

    private void Awake()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        SetRotationToZero();
        TreaseureInfoUI.fillAmount = 0;
        playerDetected = false;
        isWin = false;
        isLose = false;
        Time.timeScale = 1;

        Star1.SetActive(false);
        Star2.SetActive(false);
        Star3.SetActive(false);
        PanicEffect.SetActive(false);

        currentTime = startingTime;
    }

    private void Update()
    {
        ProcessInput();
        WinStarCondition();
        StageTimeLeft();

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

    public void WinStarCondition()
    {
        if (_coinNumber == TreasureCount && playerDetected == false)
        {
            Star1.SetActive(true);
            Star2.SetActive(true);
            Star3.SetActive(true);
        }

        if (_coinNumber == TreasureCount && playerDetected == true)
        {
            Star1.SetActive(true);
            Star2.SetActive(true);
        }

        if (_coinNumber != TreasureCount && playerDetected == false)
        {
            Star1.SetActive(true);
            Star2.SetActive(true);
        }
        
        if (_coinNumber != TreasureCount && playerDetected == true)
        {
            Star1.SetActive(true);
        }

        if (isWin == true)
        {
            isLose = false;
            WinPanel.SetActive(true);
            Time.timeScale = 0;
        }

        if (isLose == true)
        {
            isWin = false;
            LosePanel.SetActive(true);
            Time.timeScale = 0;
        }
    }

    public void StageTimeLeft()
    {
        currentTime -= 1 * Time.deltaTime;
        timeLeft.text = currentTime.ToString("0");

        if (currentTime <= 0)
        {
            currentTime = 0;
            isLose = true;
        }

        if (currentTime <= 15)
        {
            PanicEffect.SetActive(true);
        }
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag.Equals("Coin"))
        {
            Destroy(col.gameObject);
            _coinNumber += 1;
        }

        if (col.gameObject.tag.Equals("MainTreasure"))
        {
            Destroy(col.gameObject);
            _coinNumber += 1;
            Debug.Log("Main Treasure Terambil");

            DoorWin.SetActive(true);
        }

        if (col.gameObject.tag.Equals("GetOut"))
        {
            Destroy(col.gameObject);

            isWin = true;
        }

        if (col.gameObject.tag.Equals("Enemy"))
        {
            isLose = true;
        }
    }
}
