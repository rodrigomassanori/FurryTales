using UnityEngine;
using System.Collections;

public class TheDeformers : MonoBehaviour
{
    public GameObject TD;

    public GameObject PL;

    float SpeedMovement = 3.5f;

    AudioSource CreepyFox;

    void Awake()
    {
        CreepyFox = GetComponent<AudioSource>();
    }

    void Start()
    {
        if (TD.gameObject.tag == "Monster")
        {
            CreepyFox.Play();
            
            transform.Translate(0, Time.deltaTime, 10, Space.World);
        }
    }

    void Update()
    {
        StartCoroutine(BackToSpawn());
    }

    IEnumerator BackToSpawn()
    {
        yield return new WaitForSeconds(20.0f);

        transform.Translate(0, Time.deltaTime, 0, Space.World);
    }
}