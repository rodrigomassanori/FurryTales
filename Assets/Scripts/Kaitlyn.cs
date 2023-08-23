using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kaitlyn : MonoBehaviour
{
    float forwardMovement = 3.5f;

    float leftMovement = 8.0f;

    float rightMovement = 8.0f;

    float backMovement = 3.0f;

    float velocidade = 6.5f;

    float girar = 17.5f;

    readonly KeyCode W = KeyCode.W;

    readonly KeyCode A = KeyCode.A;

    readonly KeyCode D = KeyCode.D;

    readonly KeyCode S = KeyCode.S;

    CharacterController ch;

    float gravityValue = -1.5f;

    float jumpHeight = 10.0f;

    bool isGrounded = false;

    Vector3 playerVelocity;

    void Awake()
    {
        ch = GetComponentInChildren<CharacterController>();
    }

    void Update()
    {
        transform.Rotate(0, Input.GetAxisRaw("Horizontal") * girar * Time.fixedDeltaTime, 0);

        Vector3 forward = transform.TransformDirection(Vector3.forward);

        float Giro = velocidade * Input.GetAxisRaw("Vertical");

        ch.SimpleMove(forward * Giro);

        ch.detectCollisions = true;
        
        if(ch.isGrounded)
        {
            isGrounded = ch.isGrounded;

            if (isGrounded && playerVelocity.y < 0)
            {
                isGrounded = true;

                playerVelocity.y = 0.0f;
            }

            if (Input.GetButtonDown("Jump"))
            {
                print("Botão de pulo apertado");

                print("Is Grounded?" + isGrounded);

                if (isGrounded)
                {
                    playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
                }

                playerVelocity.y += gravityValue * Time.deltaTime;

                ch.Move(playerVelocity * Time.deltaTime);
            }

            if(Input.GetKey(A))
            {
                Vector3 position = transform.TransformDirection(Vector3.right *
                rightMovement * Time.fixedDeltaTime);
            }

            else if(Input.GetKey(D))
            {
                Vector3 position = transform.TransformDirection(Vector3.left * 
                leftMovement * Time.fixedDeltaTime);
            }

            if (Input.GetKey(W))
            {
                Vector3 position = transform.TransformDirection (Vector3.forward *
                forwardMovement * Time.fixedDeltaTime);
            }

            else if (Input.GetKey(S))
            {
                Vector3 position = transform.TransformDirection (Vector3.back *
                backMovement * Time.fixedDeltaTime);
            }
        }
    }
}