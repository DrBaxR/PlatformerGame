using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackBooster : MonoBehaviour
{
    public float attackmult;
    public float duration;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if(collision.tag == "Player")
        {
            PlayerController player = collision.GetComponent<PlayerController>();
            player.BuffAttack(attackmult, duration);
            Destroy(gameObject);

            
        }
    }
}
