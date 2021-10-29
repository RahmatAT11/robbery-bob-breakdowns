using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class GameSprintController : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] private PlayerController playerController;
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
