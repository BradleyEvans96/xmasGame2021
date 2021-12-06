using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Quit : MonoBehaviour
{
    SavePlayerInventory playerInventoryData;

    SavePlayerPos playerPosData;

    private Inventory inventory;


    void Start()
    {
        playerInventoryData = FindObjectOfType<SavePlayerInventory>();
        playerPosData = FindObjectOfType<SavePlayerPos>();
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
    }

    public void QuitGame()
    {
        for (int i = 0; i < inventory.slots.Length; i++)
        {
            PlayerPrefs.DeleteKey("inventorySlot" + i);
            PlayerPrefs.DeleteKey("inventorySlot" + i + "Saved");
            PlayerPrefs.DeleteKey("TimeToInventorySlot" + i + "Load");
        }
        PlayerPrefs.DeleteKey("p_x");
        PlayerPrefs.DeleteKey("p_y");
        PlayerPrefs.DeleteKey("TimeToLoad");
        PlayerPrefs.DeleteKey("Saved");

        SceneManager.LoadScene("SnowScene");
    }
}

