using UnityEngine;

public class TheDeformers : MonoBehaviour
{
    float MoveSpeed = 4.0f;

    Rigidbody2D Rb;
    
    public Transform player;

    float Angle;

    Vector2 Direction;

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
            Direction = player.position - transform.position;

            Direction.Normalize();

            Rb.velocity = Direction * MoveSpeed;

            Angle = Mathf.Atan2(Direction.x, Direction.y) * Mathf.Rad2Deg;

            transform.rotation = Quaternion.Euler(new Vector2(0.0f, Angle));
        }
    }
}