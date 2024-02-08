using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Player01 : MonoBehaviour
{
    Rigidbody2D Rb;

    float Speed = 5.0f;

    Vector2 Movement;

    Animator Anim;

    KeyCode E = KeyCode.E;

    public RawImage Map;

    void Awake()
    {
        Anim = GetComponent<Animator>();

        Rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Movement.x = Input.GetAxisRaw("Horizontal");

        Movement.y = Input.GetAxisRaw("Vertical");

        Anim.SetFloat("Horizontal", Movement.x);

        Anim.SetFloat("Vertical", Movement.y);

        Anim.SetFloat("Speed", Movement.sqrMagnitude);

        if (Input.GetKeyDown(E))
        {
            StartCoroutine(ShowMap());
        }
        
        else if(Input.GetKeyUp(E)) 
        {
            StartCoroutine(HideMap());
        }
    }

    void FixedUpdate()
    {
        Rb.MovePosition(Rb.position + Movement * Speed * Time.deltaTime);
    }

    IEnumerator ShowMap()
    {
        yield return new WaitForSeconds(10.0f);

        Map.enabled = true;

        Map.gameObject.SetActive(true);
    }

    IEnumerator HideMap()
    {
        yield return new WaitForSeconds(10.0f);

        Map.enabled = false;

        Map.gameObject.SetActive(false);
    }
}