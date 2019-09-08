using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyIfKeyPressed : MonoBehaviour
{
    private void Update()
    {
        if(Input.anyKeyDown)
        {
            Destroy(gameObject);
            Time.timeScale = 1.0f;
        }
    }
}
