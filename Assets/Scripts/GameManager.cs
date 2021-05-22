using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/// <summary>
/// !!!EXTREMELY IMPORTANT!!!
/// 
/// There must exist an instance of the game manager game object at all times when a level is played
/// Recommendation: create an instance of it in the main menu
/// </summary>

public class GameManager : MonoBehaviour
{ 
    public bool gameOver = false;
    public static int score;

    [HideInInspector] public PlayerController player;
    [HideInInspector] public Slider healthSlider;
    [HideInInspector] public Slider manaSlider;
     public Image[] buff;
    [HideInInspector] public Text healthText;
    [HideInInspector] public Text manaText;
    [HideInInspector] public Text scoreText;
    [HideInInspector] public Text healthStat;
    [HideInInspector] public Text attackDamageStat;

    private bool isLevel;

    private void Awake()
    {
        PlayerPrefs.SetInt("score", 0);
    }

    private void Start()
    {
        Initialize();
        //PlayerPrefs.SetInt("score", 0);
        
    }

    private void Update()
    {
        if(SceneManager.GetActiveScene().name == "MainMenu")
        {
           PlayerPrefs.SetInt("score", 0);
        }
        if (isLevel)
        {
            if (player.isDead)
            {
                //do the "game over stuff"
                SceneManager.LoadScene("Game Over");
                gameOver = true;
            }
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
            UpdateUI();
        }
        
    }

    void UpdateUI()
    {
        healthSlider.value = player.getHealthRatio();
        healthText.text = player.health + "/" + player.maxHealth;
        manaSlider.value = player.getManaRatio();
        manaText.text = player.mana + "/" + player.maxMana;
        scoreText.text = "Score: " + score;
        healthStat.text = "Stamina: " + player.maxHealth;
        attackDamageStat.text = "Attack power: " + player.attackDamage;
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

    public void Initialize()
    {
        if (GameObject.FindGameObjectWithTag("Player"))
        {

            //initializes all the objects
            //player
            player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();

            //UI
            //!!!ORDER IN HIERARCHY IS IMPORTANT AS FUCK!!!
            GameObject ui = GameObject.FindGameObjectWithTag("UI").transform.GetChild(1).gameObject; //canvas = 1 in UI
            healthSlider = ui.transform.GetChild(0).GetComponent<Slider>();                          //health slider = 0 in canvas
            manaSlider = ui.transform.GetChild(1).GetComponent<Slider>();                            //mana slider = 1 in canvas
            healthText = ui.transform.GetChild(2).GetComponent<Text>();                              //health text = 2 in canvas
            manaText = ui.transform.GetChild(3).GetComponent<Text>();                                //mana text = 3 in canvas
            scoreText = ui.transform.GetChild(4).GetComponent<Text>();                               //score text = 4 in canvas
            GameObject icons = ui.transform.GetChild(5).gameObject;                                  //buffs = 5 in canvas
            buff[0] = icons.transform.GetChild(0).GetComponent<Image>();
            buff[1] = icons.transform.GetChild(1).GetComponent<Image>();
            buff[2] = icons.transform.GetChild(2).GetComponent<Image>();
            healthStat = ui.transform.GetChild(6).GetComponent<Text>();                              //health stat = 6 in canvas
            attackDamageStat = ui.transform.GetChild(7).GetComponent<Text>();                        //attack damage stat = 7 in canvas
            
            isLevel = true;
        }
        else
        {
            isLevel = false;
        }
    }

    public static void IncrementScore(int val)
    {
        score = PlayerPrefs.GetInt("score");
        score += val;
        PlayerPrefs.SetInt("score", score);
    }
}
