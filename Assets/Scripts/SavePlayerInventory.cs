using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavePlayerInventory : MonoBehaviour
{
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
