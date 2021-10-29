using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform playerTransform;
    private Vector3 _offsetPosition;

    private void Update()
    {
        _offsetPosition.Set(playerTransform.position.x, playerTransform.position.y, -10f);
        transform.position = _offsetPosition;
    }
}
