using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : MonoBehaviour
{
    public int heal;
    private AudioManager audioPlay;

    void Start()
    {
         audioPlay = GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>();
    
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            PlayerController player = collision.GetComponent<PlayerController>();
            if (player.health < player.maxHealth)
            // {
            {
                audioPlay.PlaySound("healthPickup");
                player.health = Mathf.Clamp(player.health + heal, 0, player.maxHealth);
                Destroy(gameObject);
            }
           // }
        }
    }
}
