using UnityEngine;

public class TyamoonAnimation : MonoBehaviour
{
    float vel = 8.5f;

    Rigidbody rb;

    Animator an;

    Vector3 mover;

    bool AutoJump;

    bool PickupAnim;

    void Awake()
    {
        an = GetComponent<Animator>();

        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        float h = Input.GetAxisRaw("Horizontal") * Time.deltaTime;

        float v = Input.GetAxisRaw("Vertical") * Time.deltaTime;

        Move(h, v);

        Anima(h, v);

        PickItem(PickupAnim);
    }

    void Move(float h, float v)
    {
        mover.Set(h, 0.0f, v);

        mover = mover.normalized * vel * Time.deltaTime;

        rb.MovePosition(transform.position + mover);
    }

    void Anima(float h, float v)
    {
        bool walking = h != 0.0f || v != 0.0f;

        an.SetBool("Walking", walking);
    }

    bool PickItem(bool AnimPickup)
    {
        an.Play("Pickup");
        
        return PickupAnim;
    }
}