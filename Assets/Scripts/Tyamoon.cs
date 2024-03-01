using UnityEngine;

public class Tyamoon : MonoBehaviour 
{
    Rigidbody2D CharRb;
    
    Animator Anim;

    Vector2 Speed;

    void Awake()
    {
        CharRb = GetComponent<Rigidbody2D>();

        Anim = GetComponent<Animator>();
    }

    void Update()
    {
        Speed = CharRb.velocity;

        Anim.SetFloat("Vertical", Speed.y);

        Anim.SetFloat("Horizontal", speed.x);

        Anim.SetFloat("Speed", Speed.x + Speed.y);
    }
}