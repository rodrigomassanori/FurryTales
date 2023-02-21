using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PeterController : MonoBehaviour 
{
    float MoveSpeed = 2.0f;

    float RotationSpeed = 4.0f;

    float RunningSpeed;

    float Vaxis, Haxis;
    
    public bool IsJumping, IsJumpingAlt, IsGrounded = false;
    
    Vector3 Movement;
    
    void Awake()
    {
        print("Initialized (" + this.name + ")");
    }

    
}