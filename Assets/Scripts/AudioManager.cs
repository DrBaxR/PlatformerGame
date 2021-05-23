using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioClip coinPickup;
    public AudioClip playerHit;
    public AudioClip enemyHitEffect1;
    public AudioClip enemyHitEffect2;

    public AudioClip manaPickup;
    public AudioClip healthPickup;
    public AudioClip speedPickup;
    public AudioClip attackPickup;


    AudioSource myAudio;

    void Start()
    {
        myAudio =  GetComponent<AudioSource>();
        myAudio.PlayDelayed(3.0f);
    }

    public void PlaySound(string clip)
    {
        if(clip == "coinPickup")
        {
            myAudio.PlayOneShot(coinPickup);
        }

        if(clip == "playerHit")
        {
            myAudio.PlayOneShot(playerHit);
        }
        if(clip == "enemyHit")
        {
            myAudio.PlayOneShot(enemyHitEffect1);
        }
        if (clip == "manaPickup")
        {
            myAudio.PlayOneShot(manaPickup);
        }
         if (clip == "healthPickup")
        {
            myAudio.PlayOneShot(healthPickup);
        }
        if (clip == "speedPickup")
        {
            myAudio.PlayOneShot(speedPickup);
        }
        if (clip == "attackPickup")
        {
            myAudio.PlayOneShot(attackPickup);
        }
    }
}
