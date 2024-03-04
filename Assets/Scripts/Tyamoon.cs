using UnityEngine;

public class Tyamoon : MonoBehaviour 
{
    Rigidbody2D CharRb;

    Animator Anim;
    
    public Transform Pl;
    
    public float speed = 5f; 

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

        float horizontalSpeed = direction.x * speed;
        
        float verticalSpeed = direction.y * speed;

        Anim.SetFloat("Vertical", verticalSpeed);
        
        Anim.SetFloat("Horizontal", horizontalSpeed);
        
        Anim.SetFloat("Speed", Mathf.Abs(horizontalSpeed) + Mathf.Abs(verticalSpeed));

        if (Vector2.Distance(transform.position, Pl.position) > 3.0f)
        {
            CharRb.velocity = direction * speed;
        }
        
        else
        {
            CharRb.velocity = Vector2.zero;
        }
    }
}