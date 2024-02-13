using UnityEngine.SceneManagement;
using UnityEngine;

public class SceneController : MonoBehaviour 
{
	Scene Sc;

	void Awake()
	{
		Sc = SceneManager.CreateScene("GameOver");

		print(Sc);
	}
}