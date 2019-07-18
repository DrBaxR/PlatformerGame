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
    public Slider manaSlider;
    public Image[] buff;
    public Sprite speedSprite;
    public Sprite attackSprite;
    public Text healthText;
    public Text manaText;
    public Text scoreText;

    public int score = 0;
    
    private void Update()
    {
        
        if(player.isDead)
        {   
            SceneManager.LoadScene("Game Over");
            gameOver = true;
        }
        UpdateUI();
    }

    void UpdateUI()
    {
        healthSlider.value = player.getHealthRatio();
        healthText.text = player.health + "/" + player.maxHealth;
        manaSlider.value = player.getManaRatio();
        manaText.text = player.mana + "/" + player.maxMana;
        scoreText.text = "Score: " + score;
    }

    public IEnumerator AddBuff(float duration, Sprite buffSprite)
    {
        int i;
        for (i = 0; i < buff.Length; ++i)
        {
            if (buff[i].enabled == false)
                break;
        }

        if (i < buff.Length)
        {
            buff[i].sprite = buffSprite;
            buff[i].enabled = true;
            yield return new WaitForSeconds(duration);
            buff[i].enabled = false;
        }
    }
}
