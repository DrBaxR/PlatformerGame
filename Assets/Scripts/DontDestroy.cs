using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroy : MonoBehaviour
{
    public void Start()
    {
        GameObject.DontDestroyOnLoad(gameObject);
    }
}
