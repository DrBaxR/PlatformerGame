using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public float timeBetweenSpawn;
    public GameObject[] entities;
    public float timeDecrease;
    public float timeThreshold;

    float nextSpawn = 0.0f;

    private void Update()
    {
        if (nextSpawn < Time.time) 
        {
            int ind = Random.Range(0, entities.Length);

            nextSpawn = Time.time + timeBetweenSpawn;
            Instantiate(entities[ind], transform.position, Quaternion.identity);

            if(timeBetweenSpawn >= timeThreshold)
            {
                timeBetweenSpawn -= timeDecrease;
            }
        }
    }
}
