using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class TheDeformers : MonoBehaviour
{
    float MoveSpeed = 4.0f;

    Rigidbody2D Rb;
    
    public Transform player;

    public Vector2[] Directions;

    public TextMeshProUGUI MonsterQuest;

    Animator AnimMonster;

    int CurrentDirectionIndex = 0;

    void Awake()
    {
        AnimMonster = GetComponent<Animator>();

        Rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        UpdateAnim();

        Walking();

        StartCoroutine(RunTheDeformer());
    }

    void Walking()
    {
        Rb.velocity = Directions[CurrentDirectionIndex] * MoveSpeed;
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

    void UpdateAnim()
    {
        AnimMonster.SetFloat("Horizontal", Directions[CurrentDirectionIndex].x);

        AnimMonster.SetFloat("Vertical", Directions[CurrentDirectionIndex].y);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag =="Player")
        {
            StartCoroutine(GameOverScene());
        }

        else if(other.gameObject.tag == "Walls")
        {
            CurrentDirectionIndex = (CurrentDirectionIndex + 1) % Directions.Length;
        }
    }

    IEnumerator GameOverScene()
    {
        yield return new WaitForSeconds(15.0f);

        SceneManager.LoadScene("GameOver");
    }
}