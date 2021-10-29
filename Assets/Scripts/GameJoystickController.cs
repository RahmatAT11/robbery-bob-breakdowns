using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class GameJoystickController : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
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
            Vector2 rectTransformSizeDeltaJoystickBg = _imageJoystickBackground.rectTransform.sizeDelta;
            // make the values a bit lower
            _inputPosition.x = _inputPosition.x / rectTransformSizeDeltaJoystickBg.x;
            _inputPosition.y = _inputPosition.y / rectTransformSizeDeltaJoystickBg.y;
            Debug.Log(_inputPosition.x + " / " + _inputPosition.y);
            
            // normalize the input position
            _inputPosition = _inputPosition.normalized;
            
            // move the joystick
            _imageJoystick.rectTransform.anchoredPosition = new Vector2(
                _inputPosition.x * (rectTransformSizeDeltaJoystickBg.x / 3.5f), 
                _inputPosition.y * (rectTransformSizeDeltaJoystickBg.y / 3.5f));
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

    public float InputHorizontal()
    {
        if (_inputPosition.x != 0)
        {
            return _inputPosition.x;
        }
        else
        {
            return Input.GetAxis("Horizontal");
        }
    }

    public float InputVertical()
    {
        if (_inputPosition.y != 0)
        {
            return _inputPosition.y;
        }
        else
        {
            return Input.GetAxis("Vertical");
        }
    }
}
