using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//BEWARE: UGLY ASS CODE
public class Flicker : MonoBehaviour
{
    float n;
    float fps;
    public GameObject target;
    bool toDo;

    private void Start()
    {
        fps = 1.0f / Time.deltaTime;
        toDo = false;
    }

    void Update()
    {
        if(n >= fps)
        {
            target.SetActive(toDo);
            toDo = !toDo;
            n = 0;
        }
        else
        {
            n++;
        }
    }
}
