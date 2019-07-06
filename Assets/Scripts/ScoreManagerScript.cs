using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManagerScript : MonoBehaviour
{
    public float score = 0;
    public Text scoreText;
    public PlayerController player;

    private void Update()
    {
        scoreText.text = "SCORE: " + score;
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Enemy" && player.isDead == false)
        {
            score++;
        }
    }
}
