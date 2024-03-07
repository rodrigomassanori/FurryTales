using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro;
using System.Collections;

public class MissionController : MonoBehaviour
{
    public TextMeshProUGUI Quest2;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player01"))
        {
            SceneManager.GetActiveScene();
        
            print("Quest2 text is active");

            StartCoroutine(ShowQuest2());
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            StopCoroutine(ShowQuest2());
        }
    }

    IEnumerator ShowQuest2()
    {
        yield return new WaitForSeconds(20.0f);

        Quest2.enabled = true;

        Quest2.gameObject.SetActive(true);
    }
}