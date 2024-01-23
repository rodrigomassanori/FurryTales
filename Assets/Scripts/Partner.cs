using UnityEngine;

public class Partner : MonoBehaviour
{
	float Speed = 3.0f;

    Transform Player;

    Vector2 Direction;
	
	Animator Anim;
    
	Rigidbody2D Rb;

    void Awake()
    {
        Anim = GetComponent<Animator>();

        Rb = GetComponent<Rigidbody2D>();

        Player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        if (Player != null)
        {
            Direction = Player.position - transform.position;

            Direction.Normalize();

            transform.Translate(Direction * Speed * Time.deltaTime);
        }

        float Angle = Mathf.Atan2(Direction.x, Direction.y) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.AngleAxis(Angle, Vector3.forward);
    }
}