using UnityEngine;

public class Player01 : MonoBehaviour
{
    Rigidbody2D Rb;

    float Speed = 5.0f;

    Vector3 Movement;

    Vector2 MoveRb;

    Animator Anim;

    void Awake()
    {
        Anim = GetComponent<Animator>();

        Rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float H = Input.GetAxis("Horizontal");

        float V = Input.GetAxis("Vertical");

        if(H != 0.0f || V != 0.0f)
        {
            Anim.SetFloat("Horizontal", H);

            Anim.SetFloat("Vertical", V);

            Anim.SetFloat("Speed", Movement.magnitude);
        }

        Movement = new Vector3(H, V, 0.0f) * Speed * Time.deltaTime;

        transform.Translate(Movement);

        Rb.MovePosition(Rb.position + MoveRb * Speed * Time.deltaTime);
    }
}