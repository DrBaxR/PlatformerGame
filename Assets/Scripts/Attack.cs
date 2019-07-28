using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    private PlayerController player;

    private void Start()
    {
        player = transform.parent.GetComponent<PlayerController>();
    }

    private void Update()
    {
        if(Input.GetMouseButtonDown(0) && player.playerAnimator.GetBool("isJumping"))
        {
            player.playerAnimator.SetTrigger("attack");
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.tag == "Enemy" && Input.GetMouseButtonDown(0) && player.playerAnimator.GetBool("isJumping"))
        {
            Damageable enemy = collision.GetComponent<Damageable>();
            enemy.health -= transform.GetComponentInParent<PlayerController>().attackDamage;
        }
    }
}
