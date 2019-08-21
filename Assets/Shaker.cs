using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shaker : MonoBehaviour
{
    private float shakeDuration = 0f;
    private float shakeMagnitude = 0.7f;
    private float dampingSpeed = 1.0f;
    Vector3 initialPosition;

    private void Start()
    {
        initialPosition = transform.localPosition;
    }
   

    // Update is called once per frame
    void Update()
    {
        if (shakeDuration > 0)
        {
            transform.localPosition = new Vector3(Random.Range(0f, 1f), Random.Range(0f, 1f), initialPosition.z);

            shakeDuration -= Time.deltaTime * dampingSpeed;
        }
        else
        {
            shakeDuration = 0f;
            transform.localPosition = initialPosition;
        }
      
    }
    public void TriggerShake()
    {
        shakeDuration = 1.0f;
    }
}
