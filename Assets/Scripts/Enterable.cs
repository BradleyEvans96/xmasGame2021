using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class Enterable : Interactable
{
    public string sceneName;
    public string[] inventory;

    public bool isLocked;

    public bool savePlayerPosition;

    SavePlayerPos playerPosData;

    //two booleans on enterable objects to check isParentsDoor or isAirport
    // private bool of isLocked which is then determined if

    public override void Interact()
    {
        if (isLocked)
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>().pulseShowMessage("Libby: Damn, it's locked. I need to find the key...");
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
