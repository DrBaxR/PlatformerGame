using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FallCollider : MonoBehaviour
{
    public Text livesText;
    public PlayerController player;
    public Transform levelStart;
    private void OnTriggerEnter2D(Collider2D collision)
    {

        player.SetTransform(levelStart);
        player.lives--;
        Debug.Log(player.lives);
         
    }

    private void Update()
    {
        livesText.text = "Lives: " + player.lives;
        if (player.lives == 0)
            SceneManager.LoadScene("Game Over");
    }

}
