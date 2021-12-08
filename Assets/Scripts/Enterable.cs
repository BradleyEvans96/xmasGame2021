using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class Enterable : Interactable
{
    public string sceneName;
    private Inventory inventory;

    public bool isLocked;

    public bool isLibbyParentsDoor;
    public bool isAirport;

    public bool savePlayerPosition;

    SavePlayerPos playerPosData;

    //two booleans on enterable objects to check isParentsDoor or isAirport
    // private bool of isLocked which is then determined if

    public override void Interact()
    {
        bool objectsNeeded = false;
        if (isAirport || isLibbyParentsDoor)
        {
            objectsNeeded = true;
        }
        if (objectsNeeded)
        {
            bool hasObjects = false;
            inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
            if (isLibbyParentsDoor)
            {
                bool hasKey = false;
                for (int i = 0; i < inventory.slots.Length; i++)
                {
                    if (inventory.slotItems[i] == inventory.itemCatalogue[2])
                    {
                        hasKey = true;
                    }
                }
                hasObjects = hasKey;
            }
            if (isAirport)
            {
                bool hasPassport = false;
                bool hasSuitcase = false;
                for (int i = 0; i < inventory.slots.Length; i++)
                {
                    if (inventory.slotItems[i] == inventory.itemCatalogue[1])
                    {
                        hasPassport = true;
                    }
                    if (inventory.slotItems[i] == inventory.itemCatalogue[3])
                    {
                        hasSuitcase = true;
                    }
                }
                hasObjects = hasPassport && hasSuitcase;
            }
            isLocked = !hasObjects;
        }
        if (isLocked)
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>().pulseShowMessage("Libby: Damn, it's locked.");
        }
        else
        {
            if (savePlayerPosition)
            {
                playerPosData.PlayerPosSave();
            }
            SceneManager.LoadScene(sceneName);
        }
    }

    // Added to an object that can be entered
    private void Start()
    {
        playerPosData = FindObjectOfType<SavePlayerPos>();
    }
}
