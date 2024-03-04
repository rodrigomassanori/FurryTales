using UnityEngine.SceneManagement;
using UnityEngine;
using System.Collections;

public class SceneController : MonoBehaviour 
{
	void Start()
	{
		StartCoroutine(Respawn());
	}

    IEnumerator Respawn()
    {
        yield return new WaitForSeconds(4.0f);

		SceneManager.LoadScene("Game3");
    }
}