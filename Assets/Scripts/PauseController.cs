using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseController : MonoBehaviour
{
    public static bool gamePaused;
    public GameObject pauseUI;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.X))
        {
            if(gamePaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    void Pause()
    {
        Time.timeScale = 0.0f;
        pauseUI.SetActive(true);
        gamePaused = true;
    }

    public void Resume()
    {
        Time.timeScale = 1.0f;
        pauseUI.SetActive(false);
        gamePaused = false;
    }
}
