using UnityEngine;

public class CharacterBaseController : MonoBehaviour
{
    protected float MovementSpeed = 10.0f;
    protected Vector3 MovementDirection;

    protected Rigidbody2D Rigidbody2D;
    
    protected bool isSprinting;
    public bool IsSprinting
    {
        get
        {
            return isSprinting;
        }
        set
        {
            isSprinting = value;
        }
    }
    protected float _sprintSpeedMultiplier = 1.7f;

    protected virtual void Walking()
    {
        // menggerakkan player ke vector
        Rigidbody2D.velocity = MovementDirection * MovementSpeed;
    }

    protected virtual void Turning()
    {
        // rotate if vector _movementDirection is not zero
        if (MovementDirection != Vector3.zero)
        {
            float angle = Vector2.SignedAngle(transform.up, MovementDirection);
            
            Rigidbody2D.MoveRotation(Rigidbody2D.rotation + angle);
        }
    }
    
    protected virtual void Sprinting()
    {
        if (IsSprinting)
        {
            Rigidbody2D.velocity = MovementDirection * (MovementSpeed * _sprintSpeedMultiplier);
        }
    }

    protected virtual void SetRotationToZero()
    {
        transform.rotation = new Quaternion(0f, 0f, 0f, 0f);
    }
}