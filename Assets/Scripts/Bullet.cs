using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public float moveSpeed;
    public int damage;

    [SerializeField] 
    public float knockbackStrength;

    [SerializeField] GameObject bulletParticleVFX;

    private Rigidbody2D rb;

    private Transform player;
    private GameObject playerHealth;


    private Vector2 target;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        
        target = new Vector2(player.position.x, player.position.y);
    }

    private void Update()
    {
        //target = new Vector2(player.position.x, player.position.y);
        transform.position = Vector2.MoveTowards(transform.position, target, moveSpeed * Time.deltaTime);
        if (transform.position.x == target.x && transform.position.y == target.y)
            DestroyProjectile();

    }
    void DestroyProjectile()
    {
        TriggerParticleVFX();
        Destroy(gameObject);
    }

    /*private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            
        }
    }*/
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Rigidbody2D rb = collision.gameObject.GetComponent<Rigidbody2D>();
            PlayerController playerHealth = collision.gameObject.GetComponent<PlayerController>();
            Vector2 direction = (transform.position - collision.transform.position+Vector3.up).normalized;
            rb.AddForce(-direction*knockbackStrength,ForceMode2D.Impulse);
            playerHealth.TakeDamage(damage);
            DestroyProjectile();
            
        }
    }
    private void TriggerParticleVFX()
    {
         Instantiate(bulletParticleVFX, transform.position, Quaternion.identity);
    }
}
