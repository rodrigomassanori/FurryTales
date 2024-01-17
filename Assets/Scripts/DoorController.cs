using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorController : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D Pl)
    {
        if(Pl.gameObject.tag == "Player")
        {
            SceneManager.LoadScene("Game2");
        }
    }
}