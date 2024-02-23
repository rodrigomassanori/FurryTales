using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Intro2 : MonoBehaviour
{
    Animator ComicAnim;

    public Image Comic;

    void Awake()
    {
        ComicAnim = GetComponent<Animator>();
    }

    void OnEnable()
    {
        Comic.enabled = true;

        Comic.gameObject.SetActive(true);

        StartCoroutine(HideComic());
    }

    IEnumerator HideComic()
    {
        yield return new WaitForSeconds(10.0f);

        ComicAnim.Play("ComicIntro");
    }
}