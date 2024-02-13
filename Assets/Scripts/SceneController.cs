using UnityEngine.SceneManagement;
using UnityEngine;

public class SceneController : MonoBehaviour 
{
	Scene Sc;

	public GameObject Player;

	void Awake()
	{
		Instantiate(Player);
	}
}