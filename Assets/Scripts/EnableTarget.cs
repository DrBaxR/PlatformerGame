using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableTarget : MonoBehaviour
{
    public GameObject target;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            Time.timeScale = 0.0f;
            target.SetActive(true);
            Destroy(gameObject);
        }
    }
}
