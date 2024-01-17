using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorController : MonoBehaviour
{
    public GameObject Pl;

    void Start()
    {
        if(Pl.gameObject.tag == "Player")
        {
            SceneManager.LoadScene("Game2");
        }
    }
}