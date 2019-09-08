using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    private Transform targetPosition;
    int damp = 5;   
    // Start is called before the first frame update
    void Start()
    {
        targetPosition = GameObject.FindGameObjectWithTag ("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if(targetPosition)

        {
            var rotationAngle = Quaternion.LookRotation(targetPosition.position - transform.position);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotationAngle, Time.deltaTime * damp); // we rotate the rotationAngle 
        }
    }
}
