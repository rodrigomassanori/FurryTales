using UnityEngine;

public class Partner : MonoBehaviour
{
	float Speed = 3.0f;
	
	Animator Anim;
    
	Rigidbody2D Rb;

    void Awake()
    {
        Anim = GetComponent<Animator>();

        Rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Speed = Rb.velocity.magnitude;

        Anim.SetFloat("Speed", Speed);
    }
}