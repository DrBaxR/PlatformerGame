using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public Transform platform;
    public Transform[] points;
    public float speed;

    private int currentTarget;

    private void Start()
    {
        currentTarget = 1;
    }

    private void Update()
    {
        platform.transform.position = Vector2.MoveTowards(platform.transform.position, points[currentTarget].position, speed * Time.deltaTime);
        if(platform.transform.position == points[currentTarget].position)
        {
            currentTarget++;
            if (currentTarget > points.Length - 1)
                currentTarget = 0;
        }
    }
}
