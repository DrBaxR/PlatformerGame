using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float jumpHeight;
    public float gravMult;
    public int numberOfJumps;
    public float maxHealth;
    public bool isDead;
    public bool isSpeedBuffed;
    public GameManager gm;
    public bool isBuffed;
    public float attackDamage;
    public bool isAttackBuffed;
    public float sprintSpeed;
    public float teleportCooldown;


    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask whatIsGround;

    private int numberJumps;
    private bool grounded;
    private Rigidbody2D rb;
    private float health;
    private bool movesRight;
    private float speedRunOut;
    private float damageRunOut;
    private float healthRunOut;
    private float initDamage;
    private float initSpeed;
    private float initSprintSpeed;
    private float nextTeleport;
    private float initMaxHealth;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        numberJumps = 0;
        initSpeed = speed;
        health = maxHealth;
        initMaxHealth = maxHealth;
        speedRunOut = 0.0f;
        isSpeedBuffed = false;
        isBuffed = false;
        initDamage = attackDamage;
        isAttackBuffed = false;
        initSprintSpeed = sprintSpeed;
    }

    private void Update()
    {
        PlayerMovement();
        Jump();
        BuffRunOut();
        Teleport();
    }

    private void PlayerMovement()
    {
        if (Input.GetKey(KeyCode.A))
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                rb.velocity += Vector2.left * sprintSpeed * Time.deltaTime;
                transform.eulerAngles = new Vector3(0, -180, 0);
            }
            else
            {
                rb.velocity += Vector2.left * speed * Time.deltaTime;
                transform.eulerAngles = new Vector3(0, -180, 0);
            }
        }
        if (Input.GetKey(KeyCode.D))
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                rb.velocity += Vector2.right * sprintSpeed * Time.deltaTime;
                transform.eulerAngles = new Vector3(0, 0, 0);
            }
            else
            {
                rb.velocity += Vector2.right * speed * Time.deltaTime;
                transform.eulerAngles = new Vector3(0, 0, 0);
            }

        }


    }

    private void BuffRunOut()
    {
        if (Time.time >= speedRunOut)
        {
            speed = initSpeed;
            sprintSpeed = initSprintSpeed;
            isSpeedBuffed = false;
            isBuffed = false;
        }
        if (Time.time >= damageRunOut)
        {
            attackDamage = initDamage;
            isAttackBuffed = false;
            isBuffed = false;
        }
    }

    private void Jump()
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

            rb.velocity = new Vector2(rb.velocity.x, jumpHeight);
        }

        if (rb.velocity.y < 0)
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

    public float getHealthRatio()
    {
        return (float)health / maxHealth;
    }

    public void push(Vector2 force)
    {
        rb.AddForce(force);
    }

    public void BuffSpeed(float mult, float duration, Sprite speedSprite)
    {
        speedRunOut = Time.time + duration;
        speed *= mult;
        sprintSpeed *= mult;
        isSpeedBuffed = true;
        isBuffed = true;
        StartCoroutine(gm.AddBuff(duration, speedSprite));
    }

    public void BuffAttack(float mult, float duration, Sprite attackSprite)
    {
        damageRunOut = Time.time + duration;
        attackDamage *= mult;
        isAttackBuffed = true;
        isBuffed = true;
        StartCoroutine(gm.AddBuff(duration, attackSprite));
    }

    public void Teleport()
    {
        Camera cam = Camera.main;
        float height = 2f * cam.orthographicSize;
        float width = height * cam.aspect;
        
        
        if (Input.GetMouseButtonDown(1) && Time.time > nextTeleport)
        {
            Vector2 teleportDirection = cam.ScreenToWorldPoint(new Vector2(Input.mousePosition.x, Input.mousePosition.y));
            transform.position = teleportDirection;
            nextTeleport = Time.time + teleportCooldown;

        }
    }

}