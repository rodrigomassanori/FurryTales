using UnityEngine;

public class Player01 : MonoBehaviour
{
    Rigidbody2D Rb;

    float Speed = 5.0f;

    Vector2 Movement;

    Animator Anim;

    void Awake()
    {
        Anim = GetComponent<Animator>();

        Rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Movement.x = Input.GetAxis("Horizontal");

        Movement.y = Input.GetAxis("Vertical");

        Anim.SetFloat("Horizontal", Movement.x);

        Anim.SetFloat("Vertical", Movement.y);

        Anim.SetFloat("Speed", Movement.sqrMagnitude);
    }

    void FixedUpdate()
    {
        Rb.MovePosition(Rb.position + Movement * Speed * Time.deltaTime);
    }
}