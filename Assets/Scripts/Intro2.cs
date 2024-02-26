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
    void Start()
    {
        StartCoroutine(HideComic());
    }

    IEnumerator HideComic()
    {
        yield return new WaitForSeconds(10.0f);

        ComicAnim.Play("ComicIntro");
    }
}