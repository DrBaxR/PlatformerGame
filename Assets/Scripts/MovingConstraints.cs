﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingConstraints : MonoBehaviour
{
    public Transform target;
    [SerializeField] float maxValue = 1.0f;
    
    void Update()
    {
        transform.position = new Vector3(target.position.x, transform.position.y,-10);
        if(target.position.y > maxValue)
        {
            transform.position = new Vector3(target.position.x, target.position.y,-10);
        }
    }
}
