using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackBooster : MonoBehaviour
{
    public float attackmult;
    public float duration;
    public Sprite attackSprite;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if(collision.tag == "Player")
        {
            PlayerController player = collision.GetComponent<PlayerController>();
            player.BuffAttack(attackmult, duration,attackSprite);
            Destroy(gameObject);

            
        }
    }
}
