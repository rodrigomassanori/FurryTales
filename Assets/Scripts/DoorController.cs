using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorController : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D Door)
    {
        if(Door.gameObject.tag == "Door")
        {
            SceneManager.LoadScene("Game2");
        }
    }
}