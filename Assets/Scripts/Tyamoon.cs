using UnityEngine;

public class Tyamoon : MonoBehaviour 
{
    Rigidbody2D CharRb;
    
    Animator Anim;

    Vector2 Speed;

    public Transform Pl;

    void Awake()
    {
        CharRb = GetComponent<Rigidbody2D>();

        Anim = GetComponent<Animator>();
    }

    void Update()
    {
        Speed = CharRb.velocity;

        if (Vector2.Distance(transform.position, Pl.transform.position) > 3)
        {
            Anim.SetFloat("Vertical", Speed.y);

            Anim.SetFloat("Horizontal", Speed.x);

            Anim.SetFloat("Speed", Speed.x + Speed.y);
        }
    }
}