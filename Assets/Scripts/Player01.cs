using UnityEngine;

public class Player01 : MonoBehaviour
{
    Rigidbody2D rb;

    [SerializeField]
    float MoveSpeed;

    Vector2 Movement;

    Animator Anim;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();

        Anim = GetComponent<Animator>();
    }

    void Update()
    {
        Anim.Play("Idle");

        Movement.x = Input.GetAxisRaw("Horizontal");

        Movement.y = Input.GetAxisRaw("Vertical");

        transform.position = new Vector2(Mathf.Clamp(transform.position.x, -30.0f, 30.0f), 
        Mathf.Clamp(transform.position.y, -30.0f, 30.0f));

        Anim.SetFloat("Horizontal", Movement.x);

        Anim.SetFloat("Vertical", Movement.y);

        Anim.SetFloat("Speed", Movement.sqrMagnitude);
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + Movement * MoveSpeed * Time.deltaTime);
    }
}