using UnityEngine;

public class Partner : MonoBehaviour
{
    public float Speed = 5.0f;
    
    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");

        float verticalInput = Input.GetAxis("Vertical");

        Vector2 movement = new Vector2(horizontalInput, verticalInput);

        movement.Normalize();
        
        rb.velocity = movement * Speed;

        // Optionally, you can add an animation parameter for movement direction in an Animator.
        // For example, if you have a "Direction" parameter, you can set it like this:
        // animator.SetFloat("DirectionX", movement.x);
        // animator.SetFloat("DirectionY", movement.y);
    }
}