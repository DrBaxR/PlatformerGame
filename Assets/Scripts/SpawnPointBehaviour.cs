using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPointBehaviour : MonoBehaviour
{
    public GameObject entity;

    void Start()
    {
        Instantiate(entity, transform.position, Quaternion.identity);
    }
}
