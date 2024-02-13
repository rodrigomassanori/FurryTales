using System.Collections.Generic;
using UnityEngine;

public class TheDeformers : MonoBehaviour
{
    float MoveSpeed = 4.0f;

    Rigidbody2D Rb;
    
    public Transform player;

    float Rotation;

    Vector2 Direction;

    public List<Sprite> Spr;

    SpriteRenderer Sp;

    void Awake()
    {
        Rb = GetComponent<Rigidbody2D>();

        Sp = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        FollowPlayer();
    }

    void FollowPlayer()
    {
        if (Vector2.Distance(transform.position, player.position) > 3.0f 
        && player.gameObject.tag == "Player")
        {
            Direction = (Vector2)(player.transform.position - transform.position).normalized;

            Rotation = Mathf.Atan2(Direction.x, Direction.y) / Mathf.PI * 4.0f + 4.0f;

            Sp.sprite = Spr[(int)Mathf.Round(Rotation * 16) % 16];

            Rb.MovePosition((Vector2)transform.position + Direction * MoveSpeed * Time.deltaTime);
        }
    }
}