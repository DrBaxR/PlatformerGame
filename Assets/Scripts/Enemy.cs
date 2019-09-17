using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Damageable
{
    public float speed;
    public int damageAmount;
    public float damageCooldown;
    public GameObject bloodSplash;
    

   

    private void Update()
    {
        CheckforDeath();
    }

    protected void CheckforDeath()
    {
        if (health <= 0)
        {
            Instantiate(bloodSplash, transform.position, Quaternion.identity);
            Destroy(gameObject);
            

        }
    }
}
