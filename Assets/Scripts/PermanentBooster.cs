using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PermanentBooster : MonoBehaviour
{

    public int increaseDamage;
    //public EnemyController1 enemy;
    //public Text popUpText;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            //Time.timeScale = 0;
            
            
           
            PlayerController player = collision.GetComponent<PlayerController>();
            player.maxDamage += increaseDamage;
            player.attackDamage = player.maxDamage;
           
           // enemy.damageAmount += increaseDamage;
            Destroy(gameObject);
           // Time.timeScale = 1;
                
               
            
           

            

        }
    }
}
