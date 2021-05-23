using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedBooster : MonoBehaviour
{
    public float speedMultiplier;
    public float duration;
    public Sprite speedSprite;
    private AudioManager audio;

    private void Start()
    {
        audio = GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            audio.PlaySound("speedPickup");
            PlayerController player = collision.GetComponent<PlayerController>();
            player.BuffSpeed(speedMultiplier, duration, speedSprite);
           
            Destroy(gameObject);
        }
    }
}
