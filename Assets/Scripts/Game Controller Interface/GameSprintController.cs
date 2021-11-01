using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class GameSprintController : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] private PlayerController playerController;
    [SerializeField] private float sprintTimeDuration;
    private float _sprintTimeCounter;

    private Color _activeSprint;
    private Color _unactiveSprint;

    private bool _isSprintAllowed;

    private void Start()
    {
        _activeSprint = GetComponent<Image>().color;
        _unactiveSprint = Color.grey;
        _sprintTimeCounter = sprintTimeDuration;
        _isSprintAllowed = true;
    }

    private void Update()
    {
        if (playerController.IsSprinting && _isSprintAllowed)
        {
            _sprintTimeCounter -= Time.deltaTime;
            Debug.Log(_sprintTimeCounter);
        }

        if (_sprintTimeCounter < 0 && _isSprintAllowed)
        {
            playerController.IsSprinting = false;
            StartCoroutine(WaitForNextSprint());
            _sprintTimeCounter = sprintTimeDuration;
        }
    }

    private IEnumerator WaitForNextSprint()
    {
        Debug.Log("Start");
        _isSprintAllowed = false;
        GetComponent<Image>().color = _unactiveSprint;
        yield return new WaitForSeconds(sprintTimeDuration);
        GetComponent<Image>().color = _activeSprint;
        _isSprintAllowed = true;
        Debug.Log("Finish");
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Sprint(true);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        Sprint(false);
    }

    public void Sprint(bool isSprinting)
    {
        playerController.IsSprinting = isSprinting;
    }
}
