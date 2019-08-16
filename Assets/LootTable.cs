using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootTable : MonoBehaviour
{
    float dropRate = 0.25f;
    public void DropItem(GameObject[] dropItems)
    {
        if(Random.Range(0f,1f)<=dropRate)
        {
            int indexToDrop = Random.Range(0, dropItems.Length);
           
            Instantiate(dropItems[indexToDrop],transform.position, transform.rotation);
        }
    }
}
