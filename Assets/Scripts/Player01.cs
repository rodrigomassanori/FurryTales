using UnityEngine;

public class Player01 : MonoBehaviour
{
    Rigidbody2D rb;

    float MoveSpeed = 0.9f;

    Vector2 Movement;

    Animator Anim;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();

        Anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetAxisRaw("Horizontal") > 0)
        {
            Anim.SetBool("Walking", true);

            Anim.SetFloat("Horizontal", Movement.x);
        }

        if (Input.GetAxisRaw("Horizontal") < 0)
        {
            Anim.SetBool("Walking", true);

            Anim.SetFloat("Horizontal", -Movement.x);
        }

        if (Input.GetAxisRaw("Vertical") > 0)
        {
            Anim.SetBool("Walking", true);

            Anim.SetFloat("Vertical", Movement.y);
        }

        if (Input.GetAxisRaw("Vertical") < 0)
        {
            Anim.SetBool("Walking", true);

            Anim.SetFloat("Vertical", -Movement.y);
        }
    }
}