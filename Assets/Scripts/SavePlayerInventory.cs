using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavePlayerInventory : MonoBehaviour
{
    public GameObject player;

    private Inventory inventory;


    private void Start()
    {
        // inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();

        // for (int i = 0; i < inventory.slots.Length; i++)
        // {
        //     if (PlayerPrefs.GetInt("inventorySlot" + i + "Saved") == 1 && PlayerPrefs.GetInt("TimeToInventory" + i + "Load") == 1)
        //     {
        //         inventory.isFull[i] = true;
        //         inventory.slots[i] = inventory.itemCatalogue[PlayerPrefs.GetInt("inventorySlot" + i)];
        //         Instantiate(inventory.itemCatalogue[PlayerPrefs.GetInt("inventorySlot" + i)], inventory.slots[i].transform, false);
        //         PlayerPrefs.SetInt("TimeToInventorySlot" + i + "Load", 0);
        //         PlayerPrefs.Save();
        //     }
        // }
    }

    public void PlayerInventoryItemSave(int slotNumber, int itemReference)
    {
        PlayerPrefs.SetInt("inventorySlot" + slotNumber, itemReference);
        PlayerPrefs.SetInt("inventorySlot" + slotNumber + "Saved", 1);
        PlayerPrefs.Save();
    }

    public void PlayerInventoryItemLoad(int slotNumber)
    {
        PlayerPrefs.SetInt("TimeToInventory" + slotNumber + "Load", 1);
        PlayerPrefs.Save();
    }
}
