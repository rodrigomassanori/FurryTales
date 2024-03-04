using UnityEngine.SceneManagement;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SceneController : MonoBehaviour 
{
	public Image KaitlynDeath;

	void Start()
	{
		Instantiate(KaitlynDeath);
		
		StartCoroutine(Respawn());
	}

    IEnumerator Respawn()
    {
        yield return new WaitForSeconds(4.0f);

		SceneManager.LoadScene("Game3");
    }
}