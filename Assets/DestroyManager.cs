using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyManager : MonoBehaviour
{
    private void Awake()
    {
        GameObject gm = GameObject.FindGameObjectWithTag("GameController");
        if(gm != null)
        {
            Destroy(gm);
        }
    }
}
