using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class Intro2 : MonoBehaviour
{
    public Image Comic;

    void Start()
    {
        StartCoroutine(HideComic());
    }

    IEnumerator HideComic()
    {
        yield return new WaitForSeconds(10.0f);

        Comic.enabled = false;

        Comic.gameObject.SetActive(false);

        yield return new WaitForSeconds(15.0f);

        SceneManager.LoadScene("GameIntro");
    }
}