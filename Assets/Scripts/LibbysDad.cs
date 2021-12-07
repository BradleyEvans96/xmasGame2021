using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LibbysDad : Interactable
{
    private Inventory inventory;
    // Start is called before the first frame update
    public GameObject keyForDoor;

    private bool objectFoundAfterSearch = false;
    void Start()
    {
        keyForDoor.SetActive(false);
    }
    public override void Interact()
    {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
        for (int i = 0; i < inventory.slots.Length; i++)
        {
            if (inventory.isFull[i] == true)
            {
                if (inventory.slotItems[i] == inventory.itemCatalogue[0])
                {
                    keyForDoor.SetActive(true);
                    objectFoundAfterSearch = true;
                    inventory.isFull[i] = false;
                    inventory.slotItems[i] = null;
                    GameObject.FindGameObjectWithTag("Slot " + i).GetComponent<Slot>().UseItem();
                    PlayerPrefs.DeleteKey("inventorySlot" + i);
                    PlayerPrefs.DeleteKey("inventorySlot" + i + "Saved");
                }
            }
        }
        if (!objectFoundAfterSearch)
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>().pulseShowMessage("Dad: I can't give you the key yet! Let's make a trade?");
        }
        else
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>().pulseShowMessage("Dad: Nom Nom! Thanks, here is the key for the door!");
        }
    }
    // Update is called once per frame
}