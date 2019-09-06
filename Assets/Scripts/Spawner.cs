using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public float cooldown = 5.0f;
    public GameObject toSpawn;

    private float nextSpawn = 0.0f;

    void Update()
    {
        if (Time.time >= nextSpawn && !Physics2D.OverlapCircle(transform.position, 0.5f))
        { 
            Instantiate(toSpawn, transform.position, Quaternion.identity);
            nextSpawn = Time.time + cooldown;
        }
    }
}
