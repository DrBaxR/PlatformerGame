using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetFollowerX : MonoBehaviour
{
    public Transform target;

    private void Update()
    {
        transform.position = new Vector3(target.position.x, transform.position.y, -10);
    }
}
