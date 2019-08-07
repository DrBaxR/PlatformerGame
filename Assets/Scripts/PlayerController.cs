using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //public variables
    public float speed;
    public float jumpHeight;
    public float gravMult;
    public int numberOfJumps;
    public int maxHealth;
    public float sprintSpeed;
    public float teleportCooldown;
    public float attackDamage;
    public int numberJumps;

    public float maxMana;
    public float manaCost;
    public float manaRegen;
    public float manaRegenCooldown;
    public Transform groundCheck;
    public Transform underPlayer;
    public LayerMask whatIsGround;
    public Vector2 checkpoint;
    public Animator playerAnimator;

    //hidden in the inspector
    [HideInInspector]
    public int health;
    [HideInInspector]
    public float mana;
    [HideInInspector]
    public bool isDead;
    [HideInInspector]
    public bool isSpeedBuffed;
    [HideInInspector]
    public bool isBuffed;
    [HideInInspector]
    public bool isAttackBuffed;
    [HideInInspector]
    public float groundCheckRadius = 0.1f;
    [HideInInspector]
    public float maxDamage;
    [HideInInspector]
    public GameManager gm;

    //private varaibles
    private float nextManaRegen;
    private bool grounded;
    private bool movesRight;
    private float speedRunOut;
    private float damageRunOut;
    private float initDamage;
    private float initSpeed;
    private float initSprintSpeed;
    private float nextTeleport;
    private float initMaxHealth;
    private Rigidbody2D rb;

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
        maxDamage = attackDamage;
        isAttackBuffed = false;
        initSprintSpeed = sprintSpeed;
        mana = maxMana;
        nextManaRegen = 0;
        //playerAnimator = GetComponent<Animator>();

        gm = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
        gm.Initialize();
    }

    private void Update()
    {
        
        PlayerMovement();
        Jump();
        BuffRunOut();
        Teleport();
        MoveCheckpoint();
        CheckDeath();
        //RestoreMana(); //maybe not
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

            if (playerAnimator.GetBool("isJumping") == false)
                playerAnimator.SetBool("isRunning", true);
            else
                playerAnimator.SetBool("isRunning", false);
        }
        else if (Input.GetKey(KeyCode.D))
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

            if(playerAnimator.GetBool("isJumping") == false)
                playerAnimator.SetBool("isRunning", true);
            else
                playerAnimator.SetBool("isRunning", false);
        }
        else
        {
            playerAnimator.SetBool("isRunning", false);
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
            attackDamage = maxDamage;
            isAttackBuffed = false;
            isBuffed = false;
        }
    }

    private void Jump()
    {
        bool ableJump;

        grounded = Physics2D.OverlapCircle(new Vector2(underPlayer.position.x, underPlayer.position.y), groundCheckRadius, whatIsGround);

        if (grounded == true)
        {
            playerAnimator.SetBool("isJumping", false);
            numberJumps = 0;
        }
        else
        {
            playerAnimator.SetBool("isJumping", true);
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
            playerAnimator.SetBool("isJumping", true);
            playerAnimator.SetBool("isRunning", false);
            playerAnimator.SetTrigger("doubleJump");
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
    public float getManaRatio()
    {
        return (float)mana / maxMana;
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
        if (Input.GetMouseButtonDown(1) && Time.time > nextTeleport && mana >= manaCost)
        {
            Vector2 teleportDirection = Camera.main.ScreenToWorldPoint(new Vector2(Input.mousePosition.x, Input.mousePosition.y));
            
            if (!Physics2D.OverlapPoint(teleportDirection, whatIsGround))
            {
                transform.position = teleportDirection;
                mana -= manaCost;
                nextTeleport = Time.time + teleportCooldown;
            }
        }
    }

    public void RestoreMana()
    {
        if(mana < maxMana && Time.time > nextManaRegen)
        {
            mana += manaRegen;
            nextManaRegen = Time.time + manaRegenCooldown;
        }
        mana = Mathf.Clamp(mana, 0, maxMana); 
    }

    private void MoveCheckpoint()
    {
        Collider2D coll = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);
        if (coll != null) 
        {
            if(coll.tag != "MovingPlatform")
                checkpoint = transform.position;
        }
    }

    public void FallDamage(int damage)
    {
        health -= damage;
        transform.position = checkpoint;
    }

    private void CheckDeath()
    {
        isDead = (health <= 0);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.tag == "MovingPlatform")
        {
            transform.parent = collision.transform;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.transform.tag == "MovingPlatform")
        {
            transform.parent = null;
        }
    }
}