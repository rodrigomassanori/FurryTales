using UnityEngine;
using UnityEngine.UI;

public class PauseManager : MonoBehaviour 
{
    public Button PauseBtn;

    bool IsPaused;

    readonly KeyCode Q = KeyCode.Q;

    void Update()
    {
        if (Input.GetKeyDown(Q))
        {
            TogglePause();
        }
    }

    public bool TogglePause()
    {
        IsPaused = !IsPaused;

        if (IsPaused)
        {
            PauseGame();
        }

        else
        {
            ResumeGame();
        }
        
        return IsPaused;
    }

    void PauseGame()
    {
        Time.timeScale = 0.0f;

        PauseBtn.enabled = true;

        PauseBtn.gameObject.SetActive(true);
    }

    void ResumeGame()
    {
        Time.timeScale = 1.0f;

        PauseBtn.enabled = false;

        PauseBtn.gameObject.SetActive(false);
    }
}