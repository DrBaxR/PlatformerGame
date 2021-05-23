using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyController1 : Enemy
{

    public float distance;
    public float pushPower;
    private float nextDamage;
    public GameObject[] dropItems;
    
    public GameObject healthBar;
    public Sprite bleedingSprite;
    public float dropRate = 3f;
    public Transform front;

    private Vector3 localScale;

    //private GameManager gm;
    private Rigidbody2D rb;
    private float maxHealth;
    private float actualHealth;
    private bool movingRight = true;
   

   

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        nextDamage = Time.time;
        maxHealth = health;
     //   gm = GameObject.FindGameObjectWithTag("GameManager").GetComponent<Ga>
        localScale = healthBar.transform.localScale;
    }

    private void Update()
    {
        rb.velocity = transform.right * speed * Time.deltaTime + new Vector3(0, rb.velocity.y, 0);
        localScale.x = (float)health/maxHealth;
        healthBar.transform.localScale = localScale;
        healthBar.transform.localRotation = Quaternion.identity;
        ChangeDirection();
        CheckforDeath();
        if (health <= 0)
        {
            GameManager.IncrementScore(10);
            DropItem();
        }

    }

  

    private void ChangeDirection()
    {
        Transform groundDetect = gameObject.transform.GetChild(0);

        RaycastHit2D groundInfo = Physics2D.Raycast(groundDetect.transform.position, Vector2.down, distance);

        if (groundInfo.collider == null || Physics2D.OverlapPoint(front.position))
        {
            if (movingRight == true)
            {
                movingRight = false;
                transform.eulerAngles = new Vector3(0, -180, 0);
               
            }
            else
            {
                movingRight = true;
                transform.eulerAngles = new Vector3(0, 0, 0);
                
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "Player" && Time.time >= nextDamage)
        {

            PlayerController player;
            player = collision.gameObject.GetComponent<PlayerController>();
            player.TakeDamage(damageAmount);
            player.DamageOverTime(damageAmount/5,5);
            player.DebuffBleed(5, bleedingSprite);
            nextDamage = Time.time + damageCooldown;


            Vector2 pushForce = player.transform.position - transform.position + Vector3.up;
            pushForce.Normalize();
            player.push(pushForce * pushPower * 100);
        }
    }

    public void DropItem()
    {
        //if (Random.Range(2f, 4f) <= dropRate)
        
            int indexToDrop = Random.Range(0, dropItems.Length);

            Instantiate(dropItems[indexToDrop], transform.position, transform.rotation);
    }
}
