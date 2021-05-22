using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManaPickup : MonoBehaviour
{
    public float manaAmount = 25.0f;
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
            if (player.mana < player.maxMana)
            {
                audioPlay.PlaySound("manaPickup");
                player.mana = Mathf.Clamp(player.mana + manaAmount, 0, player.maxMana);
                Destroy(gameObject);
            }
        }
    }
}
