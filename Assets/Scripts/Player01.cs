using UnityEngine;

public class Player01 : MonoBehaviour
{
    Rigidbody2D rb;

    float MoveSpeed = 0.4f;

    float Movement;

    Vector2 position;

    Animator Anim;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();

        Anim = GetComponent<Animator>();
    }

    void Update()
    {
        Movement = Input.GetAxisRaw("Horizontal");

        Movement = Input.GetAxisRaw("Vertical");

        transform.position = new Vector2(Mathf.Clamp(transform.position.x, -30.0f, 30.0f), 
        Mathf.Clamp(transform.position.y, -30.0f, 30.0f));

        if (rb.velocity.x > 0)
        {
            Anim.SetFloat("Horizontal", Movement);

            Anim.SetFloat("Speed", Movement);
        }

        if (rb.velocity.x < 0)
        {
            Anim.SetFloat("Horizontal", -Movement);

            Anim.SetFloat("Speed", Movement);
        }

        if (rb.velocity.y > 0)
        {
            Anim.SetFloat("Vertical", -Movement);

            Anim.SetFloat("Speed", Movement);
        }

        if (rb.velocity.y < 0)
        {
            Anim.SetFloat("Vertical", Movement);

            Anim.SetFloat("Speed", Movement);
        }
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + position * MoveSpeed * Time.deltaTime);
    }
}