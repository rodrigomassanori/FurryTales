using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorController2 : MonoBehaviour 
{
	void OnCollisionEnter2D(Collision2D Door2)
	{
		if (Door2.gameObject.CompareTag("Player"))
		{
			SceneManager.LoadScene("Game3");
		}
	}
}