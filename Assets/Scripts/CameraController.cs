using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform playerTransform;
    private Vector3 _offsetPosition;

    private void Update()
    {
        Vector3 playerPosition = playerTransform.position;
        _offsetPosition.Set(playerPosition.x, playerPosition.y, -10f);
        transform.position = _offsetPosition;
    }
}
