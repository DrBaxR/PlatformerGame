using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedBooster : MonoBehaviour
{
    public float speedMultiplier;
    public float duration;
    public Sprite speedSprite;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            PlayerController player = collision.GetComponent<PlayerController>();
            player.BuffSpeed(speedMultiplier, duration, speedSprite);
           
            Destroy(gameObject);
        }
    }
}
