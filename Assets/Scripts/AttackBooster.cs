using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class AttackBooster : MonoBehaviour
{
    public float attackmult;
    public float duration;
    public Sprite attackSprite;
    public Text text;
    public GameObject tooltip;
   

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

