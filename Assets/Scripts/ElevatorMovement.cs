using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorMovement : MonoBehaviour
{
    Vector3 StartPos;

    Vector3 EndPos;

    [Header("Height")]
    [Range(1, 20)]
    float FinalHeight = -1.0f;

    [Header("Speed to work")]
    [Range(1, 10)]
    float Speed = 2.0f;

    [Range(0, 5)]
    [Header("Reset Time")]
    float TimeStand = 2.0f;

    void Start()
    {
        StartPos = transform.position;

        EndPos = Vector3.up * FinalHeight;
    }

    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, EndPos, Speed * Time.deltaTime);

        if(transform.position == EndPos)
        {
            InvokeRepeating("ResetPos", TimeStand, 0);
        }

        else
        {
            CancelInvoke("ResetPos");
        }
    }

    void ResetPos()
    {
        EndPos = StartPos;

        StartPos = transform.position;
    }
    
    void OnDrawGizmos()
    {
        Vector3 ActualSize = transform.localScale;

        Vector3 FinalPos = transform.position - Vector3.up * FinalHeight;

        Gizmos.color = Color.yellow;

        Gizmos.DrawWireCube(new Vector3(transform.localPosition.x, transform.localPosition.y + FinalHeight / 2, 
        transform.localPosition.z), new Vector3(ActualSize.x, ActualSize.y, ActualSize.z));

        Gizmos.color = Color.blue;

        Gizmos.DrawCube(FinalPos, ActualSize);
    }
}