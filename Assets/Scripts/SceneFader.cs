using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneFader : MonoBehaviour
{
    public Animator fadeAnim;

    private string levelToLoad;
    
    public void FadeScene(string name)
    {
        if(name=="MainMenu")
        {
            PlayerPrefs.SetInt("score",0);
        }
        levelToLoad = name;
        fadeAnim.SetTrigger("fadeOut");
    }

    public void OnFadeComplete()
    {
        SceneManager.LoadScene(levelToLoad);
    }
}
