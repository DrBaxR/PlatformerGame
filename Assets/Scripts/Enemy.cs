using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Damageable
{
    public float speed;
    public int damageAmount;
    public float damageCooldown;

    private void Update()
    {
        CheckforDeath();
    }

    protected void CheckforDeath()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
