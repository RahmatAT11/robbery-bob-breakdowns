using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class GameController : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler
{
    private Image _imageJoystickBackground;
    private Image _imageJoystick;
    private Vector2 _inputPosition;

    private void Awake()
    {
        _imageJoystickBackground = GetComponent<Image>();
        _imageJoystick = transform.GetChild(0).GetComponent<Image>();
    }

    public void OnDrag(PointerEventData eventData)
    {
        // get the position on joystick background when dragging
        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(
            _imageJoystickBackground.rectTransform,
            eventData.position,
            eventData.pressEventCamera,
            out _inputPosition))
        {
            // make the values a bit lower
            _inputPosition.x = _inputPosition.x / _imageJoystickBackground.rectTransform.sizeDelta.x;
            _inputPosition.y = _inputPosition.y / _imageJoystickBackground.rectTransform.sizeDelta.y;
            Debug.Log(_inputPosition.x + " / " + _inputPosition.y);
            
            // normalize the input position
            _inputPosition = _inputPosition.normalized;
            
            // move the joystick
            _imageJoystick.rectTransform.anchoredPosition = new Vector2(
                _inputPosition.x * (_imageJoystickBackground.rectTransform.sizeDelta.x / 3.5f), 
                _inputPosition.y * (_imageJoystickBackground.rectTransform.sizeDelta.y / 3.5f));
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        OnDrag(eventData);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        _inputPosition = Vector2.zero;
        _imageJoystick.rectTransform.anchoredPosition = Vector2.zero;
    }
}
