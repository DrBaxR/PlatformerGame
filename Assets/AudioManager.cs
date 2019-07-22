using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    AudioSource myAudio;

    void Start()
    {
        myAudio =  GetComponent<AudioSource>();
        myAudio.PlayDelayed(3.0f);
    }
}
