using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.tag == "Enemy" && Input.GetMouseButtonDown(0))
        {
            Damageable enemy = collision.GetComponent<Damageable>();
            enemy.health -= transform.GetComponentInParent<PlayerController>().attackDamage;
        }
    }
}
