using UnityEngine;

public class Player01 : MonoBehaviour
{
    Rigidbody2D rb;

    float MoveSpeed = 0.4f;

    Vector3 Movement;

    Animator Anim;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();

        Anim = GetComponent<Animator>();
    }

    void Update()
    {
        Movement = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), 0.0f);

        Anim.SetFloat("Horizontal", Movement.x);

        Anim.SetFloat("Vertical", Movement.y);

        Anim.SetFloat("Speed", Movement.magnitude);

        transform.position = transform.position + Movement * MoveSpeed * Time.deltaTime;
    }
}