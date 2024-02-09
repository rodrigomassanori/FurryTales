using UnityEngine;
using System.Collections;

public class TheDeformers : MonoBehaviour
{
    float MoveSpeed = 4.0f;

    Rigidbody2D Rb;

    void Awake()
    {
        Rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Vector2 Direction = (Vector2.zero - Rb.position).normalized;

        Rb.MovePosition(Rb.position + Direction * MoveSpeed * Time.deltaTime);
    }
}