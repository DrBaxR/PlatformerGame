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
    public Image[] buff;
    public Sprite speedSprite;
    public Sprite attackSprite;

    private float[] disableTimes;
    //private int buffIndex = 0;


    private void Start()
    {
        disableTimes = new float[3];
        for (int i = 0; i < 3; ++i)
        {
            disableTimes[i] = 0.0f;
        }
    }
    private void Update()
    {
        
        if(player.isDead)
        {   
            SceneManager.LoadScene("Game Over");
            gameOver = true;
        }
        UpdateSlider();
        UpdateBuffUI();
    }

    void UpdateBuffUI()
    {
        for(int i = 0; i < 3; ++i)
        {
            if(disableTimes[i] <= Time.time)
            {
                
                
                buff[i].enabled = false;
                disableTimes[i] = 0.0f;
                
            }
        }
    }

    void UpdateSlider()
    {
        healthSlider.value = player.getHealthRatio();
    }

    public void EnableBuff(float duration)
    {
        int i;
        if (player.isSpeedBuffed)
        {
            for (i = 0; i < buff.Length; i++)
            {
                if (buff[i].enabled == false)
                {
                    break;
                }
            }
            if (i < buff.Length)
            {
                buff[i].sprite = speedSprite;
                buff[i].enabled = true;
                disableTimes[i] = Time.time + duration;

            }
        }
        if (player.isAttackBuffed)
        {
            for (i = 0; i < buff.Length; i++)
            {
                if (buff[i].enabled == false)
                {
                    break;
                }
            }
            if (i < buff.Length)
            {
                buff[i].sprite = attackSprite;
                buff[i].enabled = true;
                disableTimes[i] = Time.time + duration;
            }

        }

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
            disableTimes[i] = Time.time + duration;
            yield return new WaitForSeconds(duration);
            buff[i].enabled = false;
        }
    }
}
