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
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
        for (int i = 0; i < inventory.slots.Length; i++)
        {
            if (inventory.isFull[i] == false)
            {
                // Item can be added to the inventory`
                inventory.isFull[i] = true;
                Instantiate(inventoryItem, inventory.slots[i].transform, false);
                for (int j = 0; j < inventory.itemCatalogue.Length; j++)
                {
                    if (inventoryItem == inventory.itemCatalogue[j])
                    {
                        inventory.slotItems[i] = inventory.itemCatalogue[j];
                        playerInventoryData.PlayerInventoryItemSave(i, j);
                        break;
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
        playerInventoryData = FindObjectOfType<SavePlayerInventory>();
    }
}
