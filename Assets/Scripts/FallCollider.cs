using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallCollider : MonoBehaviour
{
    public PlayerController player;
    public Transform levelStart;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        player.Kill();
    }
}
