using UnityEngine;

public class Player01 : MonoBehaviour
{
    Rigidbody2D Rb;

    float Speed = 2.0f;

    Vector2 Movement;

    Animator Anim;

    void Awake()
    {
        Anim = GetComponent<Animator>();

        Rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float H = Input.GetAxisRaw("Horizontal");

        float V = Input.GetAxisRaw("Vertical");

        Movement = new Vector2(H, V).normalized;

        Rb.velocity = Movement * Speed;

        bool x = H > 0;

        bool y = V > 0;

        Anim.SetBool("WalkingUp", y);

        Anim.SetBool("WalkingDown", !y);

        Anim.SetBool("WalkingLeft", !x);

        Anim.SetBool("WalkingRight", x);
    }
}