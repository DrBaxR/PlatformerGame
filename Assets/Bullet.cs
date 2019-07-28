using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public float moveSpeed;

    private Rigidbody2D rb;

    private Transform player;


    private Vector2 target;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        target = new Vector2(player.position.x, player.position.y);
    }

    private void Update()
    {

        transform.position = Vector2.MoveTowards(transform.position, target, moveSpeed * Time.deltaTime);
        if (transform.position.x == target.x && transform.position.y == target.y)
            DestroyProjectile();

    }
    void DestroyProjectile()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            DestroyProjectile();
        }
    }
}
