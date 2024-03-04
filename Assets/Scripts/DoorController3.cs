using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorController3 : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D Door3)
	{
		if (Door3.gameObject.CompareTag("Player01"))
		{
			SceneManager.LoadScene("Game4");
		}
	}
}