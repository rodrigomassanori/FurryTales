using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameIntro : MonoBehaviour 
{
	void Start () 
	{
		StartCoroutine(IntroScreen());
	}

	IEnumerator IntroScreen()
	{
		yield return new WaitForSeconds(40.0f);

		SceneManager.LoadScene("Game");
	}
}