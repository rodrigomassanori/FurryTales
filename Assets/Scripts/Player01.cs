using UnityEngine;

public class Player01 : MonoBehaviour
{
    Rigidbody2D Rb;

    float Speed = 2.0f;

    Vector2 Movement;

    void Awake()
    {
        Rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float H = Input.GetAxisRaw("Horizontal");

        float V = Input.GetAxisRaw("Vertical");

        Movement = new Vector2(H, V).normalized;

        Rb.velocity = Movement * Speed * Time.deltaTime;
    }
}