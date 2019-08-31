using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseButton : MonoBehaviour
{
    public PauseController pc;

    public void ResumeGame()
    {
        pc.Resume();
    }

    public void LoadScene(string level)
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(level);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
