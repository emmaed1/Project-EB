using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupItems : MonoBehaviour
{

    public int cashValue = 1;

    private void OnTriggerEnter3D(Collider other) { 
        if(other.tag == "Player")
        {
            InventoryInterface inventory = other.GetComponent<InventoryInterface>();

            if (inventory != null )
            {
                inventory.Money = inventory.Money + cashValue;
                print("Player Inventory has " + inventory.Money + " money in it.");
                gameObject.SetActive(false);
            }
        }
    }
}
