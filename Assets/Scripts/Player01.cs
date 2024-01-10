using UnityEngine;

public class Player01 : MonoBehaviour
{
    Rigidbody2D rb;

    float MoveSpeed = 0.4f;

    Vector2 Movement;

    Animator Anim;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();

        Anim = GetComponent<Animator>();
    }

    void Update()
    {
        Movement.x = Input.GetAxisRaw("Horizontal");

        Movement.y = Input.GetAxisRaw("Vertical");

        transform.position = new Vector2(Mathf.Clamp(transform.position.x, -30.0f, 30.0f), 
        Mathf.Clamp(transform.position.y, -30.0f, 30.0f));

        if (rb.velocity.x > 0)
        {
            Anim.SetFloat("Horizontal", Movement.x);

            Anim.SetFloat("Speed", Movement.sqrMagnitude);
        }

        if (rb.velocity.x < 0)
        {
            Anim.SetFloat("Horizontal", -Movement.x);

            Anim.SetFloat("Speed", Movement.sqrMagnitude);
        }

        if (rb.velocity.y > 0)
        {
            Anim.SetFloat("Vertical", -Movement.y);

            Anim.SetFloat("Speed", Movement.sqrMagnitude);
        }

        if (rb.velocity.y < 0)
        {
            Anim.SetFloat("Vertical", Movement.y);

            Anim.SetFloat("Speed", Movement.sqrMagnitude);
        }
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + Movement * MoveSpeed * Time.deltaTime);
    }
}