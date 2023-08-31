using UnityEngine;
using UnityEngine.AI;
using System.Collections;

public class TheDeformers : MonoBehaviour
{
    public GameObject PL;

    Transform player;

    float SpeedMovement = 3.5f;

    AudioSource CreepyFox;

    NavMeshAgent agent;

    void Awake()
    {
        CreepyFox = GetComponent<AudioSource>();

        agent = GetComponent<NavMeshAgent>();

        player = GetComponent<Transform>();
    }

    void Start()
    {
        if (PL.gameObject.tag == "Player")
        {
            //CreepyFox.Play();

            agent.destination = player.position;
            
            transform.Translate(0, Time.deltaTime, 10 * SpeedMovement, Space.World);
        }
    }

    void Update()
    {
        StartCoroutine(BackToSpawn());
    }

    IEnumerator BackToSpawn()
    {
        yield return new WaitForSeconds(20.0f);

        agent.destination = transform.position;

        transform.Translate(0, Time.deltaTime, 0, Space.World);
    }
}