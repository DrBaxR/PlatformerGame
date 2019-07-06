﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController1 : MonoBehaviour
{
    public float speed;
    public float distance;
    public int damageAmount;
    public float damageCooldown;

    private float offset;
    private float nextDamage;

    
    private Rigidbody2D rb;
    private bool movingRight = true;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        nextDamage = Time.time;
    }

    private void Update()
    {
        rb.velocity = transform.right * speed * Time.deltaTime;
        ChangeDirection();
    }

    private void ChangeDirection()
    {
        Transform groundDetect = gameObject.transform.GetChild(0);

        RaycastHit2D groundInfo = Physics2D.Raycast(groundDetect.transform.position, Vector2.down, distance);
        if (groundInfo.collider == false)
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
        
        if(collision.gameObject.tag == "Player" && Time.time >= nextDamage )
        {
            PlayerController player;
            player = collision.gameObject.GetComponent<PlayerController>();
            player.TakeDamage(damageAmount);
            nextDamage = Time.time + damageCooldown;
        }
    }
}
