using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : Pickable
{
    // Start is called before the first frame update
    private Inventory inventory;
    public GameObject inventoryItem;

    public override void Interact()
    {
        for (int i = 0; i < inventory.slots.Length; i++)
        {
            if (inventory.isFull[i] == false)
            {
                // Item can be added to the inventory
                inventory.isFull[i] = true;
                Instantiate(inventoryItem, inventory.slots[i].transform, false);
                Destroy(gameObject);
                break;
            }
        }
    }

    // Added to an object that can be entered
    private void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
    }
}
