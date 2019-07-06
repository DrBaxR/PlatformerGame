using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float jumpHeight;
    public float gravMult;
    public int numberOfJumps;
    public int health;
    public bool isDead;

    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask whatIsGround;

    private int numberJumps;
    private bool grounded;
    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        numberJumps = 0;
        health = 100;
    }

    private void FixedUpdate()
    {
        PlayerMovement();
        jump();
    }

    private void PlayerMovement()
    {
        if (Input.GetKey(KeyCode.A))
        {
            rb.velocity += Vector2.left * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D))
        {
            rb.velocity += Vector2.right * speed * Time.deltaTime;
        }
    }

    private void jump()
    {
        bool ableJump;

        grounded = Physics2D.OverlapCircle(new Vector2(groundCheck.position.x, groundCheck.position.y), groundCheckRadius, whatIsGround);

        if (grounded == true)
        {
            numberJumps = 0;
        }

        if (numberJumps <= numberOfJumps - 1)
        {
            ableJump = true;
        }
        else
        {
            ableJump = false;
        }

        if (ableJump && Input.GetKeyDown(KeyCode.Space))
        {
            numberJumps++;

            rb.velocity =  new Vector2(rb.velocity.x, jumpHeight);
        }

        if(rb.velocity.y < 0)
        {
            rb.velocity += new Vector2(0, Physics2D.gravity.y * gravMult * Time.deltaTime);
        }
        
    }

    public void SetTransform(Transform target)
    {
        transform.position = target.position;
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
            isDead = true;
    }

    public void Kill()
    {
        isDead = true;
    }
}
