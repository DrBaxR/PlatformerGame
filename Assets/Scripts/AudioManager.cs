using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioClip coinPickup;    
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
    }
}
