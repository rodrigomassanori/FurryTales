using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class EndChapter01 : MonoBehaviour 
{
    public TextMeshProUGUI EndMission;

    void Start()
    {
        StartCoroutine(EndPart01());
    }

    IEnumerator EndPart01()
    {
        yield return new WaitForSeconds(5.0f);

        EndMission.text = "So....we saved this world to a giant catastrophe.....\n and what will come to us?...";

        yield return new WaitForSeconds(10.0f);

        SceneManager.LoadScene("EndGame");
    }
}