using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    public string nameOfItem;
    public GameObject self;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player")) 
        {
            PlaceBomb tmp = col.GetComponent<PlaceBomb>();
            MoveCharacter tmp2 = col.GetComponent<MoveCharacter>();
            Health tmp3 = col.GetComponent<Health>();
            if (nameOfItem == "ItemBomb" && tmp) 
            {
                tmp.amountBomb += 1;
            }

            if (nameOfItem == "ItemExplosionRadius" && tmp) 
            {
                tmp.explosionRadius += 1;
            }

            if (nameOfItem == "ItemSpeed" && tmp2) 
            {
                tmp3.currentSpeed += 1;
            }
            Destroy(self);
        }
    }
}
