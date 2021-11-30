using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSavePosition : Interactable
{
    SavePlayerPos playerPosData;

    // Start is called before the first frame update
    void Start()
    {
        playerPosData = FindObjectOfType<SavePlayerPos>();
    }

    // Update is called once per frame
    public override void Interact()
    {
        playerPosData.PlayerPosSave();
    }
}
