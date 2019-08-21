using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingConstraints : MonoBehaviour
{
    public Transform target;
    public float speed;
    public float groundY = 1.0f;
    

    void Update()
    {
        Vector2 targetPos = new Vector2(target.position.x, target.position.y);

        //smooth move on x axis
        transform.position = new Vector3(Mathf.Lerp(transform.position.x, targetPos.x, speed), transform.position.y, -10);

        if(target.position.y > groundY)
        {
            //smooth move on y axis
            transform.position = new Vector3(transform.position.x, Mathf.Lerp(transform.position.y, targetPos.y, speed), -10);
        }

      
    }

    
}
