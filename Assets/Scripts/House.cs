using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine;

public class House : MonoBehaviour 
{
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player01"))
        {
            StartCoroutine(EnterHouse());
        }
    }

    IEnumerator EnterHouse()
    {
        yield return new WaitForSeconds(10.0f);

        SceneManager.LoadScene("Game7");
    }
}