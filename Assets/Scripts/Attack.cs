using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public Animator playerAnimator;

    private void Update()
    {
        if(Input.GetMouseButtonDown(0) && playerAnimator.GetBool("isJumping"))
        {
            playerAnimator.SetTrigger("attack");
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.tag == "Enemy" && Input.GetMouseButtonDown(0) && playerAnimator.GetBool("isJumping"))
        {
            Damageable enemy = collision.GetComponent<Damageable>();
            enemy.health -= transform.GetComponentInParent<PlayerController>().attackDamage;
        }
    }
}
