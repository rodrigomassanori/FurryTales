using UnityEngine;

public class Tyamoon : MonoBehaviour 
{
    private Rigidbody2D CharRb;
    private Animator Anim;

    Vector2 Speed;

    void Awake()
    {
        CharRb = GetComponent<Rigidbody2D>();

        Anim = GetComponent<Animator>();
    }

    void Update()
    {
        Vector2 speed = CharRb.velocity;

        Anim.SetFloat("Vertical", speed.y);

        Anim.SetFloat("Horizontal", speed.x);

        Anim.SetFloat("Speed", speed.x + speed.y);
    }
}