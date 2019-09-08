using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyIfKeyPressed : MonoBehaviour
{
    public ProgressiveText text;

    private void Update()
    {
        if(Input.anyKeyDown)
        {
            if (text.textDone)
            {
                Destroy(gameObject);
                Time.timeScale = 1.0f;
            }
            else
            {
                text.textDone = true;
            }
        }
    }
}
