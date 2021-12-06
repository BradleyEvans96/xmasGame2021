using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : Pickable
{
    // Start is called before the first frame update
    private Inventory inventory;
    public GameObject inventoryItem;
    SavePlayerInventory playerInventoryData;

    public override void Interact()
    {
        for (int i = 0; i < inventory.slots.Length; i++)
        {
            if (inventory.isFull[i] == false)
            {
                // Item can be added to the inventory`
                inventory.isFull[i] = true;
                Instantiate(inventoryItem, inventory.slots[i].transform, false);
                for (int j = 0; j < inventory.itemCatalogue.Length; j++)
                {
                    Debug.Log("Catalogue: " + inventory.itemCatalogue[i]);
                    Debug.Log("Picked Up: " + inventoryItem);
                    if (inventoryItem == inventory.itemCatalogue[j])
                    {
                        playerInventoryData.PlayerInventoryItemSave(i, j);
                    }
                }
                Destroy(gameObject);
                break;
            }
        }
    }

    // Added to an object that can be entered
    private void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
        playerInventoryData = FindObjectOfType<SavePlayerInventory>();
    }
}
