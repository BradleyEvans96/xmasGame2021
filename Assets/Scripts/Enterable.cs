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

    public override void Interact()
    {
        if (isLocked)
        {
            // commentaryText.text = "This room is locked. You shall not pass";
            Debug.Log("This room is locked, you shall not pass");
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
