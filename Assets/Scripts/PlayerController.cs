using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float jump;
    public float speed;
    public bool isDead = false;
    public GameObject effect;
    public Text healthText;
    public GameObject gameOverScreen;

    Vector2 targetPos;
    float maxHeight;
    float minHeight;
    private int health = 3;
    private Animator camAnim;

    private void Start()
    {
        targetPos = transform.position;
        maxHeight = jump;
        minHeight = -jump;

        camAnim = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Animator>();
    }

    void Update()
    {

        transform.position = Vector2.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.UpArrow) && transform.position.y < maxHeight) 
        {
            camAnim.SetTrigger("shake");
            Instantiate(effect, transform.position, Quaternion.identity);
            targetPos = new Vector2(transform.position.x, transform.position.y + jump);
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow) && transform.position.y > minHeight)
        {
            camAnim.SetTrigger("shake");
            Instantiate(effect, transform.position, Quaternion.identity);
            targetPos = new Vector2(transform.position.x, transform.position.y - jump);
        }

        healthText.text = "HP: " + health;
        checkDeath();
    }

    public void takeDamage()
    {
        camAnim.SetTrigger("shake");
        health--;
        if(health == 0)
        {
            isDead = true;
        }
    }

    void checkDeath()
    {
        if (health <= 0)
        {
            gameOverScreen.SetActive(true);
            Destroy(gameObject);
        }
    }
}
