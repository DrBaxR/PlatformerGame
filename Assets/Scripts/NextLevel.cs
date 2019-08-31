using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    public string nextLevel;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            SceneFader fader = GameObject.FindObjectOfType<SceneFader>();
            PlayerPrefs.SetInt("score", GameManager.score);
            fader.FadeScene(nextLevel);
        }
    }
}
