using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixRotation : MonoBehaviour
{
    public GameObject enemy;
   
    void LateUpdate()
    {
        transform.position = enemy.transform.position;
    }
}
