using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    SavePlayerInventory playerInventoryData;
    public bool[] isFull;
    public GameObject[] slots;

    public GameObject[] itemCatalogue;

    public GameObject[] slotItems;

    private void Start()
    {
        playerInventoryData = FindObjectOfType<SavePlayerInventory>();
    }

    private void Awake()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (PlayerPrefs.GetInt("inventorySlot" + i + "Saved") == 1 && PlayerPrefs.GetInt("TimeToInventory" + i + "Load") == 1)
            {
                isFull[i] = true;
                Instantiate(itemCatalogue[PlayerPrefs.GetInt("inventorySlot" + i)], slots[i].transform, false);
                slotItems[i] = itemCatalogue[PlayerPrefs.GetInt("inventorySlot" + i)];
                PlayerPrefs.SetInt("TimeToInventorySlot" + i + "Load", 0);
                PlayerPrefs.Save();
            }
        }
    }
}