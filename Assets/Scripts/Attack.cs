using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public Animator playerAnimator;
    
    private AudioSource audioSource;
    private AudioManager audioPlay;


    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioPlay = GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>();
    }
    private void Update()
    {
        if(Input.GetMouseButtonDown(0) && playerAnimator.GetBool("isJumping"))
        {
            playerAnimator.SetTrigger("attack");
            audioSource.Play();
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.tag == "Enemy" && Input.GetMouseButtonDown(0) && playerAnimator.GetBool("isJumping"))
        {
            
            Damageable enemy = collision.GetComponent<Damageable>();
            enemy.health -= transform.GetComponentInParent<PlayerController>().attackDamage;
            audioPlay.PlaySound("enemyHit");
        }
    }
}
