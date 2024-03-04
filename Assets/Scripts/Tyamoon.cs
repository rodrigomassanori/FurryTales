using UnityEngine;

public class Tyamoon : MonoBehaviour 
{
    Rigidbody2D CharRb;

    Animator Anim;
    
    public Transform Pl;
    
    float Speed = 2.5f; 

    void Awake()
    {
        CharRb = GetComponent<Rigidbody2D>();

        Anim = GetComponent<Animator>();
    }

    void Start()
    {
        Pl = GameObject.FindGameObjectWithTag("Player01").transform;
    }

    void Update()
    {
        Vector2 direction = (Pl.position - transform.position).normalized;

        float HorizontalSpeed = direction.x * Speed;
        
        float VerticalSpeed = direction.y * Speed;

        Anim.SetFloat("Vertical", VerticalSpeed);
        
        Anim.SetFloat("Horizontal", HorizontalSpeed);
        
        Anim.SetFloat("Speed", Mathf.Abs(HorizontalSpeed) + Mathf.Abs(VerticalSpeed));

        if (Vector2.Distance(transform.position, Pl.position) > 3.0f)
        {
            CharRb.velocity = direction * Speed;
        }
        
        else
        {
            CharRb.velocity = Vector2.zero;
        }
    }
}