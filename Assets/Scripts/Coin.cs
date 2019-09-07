﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public int collectibleValue;
    
   //public AudioManager audioPlay;

   

    private void OnTriggerEnter2D(Collider2D collision)
    {
       
        if(collision.tag == "Player")
        {
            // audioClip.clip = pickup;
            //audioPlay.PlaySound("coinPickup");
            //AudioSource.PlayClipAtPoint(pickup, transform.position);
            GameManager.IncrementScore(collectibleValue);
            Destroy(gameObject);
            
        }
       
    }
}
