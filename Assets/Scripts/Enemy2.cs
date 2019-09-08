using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2 : MonoBehaviour
{
    [SerializeField] GameObject bullet;

    public float speed;
    public float stoppingDistance;
    public float retreatDistance;
    public float distance;
    public float jumpForce;
    public float fleeDistance;

    public Transform groundDetectionRight;
    public Transform groundDetectionLeft;

    public float startTimeBtwShots;

    private bool movingRight = true;
    private bool hasMoved = false;
    private float timeBtwShots;
    private Transform player;
    private Rigidbody2D rb;
    private Vector2 initial;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb = GetComponent<Rigidbody2D>();
        timeBtwShots = startTimeBtwShots;
        initial = new Vector2(transform.position.x, transform.position.y);
    }

    // Update is called once per frame
    void Update()
    {
        EnemyMovement();
        Shooting();
        Raycasting();
    }

    private void Raycasting()
    {
        RaycastHit2D groundInfoRight = Physics2D.Raycast(groundDetectionRight.position, Vector2.down,distance);
        RaycastHit2D groundInfoLeft = Physics2D.Raycast(groundDetectionLeft.position, Vector2.down, distance);
        if (groundInfoRight.collider == false)
        {
            movingRight = false;
           

        }
         if(groundInfoLeft.collider == false)
        {
            movingRight = false;
            

        }
    }

    private void Shooting()
    {
        if (timeBtwShots <= 0 && Vector2.Distance(transform.position, player.transform.position) < 20)
        {
            Instantiate(bullet, transform.position, Quaternion.identity);
            timeBtwShots = startTimeBtwShots;
        }
        else
            timeBtwShots -= Time.deltaTime;
    }

    private void EnemyMovement()
    {
        if (Vector2.Distance(transform.position, player.position) > stoppingDistance && movingRight)
        {
            Vector2 dir = new Vector2(player.position.x, transform.position.y);
            transform.position = Vector2.MoveTowards(transform.position, dir, speed * Time.deltaTime);
            /*transform.position = new Vector2(transform.position.x, 0);
            transform.position = new Vector2(transform.position.x * speed,transform.position.y);*/
            hasMoved = true;

        }
        else if (Vector2.Distance(transform.position, player.position) < stoppingDistance && Vector2.Distance(transform.position, player.position) > retreatDistance && movingRight)
        {
            transform.position = this.transform.position;
            
        }
        else if (Vector2.Distance(transform.position, player.position) < retreatDistance && movingRight)
        {
            Vector2 dir = new Vector2(player.position.x, transform.position.y);
            transform.position = Vector2.MoveTowards(transform.position, dir, -speed * Time.deltaTime);
            /* transform.position = new Vector2(transform.position.x, 0);
            transform.position = new Vector2(-(transform.position.x*speed), transform.position.y);*/
            hasMoved = true;
        }
        if(movingRight == false)
        {
            transform.position = Vector2.MoveTowards(transform.position, initial, speed * Time.deltaTime);
            movingRight = true;
        }

        if(Vector2.Distance(transform.position, player.position) > fleeDistance )
        {
            transform.position = Vector2.MoveTowards(transform.position, initial, -speed * Time.deltaTime);
            hasMoved = false;
        }
    }

    /*private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player" && movingRight==false)
        {
            Vector2 direction = new Vector2(1, 1);
            rb.AddForce(Vector2.up * jumpForce);
            
            
        }
    }*/
    
}
