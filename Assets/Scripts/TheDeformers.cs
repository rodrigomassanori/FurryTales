using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class TheDeformers : MonoBehaviour
{
    float MoveSpeed = 4.0f;

    Rigidbody2D Rb;
    
    public Transform player;

    float Rotation;

    Vector2 Direction;

    public List<Sprite> Spr;

    SpriteRenderer Sp;

    public TextMeshProUGUI MonsterQuest;

    void Awake()
    {
        Rb = GetComponent<Rigidbody2D>();

        Sp = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        FollowPlayer();

        StartCoroutine(RunTheDeformer());
    }

    IEnumerator RunTheDeformer()
    {
        yield return new WaitForSeconds(3.0f);

        MonsterQuest.enabled = true;

        MonsterQuest.gameObject.SetActive(true);

        MonsterQuest.text = "Find the door and escape The Deformer!";

        yield return new WaitForSeconds(15.0f);

        MonsterQuest.enabled = false;

        MonsterQuest.gameObject.SetActive(false);
    }

    void FollowPlayer()
    {
        if (Vector2.Distance(transform.position, player.position) > 3.0f 
        && player.gameObject.tag == "Player")
        {
            Direction = (Vector2)(player.transform.position - transform.position).normalized;

            Rotation = Mathf.Atan2(Direction.x, Direction.y) / Mathf.PI * 8.0f + 8.0f;

            Sp.sprite = Spr[(int)Mathf.Round(Rotation * 16) % 16];

            Rb.MovePosition((Vector2)transform.position + Direction * MoveSpeed * Time.deltaTime);
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
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