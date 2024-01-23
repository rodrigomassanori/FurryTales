using UnityEngine;

public class Partner : MonoBehaviour
{
	float Speed = 3.0f;

    Transform Player;
	
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
            Vector2 Direction = Player.position - transform.position;

            Direction.Normalize();

            transform.Translate(Direction * Speed * Time.deltaTime);
        }
    }
}