using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    public float speed;
    public GameObject effect;

    void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            Instantiate(effect, transform.position, Quaternion.identity);

            collision.GetComponent<PlayerController>().takeDamage();
            Destroy(gameObject);
        }

        if(collision.tag == "Destroyer")
        {
            Destroy(gameObject);
        }
    }
}
