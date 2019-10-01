using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioClip coinPickup;
    public AudioClip playerHit;
    public AudioClip enemyHitEffect1;
    public AudioClip enemyHitEffect2;

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
            float randomHitEffect = Random.Range(0f, 1f);
            if(randomHitEffect <=0.5f)
            {
                myAudio.PlayOneShot(enemyHitEffect1);
            }
            else
            {
                myAudio.PlayOneShot(enemyHitEffect2);
            }
        }
    }
}
