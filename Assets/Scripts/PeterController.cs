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

    Rigidbody rb;
    
    void Awake()
    {
        print("Initialized(" + this.name + ")");

        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        Vaxis = Input.GetAxis("Vertical");

        Haxis = Input.GetAxis("Horizontal");

        IsJumping = Input.GetButton("Jump");

        IsJumpingAlt = Input.GetKey(KeyCode.Joystick1Button0);

        RunningSpeed = Vaxis;

        if(IsGrounded)
        {
            Movement = new Vector3(0, 0, RunningSpeed * 8);

            Movement = transform.TransformDirection(Movement);
        }

        else
        {
            Movement *= 0.70f;
        }

        rb.AddForce(Movement * MoveSpeed);

        if ((IsJumping || IsJumpingAlt) && IsGrounded)
        {
            print(this.ToString() + " IsJumping = " + IsJumping);

            rb.AddForce(Vector3.up * 150);
        }

        if ((Input.GetAxis("Vertical") != 0f || Input.GetAxis("Horizontal") != 0f) 
        && !IsJumping && IsGrounded)
        {
            if (Input.GetAxis("Vertical") >= 0)
            {
                transform.Rotate(new Vector3(0, Haxis * RotationSpeed, 0));
            }
                
            else
            {
                transform.Rotate(new Vector3(0, -Haxis * RotationSpeed, 0));
            }
        }
    }

    void OnCollisionEnter(Collision other)
    {
        print("Entered");

        if (other.gameObject.CompareTag("Ground"))
        {
            IsGrounded = true;
        }
    }

    void OnCollisionExit(Collision other)
    {
        print("Exited");

        if (other.gameObject.CompareTag("Ground"))
        {
            IsGrounded = false;
        }
    }
}