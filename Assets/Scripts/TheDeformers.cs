using UnityEngine;

public class TheDeformers : MonoBehaviour
{
    float MoveSpeed = 4.0f;

    Rigidbody2D Rb;
    
    public Transform player;

    void Awake()
    {
        Rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        FollowPlayer();
    }

    void FollowPlayer()
    {
        if (player != null)
        {
            Vector2 direction = player.position - transform.position;

            direction.Normalize();

            Rb.velocity = direction * MoveSpeed;
        }
    }
}