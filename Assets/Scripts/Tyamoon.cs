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
        if (Vector2.Distance(transform.position, Pl.transform.position) > 3.0f && Pl.gameObject.tag == "Player")
        {
            Speed = CharRb.velocity * Time.deltaTime;

            Anim.SetFloat("Vertical", Speed.y);

            Anim.SetFloat("Horizontal", Speed.x);

            Anim.SetFloat("Speed", Speed.sqrMagnitude);

            CharRb.MovePosition(CharRb.position + Speed * Time.deltaTime);
        }
    }
}