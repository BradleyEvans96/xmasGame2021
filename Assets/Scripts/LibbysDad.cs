using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LibbysDad : Interactable
{
    private Inventory inventory;
    public GameObject porkScratchings;
    // Start is called before the first frame update
    public GameObject keyForDoor;

    private bool objectFoundAfterSearch = false;
    void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
        keyForDoor.SetActive(false);
    }

    public override void Interact()
    {
        for (int i = 0; i < inventory.slots.Length; i++)
        {
            if (inventory.isFull[i] == true)
            {
                Debug.Log("Slot Full");
                Debug.Log(inventory.slots[i]);
                Debug.Log(porkScratchings);
                if (inventory.slots[i] == porkScratchings)
                {
                    Debug.Log("Pork Scratchings Found");
                    keyForDoor.SetActive(true);
                    inventory.isFull[i] = false;
                    inventory.slots[i] = null;
                    PlayerPrefs.DeleteKey("inventorySlot" + i);
                    PlayerPrefs.DeleteKey("inventorySlot" + i + "Saved");
                }
            }
        }
        if (!objectFoundAfterSearch)
        {

        }
    }
    // Update is called once per frame
    void Update()
    {

    }
}
