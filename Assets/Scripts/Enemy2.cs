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
        //RotateTowards();
        var direction = player.position - transform.position;

        // Set Y the same to make the rotations turret-like:
        direction.y = transform.position.y;

        var rot = Quaternion.LookRotation(direction, Vector3.up);
        transform.rotation = Quaternion.RotateTowards(
                                         transform.rotation,
                                         rot,
                                         5 * Time.deltaTime);
   
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
    private void RotateTowards()
    {
        var offset = 90f;
        Vector2 direction = (Vector2)player.position - (Vector2)transform.position;
        direction.Normalize();
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(Vector3.forward * (angle + offset));
    }

    private void EnemyMovement()
    {
         if(player.position.x > transform.position.x) //if the target is to the right of enemy and the enemy is not facing right
            transform.eulerAngles = new Vector3(0, -180, 0);
        if (player.position.x < transform.position.x)
            transform.eulerAngles = new Vector3(0,0, 0);
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
        if (movingRight == false)
        {
            transform.position = Vector2.MoveTowards(transform.position, initial, speed * Time.deltaTime);
            movingRight = true;
        }

        if (Vector2.Distance(transform.position, player.position) > fleeDistance )
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
