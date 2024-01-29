using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class ChernobylVideo : MonoBehaviour 
{
	VideoPlayer VDPlayer;

	void Awake()
	{
		VDPlayer = GetComponent<VideoPlayer>();
	}

	void Start()
	{
		if (VDPlayer != null && VDPlayer.clip != null)
		{
			VDPlayer.Play();

			StartCoroutine(GameIntro());
		}

		else
		{
			print("VideoPlayer component or VideoClip not set!");
		}
	}

	IEnumerator GameIntro()
	{
		yield return new WaitForSeconds(150.0f);

		SceneManager.LoadScene("GameIntro");
	}
}