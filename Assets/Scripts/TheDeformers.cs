using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class TheDeformers : MonoBehaviour
{
    public TextMeshProUGUI MonsterQuest;

    Rigidbody2D CharRb;

    Animator Anim;
    
    public Transform Pl;
    
    float Speed = 3.0f;

    AudioSource DeformedFox;

    void Awake()
    {
        CharRb = GetComponent<Rigidbody2D>();

        Anim = GetComponent<Animator>();

        DeformedFox = GetComponent<AudioSource>();
    }

    void Start()
    {
        Pl = GameObject.FindGameObjectWithTag("Player01").transform;
    }

    void Update()
    {
        Vector2 direction = (Pl.position - transform.position).normalized;

        float horizontalSpeed = direction.x * Speed;
        
        float verticalSpeed = direction.y * Speed;

        Anim.SetFloat("Vertical", verticalSpeed);
        
        Anim.SetFloat("Horizontal", horizontalSpeed);
        
        Anim.SetFloat("Speed", Mathf.Abs(horizontalSpeed) + Mathf.Abs(verticalSpeed));

        if (Vector2.Distance(transform.position, Pl.position) > 3.0f)
        {
            CharRb.velocity = direction * Speed;

            DeformedFox.Play();
        }
        
        else
        {
            CharRb.velocity = Vector2.zero;
        }

        StartCoroutine(RunTheDeformer());
    }

    IEnumerator RunTheDeformer()
    {
        yield return new WaitForSeconds(50.0f);

        MonsterQuest.enabled = true;

        MonsterQuest.gameObject.SetActive(true);

        MonsterQuest.text = "Find the door and escape The Deformer!";

        yield return new WaitForSeconds(75.0f);

        MonsterQuest.enabled = false;

        MonsterQuest.gameObject.SetActive(false);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player01"))
        {
            StartCoroutine(GameOverScene());
        }
    }

    IEnumerator GameOverScene()
    {
        yield return new WaitForSeconds(15.0f);

        SceneManager.LoadScene("GameOver");
    }
}