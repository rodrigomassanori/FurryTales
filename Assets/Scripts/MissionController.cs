using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro;
using System.Collections;

public class MissionController : MonoBehaviour
{
    public TextMeshProUGUI Quest2;

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            SceneManager.GetActiveScene();
        
            print("Quest2 text is active");

            StartCoroutine(ShowQuest2());
        }
    }

    void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            StopAllCoroutines();
        }
    }

    IEnumerator ShowQuest2()
    {
        yield return new WaitForSeconds(20.0f);

        Quest2.enabled = true;

        Quest2.gameObject.SetActive(true);
    }
}