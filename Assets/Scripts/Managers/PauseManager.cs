using System;
using UnityEngine;

public class PauseManager : MonoBehaviour 
{
    public GameObject PauseBtn;

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

        PauseBtn.SetActive(true);
    }

    void ResumeGame()
    {
        Time.timeScale = 1.0f;

        PauseBtn.SetActive(false);
    }
}