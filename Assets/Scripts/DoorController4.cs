using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorController4 : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D Door4)
	{
		if (Door4.gameObject.CompareTag("Player"))
		{
			SceneManager.LoadScene("Game5");
		}
	}
}