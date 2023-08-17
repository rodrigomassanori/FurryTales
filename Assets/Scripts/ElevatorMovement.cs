using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[RequireComponent(typeof(Rigidbody))]
public class ElevatorMovement : MonoBehaviour
{
    [SerializeField]
    Transform[] levels;

    int currentLevel;

    [SerializeField]
    int targetedLevel;

    [SerializeField]
    float elevatorSpeed;

    Rigidbody elevatorRb;

    void Awake()
    {
        elevatorRb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            if (targetedLevel + 1 < levels.Length)
            {
                targetedLevel++;
            }
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            if (targetedLevel - 1 >= 0)
            {
                targetedLevel--;
            }
        }

        if (transform.position.y != levels[targetedLevel].transform.position.y)
        {
            GoTo(levels[targetedLevel], elevatorRb);
        }

        CheckCurrentLevel(levels);
    }

    IEnumerator CheckCurrentLevel(Transform[] levels)
    {
        for (int c = 0; c < levels.Length; c++)
        {
            if (transform.position.y >= levels[c].transform.position.y)
            {
                currentLevel = c;

                yield return new WaitForSeconds(6.0f);
            }
        }
    }

    void GoTo(Transform target, Rigidbody Rb)
    {

        if (target.position.y > Rb.position.y)
        {
            Rb.MovePosition(Rb.position + (Vector3.up * Time.deltaTime * elevatorSpeed));
        }

        else
        {
            Rb.MovePosition(Rb.position + (-Vector3.up * Time.deltaTime * elevatorSpeed));
        }

        if (Vector3.Distance(target.position, Rb.position) < 0.05)
        {
            Rb.MovePosition(target.position);
        }
    }
}