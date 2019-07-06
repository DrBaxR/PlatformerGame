using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public bool gameOver = false;
    public PlayerController player;
    public Slider healthSlider;

    private void Update()
    {
        if(player.isDead)
        {
            SceneManager.LoadScene("Game Over");
            gameOver = true; 
        }
        UpdateSlider();
    }

    void UpdateSlider()
    {
        healthSlider.value = player.getHealthRatio();
    }
}
