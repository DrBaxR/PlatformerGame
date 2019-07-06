using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePlayer : MonoBehaviour
{
    private PlayerController pc;

    private void Update()
    {
        transform.Translate(Vector2.left * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            pc = collision.GetComponent<PlayerController>();
            pc.Death();
        }
    }

}
